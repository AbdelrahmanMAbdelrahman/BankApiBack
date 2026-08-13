using BankApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApi.Configurations
{
    public class UploadedFileConfiguration : IEntityTypeConfiguration<UploadedImage>
    {
        public void Configure(EntityTypeBuilder<UploadedImage> builder)
        {
            builder.HasKey(f => f.ID);
            builder.Property(f => f.ContentType).IsRequired();
            builder.Property(f => f.StoredFileName).IsRequired();
            builder.Property(f => f.Extension).IsRequired();
        }
    }
}
