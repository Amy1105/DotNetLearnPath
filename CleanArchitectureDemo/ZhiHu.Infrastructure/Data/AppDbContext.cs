using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.AppUserAggregate.Entites;
using ZhiHu.Core.QuestionAggregate.Entites;
using ZhiHu.Core.ProductClassAggregate.Entites;

namespace ZhiHu.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityUserContext<IdentityUser, int>(options)
    {
        public DbSet<Question> Questions => Set<Question>();

        public DbSet<Answer> Answers => Set<Answer>();

        public DbSet<AnswerLike> AnswerLikes => Set<AnswerLike>();

        public DbSet<AppUser> AppUsers => Set<AppUser>();

        public DbSet<FollowUser> FollowUsers => Set<FollowUser>();

        public DbSet<FollowQuestion> FollowQuestions => Set<FollowQuestion>();

        public DbSet<ProductClass> ProductClasses => Set<ProductClass>();

        public DbSet<ProductClassDetail> ProductClassesDetail => Set<ProductClassDetail>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
