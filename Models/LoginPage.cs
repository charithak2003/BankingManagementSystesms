using System.ComponentModel.DataAnnotations;

namespace BankingSystems.Models
{
    public class LoginPage
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; }
    }
}
