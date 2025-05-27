using BankApp.Models;
using System.Windows.Forms;

namespace BankApp
{
    public static class AplicatieBancara
    {
        // Eliminat codul vechi de simulare
        // public static List<LoginForm.User> users = ...

        // Dacă vrei să păstrezi tranzacțiile temporar, o listă locală (opțional)
        // public static List<Transaction> transactionHistory = new List<Transaction>();

        public static User currentUser;  // Acum se folosește modelul real User

        private static Form _currentForm;

        public static Form GetCurrentForm()
        {
            _currentForm = new LoginForm();
            return _currentForm;
        }

        private static void DeleteAllControls()
        {
            while (_currentForm.Controls.Count > 0)
            {
                _currentForm.Controls[0].Dispose();
            }
        }

        private static void AddAllControls(Form sourceForm)
        {
            while (sourceForm.Controls.Count != 0)
            {
                Control c = sourceForm.Controls[0];
                sourceForm.Controls.Remove(c);
                _currentForm.Controls.Add(c);
            }
        }

        public static void SetNewForm(Form form)
        {
            DeleteAllControls();
            AddAllControls(form);
            form.Dispose();
        }
    }
}
