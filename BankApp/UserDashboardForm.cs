/**************************************************************************
 *                                                                        *
 *  File:        UserDashboardForm.cs                                    *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Interfață principală pentru utilizatorul autentificat.  *
 *               Oferă acces la cont, tranzacții, istoric și setări.     *
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
namespace BankApp
{
    /// <summary>
    /// Formular principal pentru utilizator după autentificare.
    /// Afișează opțiuni precum: detalii cont, tranzacții, istoric, setări.
    /// </summary>
    public partial class UserDashboardForm : Form
    {
        private User currentUser;


        /// <summary>
        /// Inițializează dashboard-ul utilizatorului și setează mesajul de bun venit.
        /// </summary>
        /// <param name="user">Obiectul utilizator autentificat.</param>
        public UserDashboardForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            welcomeLabel.Text = $"Bun venit, {currentUser.FullName}!";
        }


        /// <summary>
        /// Navighează către formularul cu detalii despre cont.
        /// </summary>
        private void detailsBtn_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new AccountDetailsForm(AplicatieBancara.currentUser));
        }


        /// <summary>
        /// Revine la ecranul de autentificare (logout).
        /// </summary>
        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new LoginForm());
        }

        /// <summary>
        /// Deschide formularul pentru inițierea unei tranzacții.
        /// </summary>
        private void transactionBtn_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new TransactionForm(currentUser));
        }


        /// <summary>
        /// Deschide formularul cu istoricul tranzacțiilor.
        /// </summary>
        private void historyBtn_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new TransactionHistoryForm(currentUser));
        }

            
        /// <summary>
        /// Deschide formularul de modificare a parolei.
        /// </summary>
        private void settingsBtn_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new SettingsForm(currentUser));
        }

    }
}
