using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Authors
{

    /// <summary>
    /// 作者实体
    /// </summary>
    public class Author : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 作者姓名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BirthDate { get; private set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Biography { get; private set; }

        /// <summary>
        /// 作者照片URL
        /// </summary>
        public string PhotoUrl { get; private set; }

        /// <summary>
        /// 该作者的书籍集合
        /// </summary>
        public virtual ICollection<Book> Books { get; private set; }      
    }
}