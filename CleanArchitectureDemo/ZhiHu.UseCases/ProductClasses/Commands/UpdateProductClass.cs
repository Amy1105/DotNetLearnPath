using AutoMapper;
using FluentValidation;
using ZhiHu.Core.Data;
using ZhiHu.Core.Data.Enums;
using ZhiHu.Core.ProductClassAggregate.Entites;
using ZhiHu.Core.ProductClassAggregate.Specifications;
using ZhiHu.SharedKernel.Messaging;
using ZhiHu.SharedKernel.Repositoy;
using ZhiHu.SharedKernel.Result;
using ZhiHu.UseCases.Common.Attributes;
using ZhiHu.UseCases.Common.Interfaces;

namespace ZhiHu.UseCases.ProductClasses.Commands
{
    [Authorize]
    public record UpdateProductClassCommand : ICommand<IResult>
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
        public string? Remark { get; set; }

        public List<ProductClassDetailDto> productClassDetailDtos { get; set; }
    }

    public class UpdateQuestionCommandValidator : AbstractValidator<UpdateProductClassCommand>
    {
        public UpdateQuestionCommandValidator()
        {
            RuleFor(command => command.Id)
                .GreaterThan(0);

            RuleFor(command => command.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(1, DataSchemaConstants.DefaultMaxLength100);

            RuleFor(command => command.Name)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .Length(1, DataSchemaConstants.DefaultMaxLength100);

            RuleFor(command => command.Remark)
                .MaximumLength(DataSchemaConstants.DefaultMaxLength500);
        }
    }

    public class UpdateQuestionCommandHandler(
        IRepository<ProductClass> repository,
        IUser user,
        IMapper mapper) : ICommandHandler<UpdateProductClassCommand, IResult>
    {
        public async Task<IResult> Handle(UpdateProductClassCommand request, CancellationToken cancellationToken)
        {
            var spec = new ProductClassByUpdateBy(request.Id,user.Id!.Value);
            var productclass = await repository.GetSingleOrDefaultAsync(spec, cancellationToken);
            if (productclass == null) return Result.NotFound("产品类型不存在");
            mapper.Map(request, productclass);

            foreach (var op in request.productClassDetailDtos)
            {
                ProductClassDetail ProductClassDetail = null;

                mapper.Map(op, ProductClassDetail);

                //对应不同业务规则，分开检查
                switch (op.OperationType)
                {                    
                    case OperationType.Add:
                        productclass.AddProductClassDetail(ProductClassDetail);                      
                        break;
                    case OperationType.Update:
                        productclass.UpdateProductClassDetail(ProductClassDetail);
                        break;
                    case OperationType.Delete:
                        productclass.RemoveProductClassDetail(op.Id);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            await repository.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
