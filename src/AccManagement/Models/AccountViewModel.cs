using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccManagement.Models
{
    public class AccountViewModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string AccountNumber { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}