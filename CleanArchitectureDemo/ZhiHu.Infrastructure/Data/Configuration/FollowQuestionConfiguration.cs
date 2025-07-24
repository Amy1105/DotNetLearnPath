using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.AppUserAggregate.Entites;

namespace ZhiHu.Infrastructure.Data.Configuration
{
    public class FollowQuestionConfiguration : IEntityTypeConfiguration<FollowQuestion>
    {
        public void Configure(EntityTypeBuilder<FollowQuestion> builder)
        {
            // 设置组合唯一约束
            builder
                .HasIndex(fq => new { fq.UserId, fq.QuestionId })
                .IsUnique();

            // 设置用户与关注问题列表之间的一对多关系
            builder
                .HasOne(fq => fq.AppUser)
                .WithMany(u => u.FollowQuestions)
                .HasForeignKey(fq => fq.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
