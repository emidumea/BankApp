using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using BankApp.Data;

namespace BankApp
{
    public partial class TransactionHistoryForm : Form
    {
        private User currentUser;

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

        private void btnBack_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new UserDashboardForm(currentUser));
        }
    }
}
