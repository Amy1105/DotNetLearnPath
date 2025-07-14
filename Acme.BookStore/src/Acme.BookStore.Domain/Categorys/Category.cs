using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using Acme.BookStore.Books;

namespace Acme.BookStore.Categorys
{
    /// <summary>
    /// 书籍类别实体
    /// </summary>
    public class Category : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 类别名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 父类别ID（如果有）
        /// </summary>
        public Guid? ParentId { get; private set; }

        /// <summary>
        /// 父类别（导航属性）
        /// </summary>
        public virtual Category Parent { get; private set; }

        /// <summary>
        /// 子类别集合
        /// </summary>
        public virtual ICollection<Category> Children { get; private set; }

        /// <summary>
        /// 该类别下的书籍集合
        /// </summary>
        public virtual ICollection<Book> Books { get; private set; }

        /// <summary>
        /// 类别描述
        /// </summary>
        public string Description { get; private set; }

        private Category() { }

        public static Category Create(
            Guid id,
            string name,
            Guid? parentId = null,
            string description = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var category = new Category
            {
                Id = id,
                Name = name,
                ParentId = parentId,
                Description = description,
                Children = new List<Category>(),
                Books = new List<Book>()
            };

            return category;
        }

        public void UpdateInfo(string name, string description = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Name = name;
            Description = description;
        }

        public void SetParent(Category parent)
        {
            ParentId = parent?.Id;
            Parent = parent;
        }
    }
}
