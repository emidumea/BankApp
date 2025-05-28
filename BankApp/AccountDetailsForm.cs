using System;
using System.Windows.Forms;
using BankApp.Data;

namespace BankApp
{
    /// <summary>
    /// Formular pentru afișarea detaliilor contului utilizatorului.
    /// </summary>
    public partial class AccountDetailsForm : Form
    {
        private User currentUser;

        /// <summary>
        /// Constructor ce inițializează formularul cu datele utilizatorului.
        /// </summary>
        /// <param name="user">Utilizatorul curent conectat.</param>
        public AccountDetailsForm(User user)
        {
            InitializeComponent();
            currentUser = user;

            // Afișează datele
            lblName.Text = $"Nume: {currentUser.FullName}";
            lblIBAN.Text = $"IBAN: {currentUser.IBAN}";
            lblBalance.Text = $"Sold: {currentUser.Balance} RON";
        }

        /// <summary>
        /// Butonul de închidere revine la dashboard-ul utilizatorului.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new UserDashboardForm(AplicatieBancara.currentUser));

        }
    }
}
