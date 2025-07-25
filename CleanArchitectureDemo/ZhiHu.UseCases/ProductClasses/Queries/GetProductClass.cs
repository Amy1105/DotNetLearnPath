using ZhiHu.SharedKernel.Messaging;
using ZhiHu.SharedKernel.Result;
using ZhiHu.UseCases.Common.Attributes;
using ZhiHu.UseCases.Common.Interfaces;

namespace ZhiHu.UseCases.ProductClasses.Queries
{
    [Authorize]
    public record GetProductClassQuery(int Id) : IQuery<Result<ProductClassDto>>;

    public class GetProductClassesQueryHandler(IDataQueryService queryService)
        : IQueryHandler<GetProductClassQuery, Result<ProductClassDto>>
    {
        public async Task<Result<ProductClassDto>> Handle(GetProductClassQuery request, CancellationToken cancellationToken)
        {
            var queryable = queryService.ProductClasses   
                .Where(x=>x.Id==request.Id)
                .Select(u => new ProductClassDto
                {
                    Id = u.Id,
                    ProductClassName = u.Name,
                    Code = u.Code,
                    Remark = u.Remark,                  
                });

            var productClass = await queryService.FirstOrDefaultAsync(queryable);

            return productClass is null ? Result.NotFound() : Result.Success(productClass);
        }
    }
}
