using System;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Dto
{
    public class AuthorDto : EntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
