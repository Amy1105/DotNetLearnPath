
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.UseCases.Common.Interfaces;

namespace ZhiHu.Services
{
    public class CurrentUser(IHttpContextAccessor httpContextAccessor) : IUser
    {
        public readonly ClaimsPrincipal? User = httpContextAccessor.HttpContext?.User;

        public string? Username => User?.FindFirstValue(ClaimTypes.Name);

        public int? Id
        {
            get
            {
                var id = User?.FindFirstValue(ClaimTypes.NameIdentifier);

                if (id is null) return null;

                return Convert.ToInt32(id);
            }
        }
    }
}
