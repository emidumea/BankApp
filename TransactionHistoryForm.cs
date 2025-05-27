using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace BankApp
{
    public partial class TransactionHistoryForm : Form
    {
        private LoginForm.User currentUser;
        public TransactionHistoryForm(LoginForm.User user)
        {
            InitializeComponent();

            currentUser = user;


            cmbFilter.SelectedIndexChanged += (s, e) => LoadTransactions();
            cmbFilter.SelectedIndex = 0;
        }



        private void LoadTransactions()
        {
            lvTransactions.Items.Clear();

            var userIban = currentUser.IBAN;

            // Obține toate tranzacțiile
            IEnumerable<Transaction> filtered = AplicatieBancara.transactionHistory;

            // Aplică filtrul selectat
            string selectedFilter = cmbFilter.SelectedItem?.ToString();

            if (selectedFilter == "Trimise")
            {
                filtered = filtered.Where(t => t.FromUser == userIban);
            }
            else if (selectedFilter == "Primite")
            {
                filtered = filtered.Where(t => t.ToUser == userIban);
            }
            else
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


        private void btnBack_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new UserDashboardForm(currentUser));
        }
    }
}
