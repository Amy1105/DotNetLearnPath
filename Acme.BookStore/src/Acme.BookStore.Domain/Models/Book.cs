using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Models
{

    /// <summary>
    /// 书籍实体
    /// </summary>
    public class Book : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 书籍标题
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// 作者ID
        /// </summary>
        public Guid AuthorId { get; private set; }

        /// <summary>
        /// 作者（导航属性）
        /// </summary>
        public virtual Author Author { get; private set; }

        /// <summary>
        /// ISBN编号
        /// </summary>
        public string ISBN { get; private set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// 类别ID
        /// </summary>
        public Guid CategoryId { get; private set; }

        /// <summary>
        /// 类别（导航属性）
        /// </summary>
        public virtual Category Category { get; private set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public int Stock { get; private set; }

        /// <summary>
        /// 书籍状态
        /// </summary>
        public BookStatus Status { get; private set; }

        /// <summary>
        /// 书籍封面图片URL
        /// </summary>
        public string CoverImageUrl { get; private set; }

        /// <summary>
        /// 书籍描述
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 评论集合
        /// </summary>
        public virtual ICollection<BookReview> Reviews { get; private set; }

        // 私有构造函数，强制使用工厂方法创建实体
        private Book() { }

        // 工厂方法
        public static Book Create(
            Guid id,
            string title,
            Guid authorId,
            string isbn,
            decimal price,
            Guid categoryId,
            int stock = 0,
            BookStatus status = BookStatus.Draft,
            string coverImageUrl = null,
            string description = null)
        {
            Check.NotNullOrWhiteSpace(title, nameof(title));
            Check.NotNullOrWhiteSpace(isbn, nameof(isbn));
            Check.Range(price, nameof(price), 0, decimal.MaxValue);

            var book = new Book
            {
                Id = id,
                Title = title,
                AuthorId = authorId,
                ISBN = isbn,
                Price = price,
                CategoryId = categoryId,
                Stock = stock,
                Status = status,
                CoverImageUrl = coverImageUrl,
                Description = description,
                Reviews = new List<BookReview>()
            };

            return book;
        }

        // 业务方法：更新书籍信息
        public void UpdateInfo(
            string title,
            Guid authorId,
            string isbn,
            decimal price,
            Guid categoryId,
            string coverImageUrl = null,
            string description = null)
        {
            Check.NotNullOrWhiteSpace(title, nameof(title));
            Check.NotNullOrWhiteSpace(isbn, nameof(isbn));
            Check.Range(price, nameof(price), 0, decimal.MaxValue);

            Title = title;
            AuthorId = authorId;
            ISBN = isbn;
            Price = price;
            CategoryId = categoryId;
            CoverImageUrl = coverImageUrl;
            Description = description;
        }

        // 业务方法：增加库存
        public void IncreaseStock(int quantity)
        {
            Check.Positive(quantity, nameof(quantity));
            Stock += quantity;
        }

        // 业务方法：减少库存（带验证）
        public void DecreaseStock(int quantity)
        {
            Check.Positive(quantity, nameof(quantity));

            if (Stock < quantity)
            {
                throw new BusinessException(
                    BookStoreDomainErrorCodes.InsufficientStock,
                    $"库存不足：需要 {quantity}，现有 {Stock}"
                );
            }

            Stock -= quantity;
        }

        // 业务方法：更改书籍状态
        public void ChangeStatus(BookStatus newStatus)
        {
            Status = newStatus;
        }
    }
}