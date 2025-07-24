using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.AppUserAggregate.Entites;
using ZhiHu.Core.Interfaces;
using ZhiHu.Core.QuestionAggregate.Entites;
using ZhiHu.SharedKernel.Repositoy;
using ZhiHu.SharedKernel.Result;

namespace ZhiHu.Core.Services
{
    public class FollowQuestionService(IReadRepository<Question> questions) : IFollowQuestionService
    {
        public async Task<IResult> FollowAsync(AppUser appuser, int questionId, CancellationToken cancellationToken)
        {
            var question = await questions.GetByIdAsync(questionId, cancellationToken);
            if (question == null) return Result.NotFound("关注问题不存在");

            var result = appuser.AddFollowQuestion(questionId);
            return Result.From(result);
        }
    }
}
