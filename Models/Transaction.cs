using System;
using System.ComponentModel.DataAnnotations;

namespace BankApp.Models
{

    /// <summary>
    /// Reprezintă o tranzacție între doi utilizatori (transfer de fonduri).
    /// </summary>
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
