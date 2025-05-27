using System;
using System.Linq;
using System.Windows.Forms;
using BankApp.Models;
using BankApp.Data;

namespace BankApp
{
    public partial class TransactionForm : Form
    {
        private User currentUser;

        public TransactionForm(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string destIban = txtDestIban.Text.Trim();
            string sumaText = txtAmount.Text.Trim();

            if (string.IsNullOrWhiteSpace(destIban) || string.IsNullOrWhiteSpace(sumaText))
            {
                MessageBox.Show("Completează toate câmpurile.");
                return;
            }

            if (!decimal.TryParse(sumaText, out decimal suma) || suma <= 0)
            {
                MessageBox.Show("Suma introdusă nu este validă.");
                return;
            }

            using (var context = new AppDbContext())
            {
                var senderUser = context.Users.FirstOrDefault(u => u.Id == currentUser.Id);
                var recipient = context.Users.FirstOrDefault(u => u.IBAN == destIban);

                if (recipient == null)
                {
                    MessageBox.Show("Destinatarul nu a fost găsit.");
                    return;
                }

                if (senderUser.Balance < suma)
                {
                    MessageBox.Show("Fonduri insuficiente.");
                    return;
                }

                // Executăm tranzacția
                senderUser.Balance -= suma;
                recipient.Balance += suma;

                context.Transactions.Add(new Transaction
                {
                    FromUser = senderUser.IBAN,
                    ToUser = recipient.IBAN,
                    Amount = suma,
                    Timestamp = DateTime.Now
                });

                context.SaveChanges(); // 🔐 Salvăm modificările

                MessageBox.Show($"Ai trimis {suma} RON către {recipient.FullName} ({recipient.IBAN}).");

                // Actualizăm currentUser local cu noul sold
                currentUser.Balance = senderUser.Balance;

                AplicatieBancara.SetNewForm(new UserDashboardForm(currentUser));
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new UserDashboardForm(currentUser));
        }
    }
}
