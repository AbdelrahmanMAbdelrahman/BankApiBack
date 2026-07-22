using BankApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApi.Configurations
{
    public class PartyConfiguration : IEntityTypeConfiguration<Party>
    {
        public void Configure(EntityTypeBuilder<Party> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p=>p.PartyCode).IsRequired().HasMaxLength(50);
            builder.Property(p=>p.PartyGroupName).IsRequired().HasMaxLength(100);
            builder.Property(p=>p.InternalCode).IsRequired().HasMaxLength(50);
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p=>p.NativeName).IsRequired().HasMaxLength(100);
           
        }
    }
}
