using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.Data.Enums;

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

    public class ProductClassDetailDto
    {
        public int Id { get; set; }

        public OperationType OperationType { get; set; }
        /// <summary>
        /// 样品类型
        /// </summary>       
        public string SampleGroupCode { get; set; }

        /// <summary>
        ///样品规格名称
        /// </summary>      
        public string Name { get; set; }

        /// <summary>
        ///顺序号
        /// </summary>      
        public string Code { get; set; }

        /// <summary>
        ///备注
        /// </summary>     
        public string Remark { get; set; }
    }
}
