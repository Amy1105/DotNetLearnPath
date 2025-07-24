using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.Common;

namespace ZhiHu.Core.QuestionAggregate.Entites
{
    public class Answer : AuditWithUserEntity
    {
        private readonly List<AnswerLike> _answerLikes = new();
        public string Content { get; set; } = null!;

        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;

        public int LikeCount { get; private set; }
        public int DislikeCount { get; private set; }

        public IEnumerable<AnswerLike> AnswerLikes => _answerLikes;

        public int AddLike(AnswerLike answerLike)
        {
            if (answerLike.IsLike)
                LikeCount += 1;
            else
                DislikeCount += 1;

            _answerLikes.Add(answerLike);

            return LikeCount;
        }

        public int RemoveLike(AnswerLike answerLike)
        {
            if (answerLike.IsLike)
                LikeCount += 1;
            else
                DislikeCount += 1;

            _answerLikes.Remove(answerLike);

            return LikeCount;
        }
    }
}
