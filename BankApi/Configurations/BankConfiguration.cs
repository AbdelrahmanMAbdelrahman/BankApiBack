using BankApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApi.Configurations
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(b => b.ID);
            builder.Property(b => b.EMail).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Phone).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Address).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Fax).IsRequired().HasMaxLength(50);
            builder.Property(b => b.CurrencyID).IsRequired();
            builder.Property(b => b.LookupCode).IsRequired().HasMaxLength(50);
            builder.Property(b => b.SwiftCode).IsRequired().HasMaxLength(50);
            builder.HasOne(b => b.Currency)
            .WithMany(c => c.Banks);
        }
    }
}
