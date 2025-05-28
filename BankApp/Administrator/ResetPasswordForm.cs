using System;
using System.Linq;
using System.Windows.Forms;
using BankApp.Data;
using BankApp.Exceptions;
using BankApp.Validation;

namespace BankApp.Administrator
{
    /// <summary>
    /// Formular pentru resetarea parolei unui utilizator de către administrator.
    /// </summary>
    public partial class ResetPasswordForm : Form
    {
        public ResetPasswordForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Confirmă resetarea parolei utilizatorului indicat.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            string username = txtUsernameConfirm.Text.Trim();
            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirm.Text;

            try
            {
                if (string.IsNullOrWhiteSpace(username) ||
                    string.IsNullOrWhiteSpace(newPass) ||
                    string.IsNullOrWhiteSpace(confirmPass))
                    throw new FormValidationException("Completează toate câmpurile.");

                if (newPass != confirmPass)
                    throw new FormValidationException("Parolele nu coincid.");

                // Validare parolă
                var validator = new PasswordValidator(new StrongPasswordValidation());
                if (!validator.Validate(newPass))
                    throw new PasswordValidationException("Parola trebuie să aibă minim 8 caractere, o literă mare, una mică și o cifră.");

                using (var context = new BankApp.Data.Data.AppDbContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Username == username);
                    if (user == null)
                        throw new UserNotFoundException("Utilizatorul nu a fost găsit.");

                    user.Password = newPass;
                    context.SaveChanges();

                    MessageBox.Show($"Parola pentru utilizatorul {user.Username} a fost resetată cu succes.");
                }

                AplicatieBancara.SetNewForm(new AdminDashboardForm(AplicatieBancara.currentUser));
            }
            catch (FormValidationException ex)
            {
                MessageBox.Show($"Eroare formular: {ex.Message}");
            }
            catch (PasswordValidationException ex)
            {
                MessageBox.Show($"Eroare parolă: {ex.Message}");
            }
            catch (UserNotFoundException ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare necunoscută: {ex.Message}");
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
