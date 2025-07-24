using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.AppUserAggregate.Entites;
using ZhiHu.Core.QuestionAggregate.Entites;
using ZhiHu.UseCases.Common.Interfaces;

namespace ZhiHu.Infrastructure.Data
{
    public class DataQueryService(AppDbContext dbContext) : IDataQueryService
    {
        public IQueryable<AppUser> AppUsers => dbContext.AppUsers;

        public IQueryable<FollowQuestion> FollowQuestions => dbContext.FollowQuestions;

        public IQueryable<FollowUser> FollowUsers => dbContext.FollowUsers;

        public IQueryable<Question> Questions => dbContext.Questions;

        public IQueryable<Answer> Answers => dbContext.Answers;

        public IQueryable<AnswerLike> AnswerLikes => dbContext.AnswerLikes;

        public async Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> queryable) where T : class
        {
            return await queryable.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IList<T>> ToListAsync<T>(IQueryable<T> queryable) where T : class
        {
            return await queryable.AsNoTracking().ToListAsync();
        }

        public async Task<bool> AnyAsync<T>(IQueryable<T> queryable) where T : class
        {
            return await queryable.AsNoTracking().AnyAsync();
        }
    }
}
