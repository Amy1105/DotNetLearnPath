using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.AppUserAggregate.Entites;
using ZhiHu.SharedKernel.Result;

namespace ZhiHu.Core.Interfaces
{
    public interface IFollowQuestionService
    {
        Task<IResult> FollowAsync(AppUser appuser, int questionId, CancellationToken cancellationToken);
    }
}
