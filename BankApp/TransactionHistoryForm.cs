/**************************************************************************
 *                                                                        *
 *  File:        TransactionHistoryForm.cs                               *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Afișează istoricul tranzacțiilor utilizatorului, cu     *
 *               opțiuni de filtrare: toate, trimise, primite.           *
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
using System.Collections.Generic;
using BankApp.Data;

namespace BankApp
{
    /// <summary>
    /// Formular care afișează istoricul tranzacțiilor unui utilizator.
    /// Permite filtrarea tranzacțiilor în funcție de tip: toate, trimise, primite.
    /// </summary>
    public partial class TransactionHistoryForm : Form
    {
        private User currentUser;

        /// <summary>
        /// Inițializează formularul cu utilizatorul conectat și pregătește opțiunile de filtrare.
        /// </summary>
        /// <param name="user">Utilizatorul conectat curent.</param>
        public TransactionHistoryForm(User user)
        {
            InitializeComponent();
            currentUser = user;

            if (cmbFilter.Items.Count == 0)
            {
                cmbFilter.Items.AddRange(new string[] { "Toate", "Trimise", "Primite" });
            }

            cmbFilter.SelectedIndexChanged += (s, e) => LoadTransactions();
            cmbFilter.SelectedIndex = 0;
        }

        /// <summary>
        /// Încarcă și afișează lista tranzacțiilor filtrate în funcție de selecția utilizatorului.
        /// </summary>
        private void LoadTransactions()
        {
            lvTransactions.Items.Clear();

            string userIban = currentUser.IBAN;
            string selectedFilter = cmbFilter.SelectedItem?.ToString();

            using (var context = new BankApp.Data.Data.AppDbContext())
            {
                IEnumerable<Transaction> filtered = context.Transactions.ToList();

                if (selectedFilter == "Trimise")
                {
                    filtered = filtered.Where(t => t.FromUser == userIban);
                }
                else if (selectedFilter == "Primite")
                {
                    filtered = filtered.Where(t => t.ToUser == userIban);
                }
                else // "Toate"
                {
                    filtered = filtered.Where(t => t.FromUser == userIban || t.ToUser == userIban);
                }

                foreach (var tx in filtered.OrderByDescending(t => t.Timestamp))
                {
                    var item = new ListViewItem(tx.FromUser);
                    item.SubItems.Add(tx.ToUser);
                    item.SubItems.Add(tx.Amount.ToString("0.00"));
                    item.SubItems.Add(tx.Timestamp.ToString("g"));
                    lvTransactions.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Revine la dashboard-ul utilizatorului curent.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new UserDashboardForm(currentUser));
        }
    }
}
