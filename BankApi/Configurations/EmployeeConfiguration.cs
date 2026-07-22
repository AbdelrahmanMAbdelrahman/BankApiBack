using BankApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApi.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
         builder.HasKey(e => e.Id);
            builder.Property(e => e.Role).IsRequired().HasMaxLength(20);
            builder.Property(e => e.FName).IsRequired().HasMaxLength(20);
            builder.Property(e => e.LName).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Status).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Department).IsRequired().HasMaxLength(20);
            builder.Property(e => e.ReportsTo).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(40);
            builder.Property(e => e.MobilePhone).IsRequired().HasMaxLength(20);
            builder.Property(e => e.OfficePhone).IsRequired().HasMaxLength(20);
            builder.Property(e => e.UserName).HasMaxLength(40);
        }
    }
}
