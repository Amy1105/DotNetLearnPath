using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ZhiHu.UseCases.Common.Behaviors;

namespace ZhiHu.UseCases
{
    /// <summary>
    /// 用例层（Use Cases）：包含应用程序特有的业务规则，定义系统 “能做什么”，负责协调实体完成具体业务流程。
    /// 
    /// UseCases 层属于应用层，其核心职责是：
    /// 1.定义系统的 “用例”（即用户 / 外部系统与系统的交互场景，如 “下单”“支付”）。
    /// 2.协调实体、领域服务等领域层组件，按步骤完成用例逻辑（如 “下单” 需校验库存、创建订单实体、扣减库存等）。
    /// 3.不包含核心业务规则，仅负责 “流程编排”，依赖领域层（实体、领域服务），但不被领域层依赖。
    /// 
    /// AppUser、Questions 将DTO参数映射，调用Core中的领域服务
    /// 
    /// Common 定义了公共服务：授权，鉴权验证，异常处理，通用查询服务等
    /// 
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddUseCaseServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
           
            //automapper15
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.AddAutoMapper(cfg => {
                cfg.AddMaps(assemblies);               
            });           

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(Core.DependencyInjection))!);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });

            return services;
        }
    }
}
