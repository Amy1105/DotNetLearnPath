using MediatR;
using System.Reflection;
using ZhiHu.UseCases.Common.Attributes;
using ZhiHu.UseCases.Common.Exceptions;
using ZhiHu.UseCases.Common.Interfaces;

namespace ZhiHu.UseCases.Common.Behaviors
{
    public class AuthorizationBehavior<TRequest, TResponse>(IUser user) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

            if (authorizeAttributes.Any())
                if (user.Id is null)
                    throw new ForbiddenException();

            // 其它授权逻辑

            return await next();
        }
    }
}
