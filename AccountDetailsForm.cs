using System;
using System.Windows.Forms;
using BankApp.Models;

namespace BankApp
{
    public partial class AccountDetailsForm : Form
    {
        private User currentUser;

        public AccountDetailsForm(User user)
        {
            InitializeComponent();
            currentUser = user;

            // Afișează datele
            lblName.Text = $"Nume: {currentUser.FullName}";
            lblIBAN.Text = $"IBAN: {currentUser.IBAN}";
            lblBalance.Text = $"Sold: {currentUser.Balance} RON";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new UserDashboardForm(AplicatieBancara.currentUser));

        }
    }
}
