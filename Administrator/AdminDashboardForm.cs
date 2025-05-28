using System;
using System.Windows.Forms;
using BankApp.Models;

namespace BankApp.Administrator
{
    /// <summary>
    /// Formular principal pentru funcționalitățile administratorului.
    /// </summary>
    public partial class AdminDashboardForm : Form
    {
        private User currentUser;

        /// <summary>
        /// Inițializează dashboard-ul cu datele administratorului.
        /// </summary>
        /// <param name="user">Utilizatorul de tip administrator autentificat.</param>
        public AdminDashboardForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            lblAdminWelcome.Text = $"Bun venit, {currentUser.FullName}!";
        }

        /// <summary>
        /// Deschide formularul pentru adăugarea unui utilizator nou.
        /// </summary>
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AplicatieBancara.currentUser = currentUser; // dacă mai ai nevoie în alte formuri
            AplicatieBancara.SetNewForm(new AddUserForm());
        }

        /// <summary>
        /// Deschide formularul pentru căutarea unui utilizator existent.
        /// </summary>
        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            AplicatieBancara.currentUser = currentUser;
            AplicatieBancara.SetNewForm(new SearchUserForm());
        }

        /// <summary>
        /// Deschide formularul pentru resetarea parolei unui utilizator.
        /// </summary>
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            AplicatieBancara.currentUser = currentUser;
            AplicatieBancara.SetNewForm(new ResetPasswordForm());
        }

        /// <summary>
        /// Deconectează utilizatorul și revine la ecranul de login.
        /// </summary>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new LoginForm());
        }
    }
}
