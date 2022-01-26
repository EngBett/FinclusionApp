using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccManagement.Data.Entities
{
    public class AccountTransaction
    {
        public enum TransactionType
        {
            Purchase,
            Deposit,
            Withdrawal,
            Refund
        }
    
        public enum TransactionStatus
        {
            Pending,
            Cancelled,
            Completed,
            Reversed
        }
        
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string AccountId { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }
        public TransactionStatus TranStatus { get; set; } = TransactionStatus.Pending;
        public TransactionType TranType { get; set; }
        public DateTime InitiatedAt { get; set; }=DateTime.Now;
        public DateTime? CompletedAt { get; set; }
        public string Checksum { get; set; }
        
        public Account Account { get; set; }
    }

    
}