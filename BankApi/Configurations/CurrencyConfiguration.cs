using BankApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApi.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(c=>c.ID);
            builder.Property(c=>c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c=>c.Code).IsRequired().HasMaxLength(10);
        }
    }
}
