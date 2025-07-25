using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.AppUserAggregate.Entites;
using ZhiHu.Core.ProductClassAggregate.Entites;
using ZhiHu.Core.QuestionAggregate.Entites;

namespace ZhiHu.UseCases.Common.Interfaces
{
    public interface IDataQueryService
    {
        public IQueryable<AppUser> AppUsers { get; }

        public IQueryable<FollowQuestion> FollowQuestions { get; }

        public IQueryable<FollowUser> FollowUsers { get; }

        public IQueryable<Question> Questions { get; }

        public IQueryable<Answer> Answers { get; }

        public IQueryable<AnswerLike> AnswerLikes { get; }

        Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> queryable) where T : class;

        Task<IList<T>> ToListAsync<T>(IQueryable<T> queryable) where T : class;

        Task<bool> AnyAsync<T>(IQueryable<T> queryable) where T : class;

        public IQueryable<ProductClass> ProductClasses { get; } 
    }
}
