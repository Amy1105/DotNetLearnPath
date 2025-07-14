using Acme.BookStore.Dto;
using Acme.BookStore.IRepository;
using Acme.BookStore.IService;
using Acme.BookStore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;

namespace Acme.BookStore.Service
{
    public class AuthorService : ApplicationService, IAuthorService
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IObjectMapper _objectMapper;


        public async Task<List<AuthorDto>> GetListAsync()
        {
            var dbCategories = await authorRepository.GetListAsync();
            return _objectMapper.Map<List<Author>, List<AuthorDto>>(dbCategories);
        }
    }
}
