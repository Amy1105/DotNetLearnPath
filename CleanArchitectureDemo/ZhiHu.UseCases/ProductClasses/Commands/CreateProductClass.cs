using AutoMapper;
using FluentValidation;
using ZhiHu.Core.Data;
using ZhiHu.Core.ProductClassAggregate.Entites;
using ZhiHu.SharedKernel.Messaging;
using ZhiHu.SharedKernel.Repositoy;
using ZhiHu.SharedKernel.Result;
using ZhiHu.UseCases.Common.Attributes;
using ZhiHu.UseCases.Questions;

namespace ZhiHu.UseCases.ProductClasses.Commands
{

    [Authorize]
    public record CreateProductClassCommand(string Code,string Name,string Remark) : ICommand<IResult>;

    public class CreateProductClassValidator : AbstractValidator<CreateProductClassCommand>
    {
        public CreateProductClassValidator()
        {
            RuleFor(command => command.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(1, DataSchemaConstants.DefaultMaxLength100);

            RuleFor(command => command.Code)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .Length(1, DataSchemaConstants.DefaultMaxLength100);

            RuleFor(command => command.Remark)
                .MaximumLength(DataSchemaConstants.DefaultMaxLength500);
        }
    }

    public class CreateProductClassCommandHanlder(IRepository<ProductClass> repository, IMapper mapper) : ICommandHandler<CreateProductClassCommand, IResult>
    {
        public async Task<IResult> Handle(CreateProductClassCommand request, CancellationToken cancellationToken)
        {
            var productClass = mapper.Map<ProductClass>(request);
            repository.Add(productClass);
            await repository.SaveChangesAsync(cancellationToken);
            return Result.Success(new CreatedQuestionDto(productClass.Id));            
        }
    }
}
