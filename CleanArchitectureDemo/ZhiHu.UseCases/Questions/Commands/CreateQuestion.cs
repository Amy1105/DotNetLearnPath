using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.Data;
using ZhiHu.Core.QuestionAggregate.Entites;
using ZhiHu.SharedKernel.Messaging;
using ZhiHu.SharedKernel.Repositoy;
using ZhiHu.SharedKernel.Result;
using ZhiHu.UseCases.Common.Attributes;

namespace ZhiHu.UseCases.Questions.Commands
{
    [Authorize]
    public record CreateQuestionCommand(string Title, string? Description) : ICommand<Result<CreatedQuestionDto>>;

    public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
    {
        public CreateQuestionCommandValidator()
        {
            RuleFor(command => command.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(6, DataSchemaConstants.DefaultQuestionTitleLength)
                .Must(t => t.EndsWith('?') || t.EndsWith('？')).WithMessage("问题标题必须以问号结尾");

            RuleFor(command => command.Description)
                .MaximumLength(DataSchemaConstants.DefaultDescriptionTitleLength);
        }
    }

    public class CreateQuestionCommandHandler(
        IRepository<Question> questions,
        IMapper mapper) : ICommandHandler<CreateQuestionCommand, Result<CreatedQuestionDto>>
    {
        public async Task<Result<CreatedQuestionDto>> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = mapper.Map<Question>(request);

            questions.Add(question);

            await questions.SaveChangesAsync(cancellationToken);

            return Result.Success(new CreatedQuestionDto(question.Id));
        }
    }

}
