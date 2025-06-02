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
using BankApp.Validation;

namespace BankApp
{
    public partial class SettingsForm : Form
    {
        private User currentUser;

        /// <summary>
        /// Formular pentru modificarea parolei utilizatorului.
        /// </summary>
        public SettingsForm(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        /// <summary>
        /// Confirmă schimbarea parolei după validări.
        /// </summary>  
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string current = txtCurrentPass.Text;
            string newPass = txtNewPass.Text;
            string confirm = txtConfirmPass.Text;

            try
            {
                if (string.IsNullOrWhiteSpace(current) || string.IsNullOrWhiteSpace(newPass) || string.IsNullOrWhiteSpace(confirm))
                    throw new Exception("Completează toate câmpurile.");

                if (current != currentUser.Password)
                    throw new Exception("Parola actuală este incorectă.");

                if (newPass != confirm)
                    throw new Exception("Parola nouă și confirmarea nu coincid.");

                // Strategy Pattern cu excepție
                var validator = new PasswordValidator(new StrongPasswordValidation());
                validator.Validate(newPass); // dacă e invalidă, aruncă PasswordValidationException

                using (var context = new BankApp.Data.Data.AppDbContext())
                {
                    var userInDb = context.Users.FirstOrDefault(u => u.Id == currentUser.Id);

                    if (userInDb == null)
                        throw new Exception("Eroare: utilizatorul nu a fost găsit în baza de date.");

                    userInDb.Password = newPass;
                    context.SaveChanges();

                    currentUser.Password = newPass;
                }

                MessageBox.Show("Parola a fost schimbată cu succes!");
                AplicatieBancara.SetNewForm(new UserDashboardForm(currentUser));
            }
            catch (BankApp.Exceptions.PasswordValidationException ex)
            {
                MessageBox.Show($"Validare parolă: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}");
            }
        }


        /// <summary>
        /// Revenire la dashboard.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new UserDashboardForm(currentUser));
        }
    }
}
