using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.SharedKernel.Messaging;
using ZhiHu.SharedKernel.Result;
using ZhiHu.UseCases.Common.Attributes;
using ZhiHu.UseCases.Common.Interfaces;

namespace ZhiHu.UseCases.AppUsers.Queries
{
    [Authorize]
    public record GetUserInfoQuery(int Id) : IQuery<Result<UserInfoDto>>;

    public class GetUserInfoQueryHandler(IDataQueryService queryService)
        : IQueryHandler<GetUserInfoQuery, Result<UserInfoDto>>
    {
        public async Task<Result<UserInfoDto>> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var queryable = queryService.AppUsers
                .Where(u => u.Id == request.Id)
                .Select(u => new UserInfoDto
                {
                    Id = u.Id,
                    Nickname = u.Nickname,
                    Avatar = u.Avatar,
                    Bio = u.Bio,
                    FolloweesCount = u.Followees.Count,
                    FollowersCount = u.Followers.Count
                });

            var appUserInfo = await queryService.FirstOrDefaultAsync(queryable);

            return appUserInfo is null ? Result.NotFound() : Result.Success(appUserInfo);
        }
    }
}
