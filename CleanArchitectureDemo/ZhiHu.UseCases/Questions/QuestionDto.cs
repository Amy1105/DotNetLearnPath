using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhiHu.UseCases.Questions
{
    public record QuestionDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public int AnswerCount { get; set; }

        public int FollowerCount { get; set; }

        public int ViewCount { get; set; }
    }
}
