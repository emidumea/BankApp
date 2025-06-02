/**************************************************************************
 *                                                                        *
 *  File:        ResetPasswordForm.cs                                    *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Formular pentru resetarea parolei unui utilizator de    *
 *               către administrator, cu validare și control erori.      *
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
using BankApp.Exceptions;
using BankApp;

namespace BankApp.Administrator
{
    /// <summary>
    /// Formular pentru resetarea parolei unui utilizator de către administrator.
    /// </summary>
    public partial class ResetPasswordForm : Form
    {
        /// <summary>
        /// Constructorul formularului pentru resetarea parolei.
        /// </summary>
        public ResetPasswordForm()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Execută logica de resetare a parolei prin AppService.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            string username = txtUsernameConfirm.Text.Trim();
            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirm.Text;

            try
            {
                using (var context = new BankApp.Data.Data.AppDbContext())
                {
                    var service = new AppService(context);
                    service.AdminResetPassword(username, newPass, confirmPass);
                }

                MessageBox.Show($"Parola pentru utilizatorul {username} a fost resetată cu succes.");
                AplicatieBancara.SetNewForm(new AdminDashboardForm(AplicatieBancara.currentUser));
            }
            catch (FormValidationException ex)
            {
                MessageBox.Show($"Eroare formular: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (PasswordValidationException ex)
            {
                MessageBox.Show($"Eroare parolă: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (UserNotFoundException ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare necunoscută: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Revine la dashboard-ul administratorului.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new AdminDashboardForm(AplicatieBancara.currentUser));
        }
    }
}
