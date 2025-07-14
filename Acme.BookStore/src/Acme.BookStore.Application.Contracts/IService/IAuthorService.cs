using Acme.BookStore.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.IService
{
    public interface IAuthorService : IApplicationService
    {
        Task<List<AuthorDto>> GetListAsync();
        
    }
}
