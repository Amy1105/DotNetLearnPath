using Acme.BookStore.Dto;
using Acme.BookStore.IRepository;
using Acme.BookStore.IService;
using Acme.BookStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;

namespace Acme.BookStore.Service
{
    public class CategoryService : ApplicationService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IObjectMapper _objectMapper;


        public async Task<List<CategoryDto>> GetListAsync()
        {
            var dbCategories = await _categoryRepository.GetListAsync();
            return _objectMapper.Map<List<Category>, List<CategoryDto>>(dbCategories);
        }

    }
}
