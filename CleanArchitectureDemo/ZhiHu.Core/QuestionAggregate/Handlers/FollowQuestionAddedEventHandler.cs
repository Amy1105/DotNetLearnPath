using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.AppUserAggregate.Events;
using ZhiHu.Core.QuestionAggregate.Entites;
using ZhiHu.SharedKernel.Repositoy;

namespace ZhiHu.Core.QuestionAggregate.Handlers
{
    internal class FollowQuestionAddedEventHandler(IRepository<Question> questions)
    : INotificationHandler<FollowQuestionAddedEvent>
    {
        public async Task Handle(FollowQuestionAddedEvent notification, CancellationToken cancellationToken)
        {
            var question = await questions.GetByIdAsync(notification.FollowQuestion.QuestionId, cancellationToken);
            if (question == null) return;

            question.FollowerCount += 1;

            await questions.SaveChangesAsync(cancellationToken);
        }
    }
}
