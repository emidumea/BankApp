using System;
using System.Linq;
using System.Windows.Forms;
using BankApp.Models;
using BankApp.Data;
using BankApp.Validation;

namespace BankApp
{
    public partial class SettingsForm : Form
    {
        private User currentUser;

        public SettingsForm(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string current = txtCurrentPass.Text;
            string newPass = txtNewPass.Text;
            string confirm = txtConfirmPass.Text;

            if (string.IsNullOrWhiteSpace(current) || string.IsNullOrWhiteSpace(newPass) || string.IsNullOrWhiteSpace(confirm))
            {
                MessageBox.Show("Completează toate câmpurile.");
                return;
            }

            if (current != currentUser.Password)
            {
                MessageBox.Show("Parola actuală este incorectă.");
                return;
            }

            if (newPass != confirm)
            {
                MessageBox.Show("Parola nouă și confirmarea nu coincid.");
                return;
            }

            // Strategy Pattern – validare parola
            var validator = new PasswordValidator(new StrongPasswordValidation());
            if (!validator.Validate(newPass))
            {
                MessageBox.Show("Parola nouă trebuie să aibă minim 8 caractere, o literă mare, o literă mică și o cifră.");
                return;
            }

            using (var context = new AppDbContext())
            {
                var userInDb = context.Users.FirstOrDefault(u => u.Id == currentUser.Id);

                if (userInDb == null)
                {
                    MessageBox.Show("Eroare: utilizatorul nu a fost găsit în baza de date.");
                    return;
                }

                userInDb.Password = newPass;
                context.SaveChanges();

                currentUser.Password = newPass;
            }

            MessageBox.Show("Parola a fost schimbată cu succes!");
            AplicatieBancara.SetNewForm(new UserDashboardForm(currentUser));
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new UserDashboardForm(currentUser));
        }
    }
}
