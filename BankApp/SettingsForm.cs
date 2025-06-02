/**************************************************************************
 *                                                                        *
 *  File:        SettingsForm.cs                                         *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Formular pentru modificarea parolei utilizatorului      *
 *               autentificat, cu validări stricte și feedback vizual.   *
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
using System.Linq;
using System.Windows.Forms;
using BankApp.Data;
using BankApp.Exceptions;
using BankApp;

namespace BankApp
{
    public partial class SettingsForm : Form
    {
        private User currentUser;

        public SettingsForm(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        /// <summary>
        /// Confirmă schimbarea parolei după validare prin AppService.
        /// </summary>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string current = txtCurrentPass.Text;
            string newPass = txtNewPass.Text;
            string confirm = txtConfirmPass.Text;

            try
            {
                using (var context = new BankApp.Data.Data.AppDbContext())
                {
                    var service = new AppService(context);
                    service.ChangePassword(currentUser.Id, current, newPass, confirm);
                }

                MessageBox.Show("Parola a fost schimbată cu succes!");
                currentUser.Password = newPass; // actualizează și în memorie
                AplicatieBancara.SetNewForm(new UserDashboardForm(currentUser));
            }
            catch (PasswordValidationException ex)
            {
                MessageBox.Show($"Validare parolă: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormValidationException ex)
            {
                MessageBox.Show($"Eroare formular: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (UserNotFoundException ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare neașteptată: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new UserDashboardForm(currentUser));
        }
    }
}
