using System;
using System.Linq;
using System.Windows.Forms;
using BankApp.Models;
using BankApp.Data;
using BankApp.Validation;

namespace BankApp.Administrator
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();

            cmbRole.Items.Add("User");
            cmbRole.Items.Add("Admin");
            cmbRole.SelectedIndex = 0;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string iban = txtIBAN.Text.Trim();
            string role = cmbRole.SelectedItem.ToString();
            string balanceText = txtBalance.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)
                || string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(iban)
                || string.IsNullOrWhiteSpace(balanceText))
            {
                MessageBox.Show("Completează toate câmpurile.");
                return;
            }

            // Strategy Pattern – validare parola
            var validator = new PasswordValidator(new StrongPasswordValidation());
            if (!validator.Validate(password))
            {
                MessageBox.Show("Parola trebuie să aibă minim 8 caractere, o literă mare, o literă mică și o cifră.");
                return;
            }

            if (!decimal.TryParse(balanceText, out decimal balance) || balance < 0)
            {
                MessageBox.Show("Soldul trebuie să fie un număr pozitiv.");
                return;
            }

            using (var context = new AppDbContext())
            {
                bool exists = context.Users.Any(u => u.Username == username || u.IBAN == iban);
                if (exists)
                {
                    MessageBox.Show("Există deja un utilizator cu acest username sau IBAN.");
                    return;
                }

                var newUser = new User
                {
                    Username = username,
                    Password = password,
                    FullName = fullName,
                    IBAN = iban,
                    Balance = balance,
                    Role = role
                };

                context.Users.Add(newUser);
                context.SaveChanges();
            }

            MessageBox.Show("Utilizatorul a fost creat cu succes.");
            AplicatieBancara.SetNewForm(new AdminDashboardForm(AplicatieBancara.currentUser));
        }
    

        private void btnBack_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new AdminDashboardForm(AplicatieBancara.currentUser));
        }
    }
}
