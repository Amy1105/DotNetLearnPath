using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.AppUserAggregate.Entites;
using ZhiHu.SharedKernel.Messaging;
using ZhiHu.SharedKernel.Repositoy;
using ZhiHu.SharedKernel.Result;

namespace ZhiHu.UseCases.AppUsers.Commands
{
    public record CreateAppUserCommand(int UserId) : ICommand<Result<CreatedAppUserDto>>;

    public class CreateAppUserCommandHandler(
        IRepository<AppUser> userRepo,
        IMapper mapper) : ICommandHandler<CreateAppUserCommand, Result<CreatedAppUserDto>>
    {
        public async Task<Result<CreatedAppUserDto>> Handle(CreateAppUserCommand command,
            CancellationToken cancellationToken)
        {
            var user = userRepo.Add(new AppUser(command.UserId)
            {
                Nickname = $"新用户{command.UserId}"
            });

            await userRepo.SaveChangesAsync(cancellationToken);

            return Result.Success(mapper.Map<CreatedAppUserDto>(user));
        }
    }
}
