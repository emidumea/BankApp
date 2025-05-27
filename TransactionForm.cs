using System;
using System.Linq;
using System.Windows.Forms;

namespace BankApp
{
    public partial class TransactionForm : Form
    {
        private LoginForm.User currentUser;

        public TransactionForm(LoginForm.User user)
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

            if (currentUser.Balance < suma)
            {
                MessageBox.Show("Fonduri insuficiente.");
                return;
            }

            var recipient = AplicatieBancara.users.FirstOrDefault(u => u.IBAN == destIban);

            if (recipient == null)
            {
                MessageBox.Show("Destinatarul nu a fost găsit.");
                return;
            }

            // Executăm tranzacția
            currentUser.Balance -= suma;
            recipient.Balance += suma;

            MessageBox.Show($"Ai trimis {suma} RON către {recipient.FullName} ({recipient.IBAN}).");


            // Revenim la dashboard
            AplicatieBancara.SetNewForm(new UserDashboardForm(currentUser));
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new UserDashboardForm(currentUser));
        }
    }
}
