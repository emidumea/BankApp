using System;
using System.Windows.Forms;
using BankApp.Models;

namespace BankApp.Administrator
{
    public partial class AdminDashboardForm : Form
    {
        private User currentUser;

        public AdminDashboardForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            lblAdminWelcome.Text = $"Bun venit, {currentUser.FullName}!";
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AplicatieBancara.currentUser = currentUser; // dacă mai ai nevoie în alte formuri
            AplicatieBancara.SetNewForm(new AddUserForm());
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            AplicatieBancara.currentUser = currentUser;
            AplicatieBancara.SetNewForm(new SearchUserForm());
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            AplicatieBancara.currentUser = currentUser;
            AplicatieBancara.SetNewForm(new ResetPasswordForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new LoginForm());
        }
    }
}
