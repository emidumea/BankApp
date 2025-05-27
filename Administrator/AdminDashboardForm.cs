using System;
using System.Windows.Forms;

namespace BankApp.Administrator
{
    public partial class AdminDashboardForm : Form
    {
        private LoginForm.User currentUser;

        public AdminDashboardForm(LoginForm.User user)
        {
            InitializeComponent();
            currentUser = user;
            lblAdminWelcome.Text = $"Bun venit, {currentUser.FullName}!";
        }



        //private void btnSearchUser_Click(object sender, EventArgs e)
        //{
        //    AplicatieBancara.SetNewForm(new SearchUserForm());
        //}

        //private void btnResetPassword_Click(object sender, EventArgs e)
        //{
        //    AplicatieBancara.SetNewForm(new ResetPasswordForm());
        //}

        //private void btnViewTransactions_Click(object sender, EventArgs e)
        //{
        //    AplicatieBancara.SetNewForm(new TransactionListAdminForm());
        //}

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new LoginForm());
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new AddUserForm());
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new SearchUserForm());
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new ResetPasswordForm());
        }
    }
}
