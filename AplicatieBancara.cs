using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BankApp
{
    public static class AplicatieBancara
    {

        public static List<LoginForm.User> users = new List<LoginForm.User>
        {
            new LoginForm.User { Username = "admin", Password = "admin123", FullName = "Admin Principal", Role = "Admin", IBAN = "RO00ADMIN0000000001", Balance = 0 },
            new LoginForm.User { Username = "user1", Password = "user123", FullName = "Ion Popescu", Role = "User", IBAN = "RO49AAAA1B31007593840000", Balance = 1850.50M },
            new LoginForm.User { Username = "user2", Password = "user123", FullName = "Maria Ionescu", Role = "User", IBAN = "RO59AAAA1B31007593840001", Balance = 500.00M }
        };
        public static List<Transaction> transactionHistory = new List<Transaction>();

        public static LoginForm.User currentUser;

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
