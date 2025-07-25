using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.Core.Common;
using ZhiHu.Core.AppUserAggregate.Entites;
using ZhiHu.SharedKernel.Domain;

namespace ZhiHu.Core.ProductClassAggregate.Entites
{
    public partial class ProductClass : BaseAuditEntity, IAggregateRoot
    {
        protected ProductClass()
        {

        }
        
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

        public ICollection<ProductClassDetail> productClassDetails { get; set; } = new List<ProductClassDetail>();
    }
}
