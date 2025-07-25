using ZhiHu.Core.Common;

namespace ZhiHu.Core.ProductClassAggregate.Entites
{
    public  class ProductClassDetail : BaseAuditEntity
    {
        protected ProductClassDetail()
        {

        }     

        /// <summary>
        /// ProductClassId
        /// </summary>
        public ProductClass ProductClass { get; set; } = null!;

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
