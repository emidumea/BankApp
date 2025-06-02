/**************************************************************************
 *                                                                        *
 *  File:        AdminDashboardForm.cs                                   *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Interfață principală pentru administrator. Permite      *
 *               gestionarea utilizatorilor (adăugare, căutare, resetare).*
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify *
 *  it under the terms of the GNU General Public License as published by *
 *  the Free Software Foundation. This program is distributed in the     *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even  *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR  *
 *  PURPOSE. See the GNU General Public License for more details.        *
 *                                                                        *
 **************************************************************************/


using System;
using System.Windows.Forms;
using BankApp.Data;

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
