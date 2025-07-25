using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.UseCases.Common.Exceptions;
using ZhiHu.UseCases.Questions.Commands;

namespace TestZhiHu.Questions.Commonds
{
    public class CreateQuestionTest(IServiceProvider serviceProvider) : TestBase(serviceProvider)
    {
        [Fact]
        public async Task ShouldSuccess()
        {
            var result = await Sender.Send(new CreateQuestionCommand("这是一个问题吗？", "这是一个问题的描述"));
            result.GetValue().Should().NotBe(0);
            result.Status.Should().Be(ResultStatus.Ok);
        }

        [Fact]
        public async Task ShouldValidationExceptionForNoQuestionMark()
        {
            var action = async () =>
            {
                await Sender.Send(new CreateQuestionCommand("这不是一个问题", "这是一个问题的描述"));
            };
            await action.Should().ThrowAsync<ValidationException>();
        }

        [Fact]
        public async Task ShouldValidationExceptionForLength()
        {
            var action = async () =>
            {
                await Sender.Send(new CreateQuestionCommand("这是问题？", "这是一个问题的描述"));
            };
            await action.Should().ThrowAsync<ValidationException>();
        }

        [Fact]
        public async Task ShouldValidationExceptionForEmpty()
        {
            var action = async () =>
            {
                await Sender.Send(new CreateQuestionCommand("", ""));
            };
            await action.Should().ThrowAsync<ValidationException>();
        }
    }
}
