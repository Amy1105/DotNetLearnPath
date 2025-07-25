using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZhiHu.Core.Data;
using ZhiHu.Core.ProductClassAggregate.Entites;

namespace ZhiHu.Infrastructure.Data.Configuration
{
    public class ProductClassConfiguration : IEntityTypeConfiguration<ProductClass>
    {
        public void Configure(EntityTypeBuilder<ProductClass> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(DataSchemaConstants.DefaultMaxLength100)
                .IsRequired();

            builder.Property(p => p.Code)
                .HasMaxLength(DataSchemaConstants.DefaultMaxLength100)
                .IsRequired();

            builder.Property(p => p.Remark)            
            .HasMaxLength(DataSchemaConstants.DefaultMaxLength500);
        }
    }
}
