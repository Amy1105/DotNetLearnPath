using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.AppUserAggregate.Entites;
using ZhiHu.Core.AppUserAggregate.Specifications;
using ZhiHu.SharedKernel.Messaging;
using ZhiHu.SharedKernel.Repositoy;
using ZhiHu.SharedKernel.Result;
using ZhiHu.UseCases.Common.Attributes;
using ZhiHu.UseCases.Common.Interfaces;

namespace ZhiHu.UseCases.AppUsers.Commands
{
    [Authorize]
    public record DeleteFollowQuestionCommand(int QuestionId) : ICommand<IResult>;

    public class DeleteFollowQuestionCommandHanlder(
        IRepository<AppUser> userRepo,
        IUser user) : ICommandHandler<DeleteFollowQuestionCommand, IResult>
    {
        public async Task<IResult> Handle(DeleteFollowQuestionCommand request, CancellationToken cancellationToken)
        {
            var spec = new FollowQuestionByIdSpec(user.Id!.Value, request.QuestionId);
            var appuser = await userRepo.GetSingleOrDefaultAsync(spec, cancellationToken);
            if (appuser == null) return Result.NotFound("用户不存在");

            appuser.RemoveFollowQuestion(request.QuestionId);

            await userRepo.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
