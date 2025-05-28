using System;
using System.Linq;
using System.Windows.Forms;
using BankApp.Data;
using BankApp.Models;
using BankApp.Validation;

namespace BankApp.Administrator
{
    public partial class ResetPasswordForm : Form
    {
        public ResetPasswordForm()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string username = txtUsernameConfirm.Text.Trim();
            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirm.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(newPass) ||
                string.IsNullOrWhiteSpace(confirmPass))
            {
                MessageBox.Show("Completează toate câmpurile.");
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Parolele nu coincid.");
                return;
            }

            var validator = new PasswordValidator(new StrongPasswordValidation());
            if (!validator.Validate(newPass))
            {
                MessageBox.Show("Parola trebuie să aibă minim 6 caractere și cel puțin o cifră.");
                return;
            }

            using (var context = new AppDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    MessageBox.Show("Utilizatorul nu a fost găsit.");
                    return;
                }

                user.Password = newPass;
                context.SaveChanges();

                MessageBox.Show($"Parola pentru utilizatorul {user.Username} a fost resetată cu succes.");
            }

            AplicatieBancara.SetNewForm(new AdminDashboardForm(AplicatieBancara.currentUser));
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new AdminDashboardForm(AplicatieBancara.currentUser));
        }
    }
}
