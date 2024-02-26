using System.ComponentModel.DataAnnotations;

namespace BankingSystems.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public long AadhaarNo { get; set; }

    }
}
