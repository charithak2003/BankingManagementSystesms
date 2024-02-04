using BankingSystems.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingSystems.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Loans> Loans { get; set; }
    }
}
