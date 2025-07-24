using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.Common;

namespace ZhiHu.Core.QuestionAggregate.Entites
{
    public class AnswerLike : BaseAuditEntity
    {
        public int AnswerId { get; set; }
        public Answer Answer { get; set; } = null!;

        public int UserId { get; set; }

        public bool IsLike { get; set; }
    }
}
