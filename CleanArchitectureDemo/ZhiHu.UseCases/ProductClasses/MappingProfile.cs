using AutoMapper;
using ZhiHu.Core.ProductClassAggregate.Entites;
using ZhiHu.UseCases.ProductClasses.Commands;

namespace ZhiHu.UseCases.ProductClasses
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductClassCommand, ProductClass>();
            CreateMap<UpdateProductClassCommand, ProductClass>();
        }
    }
}
