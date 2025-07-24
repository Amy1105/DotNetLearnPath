using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Infrastructure;
using ZhiHu.UseCases.AppUsers.Queries;

namespace ZhiHu.Controllers
{
    public class AppUserController : ApiControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Sender.Send(new GetUserInfoQuery(id));

            return ReturnResult(result);
        }
    }
}
