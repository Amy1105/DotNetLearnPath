using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;

namespace Acme.BookStore.Models
{
    /// <summary>
    /// 书籍评论实体
    /// </summary>
    public class BookReview : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 书籍ID
        /// </summary>
        public Guid BookId { get; private set; }

        /// <summary>
        /// 书籍（导航属性）
        /// </summary>
        public virtual Book Book { get; private set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// 评分（1-5星）
        /// </summary>
        public int Rating { get; private set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string Comment { get; private set; }

        /// <summary>
        /// 评论是否已审核
        /// </summary>
        public bool IsApproved { get; private set; }

        //private BookReview() { }

        //public static BookReview Create(
        //    Guid id,
        //    Guid bookId,
        //    Guid userId,
        //    int rating,
        //    string comment)
        //{
        //    Check.NotNull(bookId, nameof(bookId));
        //    Check.NotNull(userId, nameof(userId));
        //    Check.Range(rating, nameof(rating), 1, 5);
        //    Check.NotNullOrWhiteSpace(comment, nameof(comment));

        //    var review = new BookReview
        //    {
        //        Id = id,
        //        BookId = bookId,
        //        UserId = userId,
        //        Rating = rating,
        //        Comment = comment,
        //        IsApproved = false // 默认未审核
        //    };

        //    return review;
        //}

        //public void UpdateRatingAndComment(int rating, string comment)
        //{
        //    Check.Range(rating, nameof(rating), 1, 5);
        //    Check.NotNullOrWhiteSpace(comment, nameof(comment));

        //    Rating = rating;
        //    Comment = comment;
        //}

        //public void Approve()
        //{
        //    IsApproved = true;
        //}

        //public void Reject()
        //{
        //    IsApproved = false;
        //}
    }
}
