using System.ComponentModel.DataAnnotations;

namespace BankingSystems.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int Ssn { get; set; }
        public DateOnly Bdate { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public float Salary { get; set; }
    }
}
