using BankApp.Data;
using BankApp.Exceptions;
using System;
using System.Linq;
using System.Windows.Forms;
using BankApp.Validation;

namespace BankApp
{
    /// <summary>
    /// Formular pentru efectuarea unei tranzacții bancare.
    /// </summary>
    public partial class TransactionForm : Form
    {
        private User currentUser;


        /// <summary>
        /// Inițializează formularul pentru utilizatorul curent.
        /// </summary>
        /// <param name="user">Utilizatorul autentificat.</param>
        public TransactionForm(User user)
        {
            InitializeComponent();
            currentUser = user;
        }


        /// <summary>
        /// Confirmă tranzacția, aplică validări și o salvează în baza de date.
        /// </summary>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string destIban = txtDestIban.Text.Trim();
                string sumaText = txtAmount.Text.Trim();

                if (string.IsNullOrWhiteSpace(destIban) || string.IsNullOrWhiteSpace(sumaText))
                    throw new TransactionValidationException("Completează toate câmpurile.");

                if (!decimal.TryParse(sumaText, out decimal suma) || suma <= 0)
                    throw new TransactionValidationException("Suma introdusă nu este validă.");

                using (var context = new BankApp.Data.Data.AppDbContext())
                {
                    var senderUser = context.Users.FirstOrDefault(u => u.Id == currentUser.Id)
                        ?? throw new TransactionValidationException("Expeditorul nu a fost găsit.");

                    var recipient = context.Users.FirstOrDefault(u => u.IBAN == destIban)
                        ?? throw new TransactionValidationException("Destinatarul nu a fost găsit.");

                    if (senderUser.Balance < suma)
                        throw new InsufficientFundsException("Fonduri insuficiente pentru a efectua tranzacția.");

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

                    context.SaveChanges();

                    MessageBox.Show($"Ai trimis {suma} RON către {recipient.FullName} ({recipient.IBAN}).");

                    currentUser.Balance = senderUser.Balance;
                    AplicatieBancara.SetNewForm(new UserDashboardForm(currentUser));
                }
            }
            catch (TransactionValidationException ex)
            {
                MessageBox.Show(ex.Message, "Eroare tranzacție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InsufficientFundsException ex)
            {
                MessageBox.Show(ex.Message, "Fonduri insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare neașteptată: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Butonul de revenire la dashboard.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new UserDashboardForm(currentUser));
        }
    }
}
