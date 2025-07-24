using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.AppUserAggregate.Entites;
using ZhiHu.SharedKernel.Domain;

namespace ZhiHu.Core.AppUserAggregate.Events
{
    internal class FollowQuestionAddedEvent(FollowQuestion followQuestion) : BaseEvent
    {
        public FollowQuestion FollowQuestion { get; } = followQuestion;
    }
}
