using BankApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BankApi.Data
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options):DbContext(options)
    {
       public DbSet<Employee>Employees { get; set; } 
       public DbSet<Party> Parties { get; set; }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
