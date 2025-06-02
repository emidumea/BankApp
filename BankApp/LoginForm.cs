/**************************************************************************
 *                                                                        *
 *  File:        LoginForm.cs                                                *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel  *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                          *
 *  Website:     https://github.com/emidumea/BankApp                      *
 *  Description: Formularul principal de autentificare                       *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
/**************************************************************************
 *                                                                        *
 *  File:        LoginForm.cs                                            *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Formul pentru autentificarea utilizatorului în aplicație.
 *               Validează datele și redirecționează către dashboard.    *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify *
 *  it under the terms of the GNU General Public License as published by *
 *  the Free Software Foundation. This program is distributed in the     *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even  *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR  *
 *  PURPOSE. See the GNU General Public License for more details.        *
 *                                                                        *
 **************************************************************************/



using BankApp.Administrator;
using BankApp.Data;
using BankApp.Validation;
using BankApp.Exceptions;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BankApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Gestionează logica de autentificare atunci când utilizatorul apasă butonul de login.
        /// Validează parola, caută utilizatorul în baza de date și redirecționează spre dashboard.
        /// </summary>
        /// <param name="sender">Obiectul care a declanșat evenimentul (butonul).</param>
        /// <param name="e">Datele evenimentului declanșat.</param>
        /// <exception cref="PasswordValidationException">Aruncată dacă parola nu respectă cerințele de validare.</exception>
        /// <exception cref="UserNotFoundException">Aruncată dacă utilizatorul nu este găsit în baza de date.</exception>
        /// <exception cref="Exception">Pentru alte erori neprevăzute.</exception>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;

                IValidationStrategy validator = new SimplePasswordValidation();
                if (!validator.IsValid(password))
                    throw new PasswordValidationException("Parola introdusă este prea scurtă (minim 4 caractere).");

                using (var context = new BankApp.Data.Data.AppDbContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

                    if (user == null)
                        throw new UserNotFoundException("Utilizatorul sau parola nu sunt corecte.");

                    AplicatieBancara.currentUser = user;
                    MessageBox.Show($"Autentificare reușită ca {user.Role}!");

                    if (user.Role == "Admin")
                        AplicatieBancara.SetNewForm(new AdminDashboardForm(user));
                    else
                        AplicatieBancara.SetNewForm(new UserDashboardForm(user));
                }
            }
            catch (PasswordValidationException ex)
            {
                MessageBox.Show(ex.Message, "Eroare validare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (UserNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Autentificare eșuată", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare neașteptată: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
