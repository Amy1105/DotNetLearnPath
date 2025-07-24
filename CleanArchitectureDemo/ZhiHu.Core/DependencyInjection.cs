using Microsoft.Extensions.DependencyInjection;
using ZhiHu.Core.Interfaces;
using ZhiHu.Core.Services;

namespace ZhiHu.Core
{

    /// <summary>
    /// AppUserAggregate 、QuestionAggregate 领域
    ///      Entites领域实体
    ///      领域事件
    ///      领域规范
    /// Services  领域服务：可以跨领域实体
    /// 
    /// Common 聚合根
    /// 
    /// Data 值对象
    /// 
    /// 
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IFollowQuestionService, FollowQuestionService>();
            return services;
        }
    }
}
