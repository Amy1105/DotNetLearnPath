using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.QuestionAggregate.Entites;
using ZhiHu.SharedKernel.Specification;

namespace ZhiHu.Core.QuestionAggregate.Specifications
{
    public class QuestionByCreatedBy : Specification<Question>
    {
        public QuestionByCreatedBy(int userId, int questionId)
        {
            FilterCondition = q => q.Id == questionId && q.CreatedBy == userId;
        }
    }
}
