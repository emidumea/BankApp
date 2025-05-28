using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
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
