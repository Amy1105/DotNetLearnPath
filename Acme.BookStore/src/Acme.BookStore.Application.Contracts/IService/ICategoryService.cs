using Acme.BookStore.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.IService
{
    public interface ICategoryService : IApplicationService
    {
        Task<List<CategoryDto>> GetListAsync();

    }
}
