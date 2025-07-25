using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.UseCases;
using ZhiHu.Core;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ZhiHu.Infrastructure.Data;
using ZhiHu.Infrastructure.Data.Interceptors;
using ZhiHu.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
namespace TestZhiHu
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var mockUser = new Mock<IUser>();
            mockUser.Setup(user => user.Id).Returns(1);
            services.AddSingleton(mockUser.Object);

            ConfigureEfCore(services);

            services.AddScoped<DbInitializer>();

            services.AddUseCaseServices();
            services.AddCoreServices();
        }

        private static void ConfigureEfCore(IServiceCollection services)
        {
            services.AddScoped<ISaveChangesInterceptor, AuditEntityInterceptor>();
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<AppDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

                options.UseSqlite("Data Source=:memory:");
            });

            services.AddScoped(typeof(IReadRepository<>), typeof(EfReadRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddScoped<IDataQueryService, DataQueryService>();
        }
    }
}
