using System;
using System.Windows.Forms;

namespace BankApp
{
    public partial class UserDashboardForm : Form
    {
        private LoginForm.User currentUser;

        public UserDashboardForm(LoginForm.User user)
        {
            InitializeComponent();
            currentUser = user;
            welcomeLabel.Text = $"Bun venit, {currentUser.FullName}!";
        }

        private void detailsBtn_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new AccountDetailsForm(AplicatieBancara.currentUser));
        }


        //private void transactionBtn_Click(object sender, EventArgs e)
        //{
        //    TransactionForm transactionForm = new TransactionForm(currentUser);
        //    transactionForm.ShowDialog();
        //}

        //private void historyBtn_Click(object sender, EventArgs e)
        //{
        //    TransactionHistoryForm historyForm = new TransactionHistoryForm(currentUser);
        //    historyForm.ShowDialog();
        //}

        //private void settingsBtn_Click(object sender, EventArgs e)
        //{
        //    SettingsForm settingsForm = new SettingsForm(currentUser);
        //    settingsForm.ShowDialog();
        //}

        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new LoginForm());
        }

        private void transactionBtn_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new TransactionForm(currentUser));
        }
    }
}
