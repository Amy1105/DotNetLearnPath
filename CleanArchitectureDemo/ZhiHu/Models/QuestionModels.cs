using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhiHu.Models
{
    public record CreateQuestionRequest(string Title, string Description);

    public record UpdateQuestionRequest(string Title, string Description);

}
