using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.Common;

namespace ZhiHu.Core.AppUserAggregate.Entites
{
    public class FollowUser : BaseEntity
    {
        // 关注者
        public int FollowerId { get; set; }
        public AppUser Follower { get; set; } = null!;

        // 被关注者
        public int FolloweeId { get; set; }
        public AppUser Followee { get; set; } = null!;

        public DateTimeOffset FollowDate { get; set; }
    }
}
