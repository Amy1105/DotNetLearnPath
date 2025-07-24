using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.Common;
using ZhiHu.SharedKernel.Domain;

namespace ZhiHu.Core.AppUserAggregate.Entites
{
    public class FollowQuestion : BaseEntity
    {
        public int UserId { get; set; }
        public AppUser AppUser { get; set; } = null!;

        public int QuestionId { get; set; }

        public DateTimeOffset FollowDate { get; set; }
    }
}
