using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZhiHu.Infrastructure.Data.Interceptors;
using ZhiHu.Infrastructure.Data.Repositories;
using ZhiHu.Infrastructure.Data;
using ZhiHu.Infrastructure.Identity;
using ZhiHu.SharedKernel.Repositoy;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ZhiHu.UseCases.Common.Interfaces;

namespace ZhiHu.Infrastructure
{
    /// <summary>
    /// Infrastructure 类库（基础设施层） 主要负责处理与系统外部环境的交互，
    /// 为核心业务逻辑（领域层、用例层）提供技术支持，同时隔离外部依赖对核心层的影响
    /// 
    /// **隔离外部依赖，提供技术实现**
    /// 
    /// Data：
    ///     与EFcore 对接
    ///         efcore实体配置、efcoreInterceptors拦截器允许截获、修改和/或抑制 EF Core 操作、公共仓储、规范查询模式、
    ///     与IdentityServer4对接
    /// 
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            ConfigureEfCore(services, configuration);

            ConfigureIdentity(services, configuration);

            return services;
        }

        private static void ConfigureEfCore(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddScoped<ISaveChangesInterceptor, AuditEntityInterceptor>();
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<AppDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

                options.UseSqlite(connectionString);
            });

            services.AddScoped<AppDbInitializer>();

            services.AddScoped(typeof(IReadRepository<>), typeof(EfReadRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddScoped<IDataQueryService, DataQueryService>();
        }

        private static void ConfigureIdentity(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddIdentityCore<IdentityUser>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequiredLength = 8;
                })
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<IdentityService>();

            // 从配置文件中读取JwtSettings，并注入到容器中
            var configurationSection = configuration.GetSection("JwtSettings");
            var jwtSettings = configurationSection.Get<JwtSettings>();
            if (jwtSettings is null) throw new NullReferenceException(nameof(jwtSettings));
            services.Configure<JwtSettings>(configurationSection);

            ConfigureAuthentication(services, jwtSettings);
        }

        public static void ConfigureAuthentication(IServiceCollection services, JwtSettings jwtSettings)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSettings.Secret)
                        )
                    };
                });
        }
    }
}
