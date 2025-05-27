using System;
using System.Windows.Forms;

namespace BankApp
{
    public partial class AccountDetailsForm : Form
    {
        private LoginForm.User currentUser;

        public AccountDetailsForm(LoginForm.User user)
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
            this.Close();
        }
    }
}
