using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhiHu.UseCases.ProductClasses
{
    public class ProductClassDto
    {
        public int Id { get; set; }
        /// <summary>
        ///样品类型名称
        /// </summary>     
        public string ProductClassName { get; set; }

        /// <summary>
        ///编码
        /// </summary>     
        public string Code { get; set; }

        /// <summary>
        ///备注
        /// </summary>    
        public string Remark { get; set; }
    }
}
