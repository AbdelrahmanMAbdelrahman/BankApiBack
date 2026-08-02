using BankApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApi.Configurations
{
    public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder.HasKey(f => f.ID);
            builder.Property(f => f.AccountNumber).IsRequired().HasMaxLength(20);
            builder.Property(f=>f.FacilityType).IsRequired();
            builder.HasOne(f => f.Currency)
                .WithMany(c => c.Facilities);
            builder.HasOne(f => f.Party)
                .WithMany(p => p.Facilities);
                
        }
    }
}
