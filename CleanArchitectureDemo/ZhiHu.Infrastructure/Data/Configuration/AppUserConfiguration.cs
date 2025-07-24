using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.AppUserAggregate.Entites;
using ZhiHu.Core.Data;

namespace ZhiHu.Infrastructure.Data.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(p => p.Id)
                .ValueGeneratedNever();

            builder.Property(p => p.Nickname)
                .HasMaxLength(DataSchemaConstants.DefaultAppUserNickNameLength);

            builder.Property(p => p.Bio)
                .HasMaxLength(DataSchemaConstants.DefaultAppUserBioLength);
        }
    }
}
