/**************************************************************************
 *                                                                        *
 *  File:        LoginForm.cs                                            *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Formularul principal de autentificare                   *
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
using BankApp.Exceptions;
using BankApp;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace BankApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            AdaugaButonAjutor();
        }

        /// <summary>
        /// Gestionează logica de autentificare atunci când utilizatorul apasă butonul de login.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            try
            {
                using (var context = new BankApp.Data.Data.AppDbContext())
                {
                    var service = new AppService(context);
                    var user = service.Login(username, password);

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

        private void AdaugaButonAjutor()
        {
            Button btnHelp = new Button();
            btnHelp.Text = "Ajutor";
            btnHelp.Size = new Size(70, 30);
            btnHelp.Location = new Point(this.ClientSize.Width - 80, 10);
            btnHelp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHelp.Click += (s, e) => AplicatieBancara.DeschideHelp(this);

            this.Controls.Add(btnHelp);

            // Opțional: shortcut F1
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.F1)
                {
                    AplicatieBancara.DeschideHelp(this);
                }
            };
        }

    }
}