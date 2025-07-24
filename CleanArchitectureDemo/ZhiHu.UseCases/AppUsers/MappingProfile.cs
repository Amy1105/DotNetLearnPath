using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.AppUserAggregate.Entites;

namespace ZhiHu.UseCases.AppUsers
{
    public record CreatedAppUserDto(int Id, string Nickname);

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, CreatedAppUserDto>();
        }
    }
}
