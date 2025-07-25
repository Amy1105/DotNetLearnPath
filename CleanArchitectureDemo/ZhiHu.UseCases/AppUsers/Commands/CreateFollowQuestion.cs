﻿using ZhiHu.Core.AppUserAggregate.Entites;
using ZhiHu.Core.AppUserAggregate.Specifications;
using ZhiHu.Core.Interfaces;
using ZhiHu.SharedKernel.Messaging;
using ZhiHu.SharedKernel.Repositoy;
using ZhiHu.SharedKernel.Result;
using ZhiHu.UseCases.Common.Attributes;
using ZhiHu.UseCases.Common.Interfaces;

namespace ZhiHu.UseCases.AppUsers.Commands
{
    [Authorize]
    public record CreateFollowQuestionCommand(int QuestionId) : ICommand<IResult>;

    public class CreateFollowQuestionCommandHanlder(
        IRepository<AppUser> userRepo,
        IFollowQuestionService followQuestionService,
        IUser user) : ICommandHandler<CreateFollowQuestionCommand, IResult>
    {
        public async Task<IResult> Handle(CreateFollowQuestionCommand request, CancellationToken cancellationToken)
        {
            var spec = new FollowQuestionByIdSpec(user.Id.Value, request.QuestionId);
            var appuser = await userRepo.GetSingleOrDefaultAsync(spec, cancellationToken);
            if (appuser == null) return Result.NotFound("用户不存在");

            var result = await followQuestionService.FollowAsync(appuser, request.QuestionId, cancellationToken);
            if (!result.IsSuccess) return result;

            await userRepo.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
