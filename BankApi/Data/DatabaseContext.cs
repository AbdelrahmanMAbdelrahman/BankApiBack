using BankApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BankApi.Data
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options):DbContext(options)
    {
       public DbSet<Employee>Employees { get; set; } 
       public DbSet<Party> Parties { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Disbursement> Disbursements { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<UploadedImage> Images { get; set; }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
