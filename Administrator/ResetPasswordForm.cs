using System;
using System.Linq;
using System.Windows.Forms;

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

            var user = AplicatieBancara.users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                MessageBox.Show("Utilizatorul nu a fost găsit.");
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Parolele nu coincid.");
                return;
            }

            user.Password = newPass;
            MessageBox.Show($"Parola pentru utilizatorul {user.Username} a fost resetată cu succes.");
            AplicatieBancara.SetNewForm(new AdminDashboardForm(AplicatieBancara.currentUser));
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            AplicatieBancara.SetNewForm(new AdminDashboardForm(AplicatieBancara.currentUser));
        }
    }
}
