using System.ComponentModel.DataAnnotations;

namespace BankApp.Models
{
    /// <summary>
    /// Reprezintă un utilizator al aplicației bancare (client sau administrator).
    /// </summary>
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string FullName { get; set; }
        public string Role { get; set; }
        public string IBAN { get; set; }
        public decimal Balance { get; set; }
    }
}
