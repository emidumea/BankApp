//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace BankApp
//{
//    public partial class LoginForm : Form
//    {
//        public LoginForm()
//        {
//            InitializeComponent();
//        }

//        private void label1_Click(object sender, EventArgs e) //labelUser
//        {

//        }

//        private void txtUsername_TextChanged(object sender, EventArgs e) //txtUsername
//        {

//        }


//        private void btnLogin_Click(object sender, EventArgs e) //btnLogin
//        {

//        }

//        private void labelPassword_Click(object sender, EventArgs e) //labelPassword
//        {

//        }

//        private void txtPassword_TextChanged(object sender, EventArgs e) //txtPassword
//        {

//        }
//    }
//}
using BankApp.Administrator;
using System;
using System.Collections.Generic;
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

        // Clasa User simplă pentru test
        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string FullName { get; set; }
            public string Role { get; set; } // "User" sau "Admin"
            public string IBAN { get; set; }
            public decimal Balance { get; set; }
        }

        // Simulăm o "bază de date"
        //private List<User> users = new List<User>
        //{
        //    new User { Username = "admin", Password = "admin123", FullName = "Admin Principal", Role = "Admin", IBAN = "RO00ADMIN0000000001", Balance = 0 },
        //    new User { Username = "user1", Password = "user123", FullName = "Ion Popescu", Role = "User", IBAN = "RO49AAAA1B31007593840000", Balance = 1850.50M },
        //    new User { Username = "user2", Password = "user2", FullName = "Marius Tamas", Role = "User", IBAN = "RO49AAAA1B31007593840075", Balance = 1600.50M }
        //};



        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            var user = AplicatieBancara.users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                MessageBox.Show("Utilizator sau parolă incorecte.");
                return;
            }

            AplicatieBancara.currentUser = user; 

            MessageBox.Show($"Autentificare reușită ca {user.Role}!");

            if (user.Role == "Admin")
            {
                AplicatieBancara.currentUser = user;
                AplicatieBancara.SetNewForm(new AdminDashboardForm(user));
            }
            else
            {
                AplicatieBancara.SetNewForm(new UserDashboardForm(user));
            }
        }

    }
}
