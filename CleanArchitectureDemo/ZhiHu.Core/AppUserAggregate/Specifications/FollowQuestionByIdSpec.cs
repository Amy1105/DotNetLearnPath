using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.AppUserAggregate.Entites;
using ZhiHu.SharedKernel.Specification;

namespace ZhiHu.Core.AppUserAggregate.Specifications
{
    public class FollowQuestionByIdSpec : Specification<AppUser>
    {
        public FollowQuestionByIdSpec(int userId, int questionId)
        {
            FilterCondition = user => user.Id.Equals(userId);

            AddInclude(user => user.FollowQuestions.Where(fq => fq.QuestionId.Equals(questionId)));
        }
    }
}
