namespace BankingSystems.Models
{
    public class AddAccountViewModel
    {
        public int AccountNo { get; set; }
        public string IFSCCode { get; set; }
        public float Balance { get; set; }
        public int NoOfTransactions { get; set; }
        public string Name { get; set; }
    }
}
