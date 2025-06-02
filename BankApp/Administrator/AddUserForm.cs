/**************************************************************************
 *                                                                        *
 *  File:        AddUserForm.cs                                          *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Formular pentru administrator pentru adăugarea de       *
 *               utilizatori noi, cu validări și verificări de duplicate.*
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
using BankApp.Exceptions;

namespace BankApp.Administrator
{
    /// <summary>
    /// Formular pentru adăugarea unui nou utilizator de către administrator.
    /// </summary>
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();

            cmbRole.Items.Add("User");
            cmbRole.Items.Add("Admin");
            cmbRole.SelectedIndex = 0;

        }


        /// <summary>
        /// Creează un utilizator nou pe baza datelor introduse, după validare completă.
        /// </summary>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string iban = txtIBAN.Text.Trim();
            string role = cmbRole.SelectedItem.ToString();
            string balanceText = txtBalance.Text.Trim();

            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                    string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(iban) ||
                    string.IsNullOrWhiteSpace(balanceText))
                {
                    throw new FormValidationException("Completează toate câmpurile.");
                }

                var validator = new PasswordValidator(new StrongPasswordValidation());
                if (!validator.Validate(password))
                {
                    throw new PasswordValidationException("Parola trebuie să aibă minim 8 caractere, o literă mare, una mică și o cifră.");
                }

                if (!decimal.TryParse(balanceText, out decimal balance) || balance < 0)
                {
                    throw new FormValidationException("Soldul trebuie să fie un număr pozitiv.");
                }

                using (var context = new BankApp.Data.Data.AppDbContext())
                {
                    bool exists = context.Users.Any(u => u.Username == username || u.IBAN == iban);
                    if (exists)
                    {
                        throw new DuplicateUserException("Există deja un utilizator cu acest username sau IBAN.");
                    }

                    var newUser = new User
                    {
                        Username = username,
                        Password = password,
                        FullName = fullName,
                        IBAN = iban,
                        Balance = balance,
                        Role = role
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();
                }

                MessageBox.Show("Utilizatorul a fost creat cu succes.");
                AplicatieBancara.SetNewForm(new AdminDashboardForm(AplicatieBancara.currentUser));
            }
            catch (FormValidationException ex)
            {
                MessageBox.Show($"Eroare de validare formular: {ex.Message}");
            }
            catch (PasswordValidationException ex)
            {
                MessageBox.Show($"Eroare de validare parolă: {ex.Message}");
            }
            catch (DuplicateUserException ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare necunoscută: {ex.Message}");
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
