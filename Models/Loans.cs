using System.ComponentModel.DataAnnotations;

namespace BankingSystems.Models
{
    public class Loans
    {
        [Key]
        [Required]
        public string TypeOfLoan { get; set; }
        public int LoanNumber { get; set; }
        public float Interest { get; set; }
        public float AmountTaken { get; set; }
        public float PaidOff { get; set; }
        public string BranchName { get; set; }
    }
}
