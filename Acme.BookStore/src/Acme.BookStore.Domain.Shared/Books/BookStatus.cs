using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BookStore.Books
{
    /// <summary>
    /// 书籍状态枚举
    /// </summary>
    public enum BookStatus
    {
        Draft = 0,        // 草稿
        Published = 1,    // 已发布
        OutOfStock = 2,   // 缺货
        Discontinued = 3  // 已停售
    }
}
