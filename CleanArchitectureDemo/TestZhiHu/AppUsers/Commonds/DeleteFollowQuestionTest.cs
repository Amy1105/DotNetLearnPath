using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.UseCases.AppUsers.Commands;

namespace TestZhiHu.AppUsers.Commonds
{
    public class DeleteFollowQuestionTest(IServiceProvider serviceProvider) : TestBase(serviceProvider)
    {
        [Fact]
        public async Task ShouldSuccess()
        {
            await Sender.Send(new CreateFollowQuestionCommand(1));
            var result = await Sender.Send(new DeleteFollowQuestionCommand(1));
            result.Status.Should().Be(ResultStatus.Ok);
            DbContext.FollowQuestions.Count().Should().Be(0);
        }

        [Fact]
        public async Task ShouldQuestionNoExists()
        {
            var result = await Sender.Send(new DeleteFollowQuestionCommand(99));
            result.Status.Should().Be(ResultStatus.Ok);
        }

        [Fact]
        public async Task ShouldFollowerCountZero()
        {
            await Sender.Send(new CreateFollowQuestionCommand(1));
            await Sender.Send(new DeleteFollowQuestionCommand(1));
            var question = await DbContext.Questions.FindAsync(1);
            question!.FollowerCount.Should().Be(0);
        }
    }
}
