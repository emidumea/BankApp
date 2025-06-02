/**************************************************************************
 *                                                                        *
 *  File:        AccountDetailsForm.cs                                   *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Afișează detaliile contului curent: nume complet, IBAN  *
 *               și sold. Permite revenirea la dashboard.                *
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
    /// Formular pentru afișarea detaliilor contului utilizatorului.
    /// </summary>
    public partial class AccountDetailsForm : Form
    {
        private User currentUser;

        /// <summary>
        /// Constructor ce inițializează formularul cu datele utilizatorului.
        /// </summary>
        /// <param name="user">Utilizatorul curent conectat.</param>
        public AccountDetailsForm(User user)
        {
            InitializeComponent();
            currentUser = user;

            // Afișează datele
            lblName.Text = $"Nume: {currentUser.FullName}";
            lblIBAN.Text = $"IBAN: {currentUser.IBAN}";
            lblBalance.Text = $"Sold: {currentUser.Balance} RON";
        }

        /// <summary>
        /// Butonul de închidere revine la dashboard-ul utilizatorului.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new UserDashboardForm(AplicatieBancara.currentUser));

        }
    }
}
