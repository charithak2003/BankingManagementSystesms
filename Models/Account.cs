using System.ComponentModel.DataAnnotations;

namespace BankingSystems.Models
{
    public class Account
    {

        [Key]
        [Required]
        public int Id { get; set; }
        public int AccountNo { get; set; }
        public string IFSCCode { get; set; }
        public float Balance { get; set; }
        public int NoOfTransactions { get; set; }
        public string Name { get; set; }

    }
}
