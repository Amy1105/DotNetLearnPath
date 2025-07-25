using FluentValidation;
using ZhiHu.Core.QuestionAggregate.Entites;
using ZhiHu.Core.QuestionAggregate.Specifications;
using ZhiHu.SharedKernel.Messaging;
using ZhiHu.SharedKernel.Repositoy;
using ZhiHu.SharedKernel.Result;
using ZhiHu.UseCases.Common.Attributes;
using ZhiHu.UseCases.Common.Interfaces;

namespace ZhiHu.UseCases.Questions.Commands
{

    [Authorize]
    public record DeleteQuestionCommand(int Id) : ICommand<IResult>;

    public class DeleteQuestionCommandValidator : AbstractValidator<DeleteQuestionCommand>
    {
        public DeleteQuestionCommandValidator()
        {
            RuleFor(command => command.Id)
                .GreaterThan(0);
        }
    }

    public class DeleteQuestionCommandHandler(
        IRepository<Question> questions,
        IUser user) : ICommandHandler<DeleteQuestionCommand, IResult>
    {
        public async Task<IResult> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var spec = new QuestionWithAnswerByCreatedBy(user.Id.Value, request.Id);
            var question = await questions.GetSingleOrDefaultAsync(spec, cancellationToken);
            if (question == null) return Result.NotFound("问题不存在");

            if (question.Answers.Count != 0) return Result.Failure("问题下有回答，不能删除");

            questions.Delete(question);

            await questions.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }


}
