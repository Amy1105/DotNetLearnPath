using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.Common;
using ZhiHu.SharedKernel.Domain;

namespace ZhiHu.Core.QuestionAggregate.Entites
{
    public class Question : AuditWithUserEntity, IAggregateRoot
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public int ViewCount { get; private set; }

        public int FollowerCount { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();

        public int AddView()
        {
            ViewCount += 1;
            return ViewCount;
        }

        public int SubView()
        {
            ViewCount -= 1;
            return ViewCount;
        }
    }

}
