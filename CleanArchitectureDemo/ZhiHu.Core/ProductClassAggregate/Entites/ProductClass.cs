using ZhiHu.Core.Common;
using ZhiHu.SharedKernel.Domain;

namespace ZhiHu.Core.ProductClassAggregate.Entites
{
    public partial class ProductClass : AuditWithUserEntity, IAggregateRoot
    {
        protected ProductClass()
        {

        }
        
        /// <summary>
        ///样品类型名称
        /// </summary>     
        public string Name { get; set; }

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
