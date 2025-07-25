using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.UseCases.Questions.Queries;

namespace TestZhiHu.Questions.Queries
{
    public class GetQuestionTest(IServiceProvider serviceProvider) : TestBase(serviceProvider)
    {
        [Fact]
        public async Task ShouldSuccess()
        {
            var result = await Sender.Send(new GetQuestionQuery(1));
            result.Value.Should().NotBeNull();
            result.Status.Should().Be(ResultStatus.Ok);
        }

        [Fact]
        public async Task ShouldQuestionNoExists()
        {
            var result = await Sender.Send(new GetQuestionQuery(99));
            result.Status.Should().Be(ResultStatus.NotFound);
            result.Errors.Should().Contain("问题不存在");
        }
    }
}
