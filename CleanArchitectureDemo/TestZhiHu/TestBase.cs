using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Infrastructure.Data;
using ZhiHu.UseCases.Common.Interfaces;

namespace TestZhiHu
{
    public abstract class TestBase
    {
        protected TestBase(IServiceProvider serviceProvider)
        {
            serviceProvider.GetRequiredService<DbInitializer>().InitialCreate();

            Sender = serviceProvider.GetRequiredService<ISender>();

            CurrentUser = serviceProvider.GetRequiredService<IUser>();

            DbContext = serviceProvider.GetRequiredService<AppDbContext>();
        }

        protected ISender Sender { get; private set; }

        protected IUser CurrentUser { get; private set; }

        protected AppDbContext DbContext { get; private set; }
    }

}
