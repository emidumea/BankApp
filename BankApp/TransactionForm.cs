/**************************************************************************
 *                                                                        *
 *  File:        TransactionForm.cs                                      *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Formular pentru efectuarea unei tranzacții bancare.     *
 *               Realizează validări și actualizează soldurile.          *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify *
 *  it under the terms of the GNU General Public License as published by *
 *  the Free Software Foundation. This program is distributed in the     *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even  *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR  *
 *  PURPOSE. See the GNU General Public License for more details.        *
 *                                                                        *
 **************************************************************************/

using BankApp.Data;
using BankApp.Exceptions;
using System;
using System.Windows.Forms;

namespace BankApp
{
    /// <summary>
    /// Formular grafic pentru inițierea unei tranzacții bancare de către utilizator.
    /// </summary>
    public partial class TransactionForm : Form
    {
        private User currentUser;

        /// <summary>
        /// Constructor care inițializează formularul pentru utilizatorul autentificat.
        /// </summary>
        /// <param name="user">Utilizatorul curent autentificat.</param>
        public TransactionForm(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        /// <summary>
        /// Eveniment declanșat la apăsarea butonului "Confirmă".
        /// Inițiază validarea și procesarea tranzacției prin AppService.
        /// </summary>
        /// <param name="sender">Butonul de confirmare.</param>
        /// <param name="e">Datele evenimentului declanșat.</param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string destIban = txtDestIban.Text.Trim();
            string sumaText = txtAmount.Text.Trim();

            try
            {
                if (!decimal.TryParse(sumaText, out decimal suma))
                    throw new TransactionValidationException("Suma introdusă nu este validă.");

                using (var context = new BankApp.Data.Data.AppDbContext())
                {
                    var service = new AppService(context);
                    service.ExecuteTransaction(currentUser.Id, destIban, suma);

                    var updated = context.Users.Find(currentUser.Id);
                    currentUser.Balance = updated.Balance;

                    MessageBox.Show($"Ai trimis {suma} RON către {destIban}.");
                    AplicatieBancara.SetNewForm(new UserDashboardForm(currentUser));
                }
            }
            catch (TransactionValidationException ex)
            {
                MessageBox.Show(ex.Message, "Eroare validare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InsufficientFundsException ex)
            {
                MessageBox.Show(ex.Message, "Fonduri insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare neașteptată: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Revine la dashboard-ul utilizatorului curent.
        /// </summary>
        /// <param name="sender">Butonul "Înapoi".</param>
        /// <param name="e">Datele evenimentului declanșat.</param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new UserDashboardForm(currentUser));
        }
    }
}
