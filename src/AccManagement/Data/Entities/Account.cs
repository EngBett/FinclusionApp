using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccManagement.Data.Entities
{
    public class Account
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string AccountNumber { get; set; }
        public bool Active { get; set; } = true;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public DateTime UpdatedAt { get; set; }=DateTime.Now;
        public string CheckSum { get; set; }

        public override string ToString()
        {
            return $"{Id}{UserId}{AccountNumber}{Balance}{CreatedAt}{UpdatedAt}";
        }
    }
}