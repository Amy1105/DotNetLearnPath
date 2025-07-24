using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhiHu.Models
{
    public record UserRegisterRequest(string Username, string Password);

    public record UserLoginRequest(string Username, string Password);
}
