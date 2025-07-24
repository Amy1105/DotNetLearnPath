using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.Data;
using ZhiHu.Core.QuestionAggregate.Entites;

namespace ZhiHu.Infrastructure.Data.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(p => p.Title)
                .HasMaxLength(DataSchemaConstants.DefaultQuestionTitleLength)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnType("text")
                .HasMaxLength(DataSchemaConstants.DefaultDescriptionTitleLength);
        }
    }
}
