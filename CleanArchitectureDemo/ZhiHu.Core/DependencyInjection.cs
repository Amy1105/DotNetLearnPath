using Microsoft.Extensions.DependencyInjection;
using ZhiHu.Core.Interfaces;
using ZhiHu.Core.Services;

namespace ZhiHu.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IFollowQuestionService, FollowQuestionService>();
            return services;
        }
    }
}
