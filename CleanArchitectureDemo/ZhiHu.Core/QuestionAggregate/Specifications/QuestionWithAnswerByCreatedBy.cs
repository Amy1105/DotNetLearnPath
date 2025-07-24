using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.QuestionAggregate.Entites;
using ZhiHu.SharedKernel.Specification;

namespace ZhiHu.Core.QuestionAggregate.Specifications
{
    public class QuestionWithAnswerByCreatedBy : Specification<Question>
    {
        public QuestionWithAnswerByCreatedBy(int userId, int questionId)
        {
            FilterCondition = q => q.Id == questionId && q.CreatedBy == userId;
            AddInclude(q => q.Answers.Take(1));
        }
    }
}
