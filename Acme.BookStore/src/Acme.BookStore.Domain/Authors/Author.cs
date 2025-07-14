using Acme.BookStore.Books;
using Acme.BookStore.Categorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Json.SystemTextJson.JsonConverters;

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
        public DateOnly BirthDate { get; private set; }

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


        public Author()
        {
                
        }
        public static Author Create(Guid id,string Name,DateOnly BirthDate,string Biography,string PhotoUrl)
        {
            Check.NotNullOrWhiteSpace(Name, nameof(Name));
             Author author = new Author()
            {
                 Id = id,
                 Name = Name,
                BirthDate = BirthDate,
                Biography = Biography,
                PhotoUrl = PhotoUrl

            };
            return author;
        }      

    }
}