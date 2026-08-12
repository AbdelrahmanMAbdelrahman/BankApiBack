using BankApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApi.Configurations
{
    public class DisbursementConfiguration : IEntityTypeConfiguration<Disbursement>
    {
        public void Configure(EntityTypeBuilder<Disbursement> builder)
        {
            builder.HasKey(d => d.ID);
            builder.Property(d => d.Amount).IsRequired();
            builder.Property(d=>d.DisbursementMethod).IsRequired();
            builder.Property(d=>d.DisbursementDate).IsRequired();
            builder.Property(d => d.DisbursementDate).IsRequired();
            builder.Property(d => d.ContractID).IsRequired();
            builder.Property(d => d.FacilityID).IsRequired();
            builder.HasOne(d => d.Facility).WithOne(f => f.Disbursement);
            builder.HasOne(d => d.Contract).WithOne(f => f.Disbursement);
            
             
        }
    }
}
