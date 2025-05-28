using System;
using System.Linq;
using System.Windows.Forms;
using BankApp.Data;
using SQLitePCL;

namespace BankApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Batteries_V2.Init();

            using (var context = new BankApp.Data.Data.AppDbContext())
            {
                context.Database.EnsureCreated();

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User
                        {
                            Username = "admin",
                            Password = "admin123",
                            FullName = "Admin Principal",
                            Role = "Admin",
                            IBAN = "RO00ADMIN0000000001",
                            Balance = 0
                        },
                        new User
                        {
                            Username = "user1",
                            Password = "user123",
                            FullName = "Ion Popescu",
                            Role = "User",
                            IBAN = "RO49AAAA1B31007593840000",
                            Balance = 1850.50M
                        },
                        new User
                        {
                            Username = "user2",
                            Password = "pass456",
                            FullName = "Maria Ionescu",
                            Role = "User",
                            IBAN = "RO59BBBB2B31007593840011",
                            Balance = 3000.00M
                        }
                    );
                    context.SaveChanges();
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(AplicatieBancara.GetCurrentForm());
        }

    }
}
