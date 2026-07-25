using BankApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApi.Configurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ISLetter).IsRequired();
            builder.Property(c => c.StartDate).IsRequired();
            builder.Property(c => c.ContractNumber).IsRequired();
            builder.Property(c => c.ContractType).IsRequired();
            builder.Property(c => c.EndDate).IsRequired();
            builder.HasOne(c => c.Party).WithMany(P => P.Contracts);

        }
    }
}
