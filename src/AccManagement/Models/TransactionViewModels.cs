using System.ComponentModel.DataAnnotations;

namespace AccManagement.Models
{
    public class TransactionViewModels
    {
        
    }

    public class DepositViewModel
    {
        [Required]
        public decimal Amount { get; set; }
        public string Narration { get; set; }
    }

    public class WithdrawalViewModel
    {
        public decimal Amount { get; set; }
        public string Narration { get; set; }
    }
}