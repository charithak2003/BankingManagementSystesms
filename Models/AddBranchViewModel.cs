using System.ComponentModel.DataAnnotations;

namespace BankingSystems.Models
{
    public class AddBranchViewModel
    {
        [MaxLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public int NoOfEmps { get; set; }
    }
}
