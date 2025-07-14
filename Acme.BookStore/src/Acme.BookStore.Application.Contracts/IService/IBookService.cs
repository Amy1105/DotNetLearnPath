using Acme.BookStore.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.IService
{
    public interface IBookService : IApplicationService
    {
        Task<BookDto> GetAsync(Guid id);
        Task<PagedResultDto<BookDto>> GetListAsync(GetBookListDto input);
        Task<bool> CreateAsync(CreateBookDto input);

        Task UpdateAsync(Guid id, UpdateBookDto input);
        Task DeleteAsync(Guid id);
    }
}
