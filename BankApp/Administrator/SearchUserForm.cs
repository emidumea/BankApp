/**************************************************************************
 *                                                                        *
 *  File:        SearchUserForm.cs                                       *
 *  Copyright:   (c) 2025, Dumea Emilian, Oancea Cosmin, Chiriac Gabriel *
 *  E-mail:      emilian.dumea@student.tuiasi.ro                         *
 *  Website:     https://github.com/emidumea/BankApp                     *
 *  Description: Permite administratorului să caute utilizatori după     *
 *               username sau IBAN și să vizualizeze rezultatele.        *
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

namespace BankApp.Administrator
{

    /// <summary>
    /// Formular pentru căutarea utilizatorilor după username sau IBAN.
    /// </summary>
    public partial class SearchUserForm : Form
    {
        public SearchUserForm()
        {
            InitializeComponent();

            lvResults.View = View.Details;
            lvResults.FullRowSelect = true;

            // Adaugă capetele de coloană (dacă nu sunt în Designer)
            if (lvResults.Columns.Count == 0)
            {
                lvResults.Columns.Add("Username", 100);
                lvResults.Columns.Add("Nume complet", 150);
                lvResults.Columns.Add("IBAN", 160);
                lvResults.Columns.Add("Sold", 80);
                lvResults.Columns.Add("Rol", 80);
            }
        }

        /// <summary>
        /// Caută utilizatorii după textul introdus și afișează rezultatele.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(search))
            {
                MessageBox.Show("Introdu un username sau un IBAN.");
                return;
            }

            using (var context = new BankApp.Data.Data.AppDbContext())
            {
                var results = context.Users
                    .Where(u => u.Username.ToLower().Contains(search) || u.IBAN.ToLower().Contains(search))
                    .ToList();

                lvResults.Items.Clear();

                if (results.Count == 0)
                {
                    MessageBox.Show("Nu s-a găsit niciun utilizator.");
                    return;
                }

                foreach (var u in results)
                {
                    var item = new ListViewItem(u.Username);
                    item.SubItems.Add(u.FullName);
                    item.SubItems.Add(u.IBAN);
                    item.SubItems.Add(u.Balance.ToString("0.00"));
                    item.SubItems.Add(u.Role);
                    lvResults.Items.Add(item);
                }
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
