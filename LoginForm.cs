using BankApp.Administrator;
using BankApp.Data;
using BankApp.Models;
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            using (var context = new AppDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user == null)
                {
                    MessageBox.Show("Utilizator sau parolă incorecte.");
                    return;
                }

                AplicatieBancara.currentUser = user;
                MessageBox.Show($"Autentificare reușită ca {user.Role}!");

                if (user.Role == "Admin")
                {
                    AplicatieBancara.SetNewForm(new AdminDashboardForm(user));
                }
                else
                {
                    AplicatieBancara.SetNewForm(new UserDashboardForm(user));
                }
            }
        }
    }
}
