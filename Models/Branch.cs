using System.ComponentModel.DataAnnotations;

namespace BankingSystems.Models
{
    public class Branch
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public int NoOfEmps { get; set; }
    }
}
