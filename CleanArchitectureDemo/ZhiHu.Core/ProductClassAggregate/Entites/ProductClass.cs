using ZhiHu.Core.Common;
using ZhiHu.SharedKernel.Domain;
using ZhiHu.SharedKernel.Exceptions;

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
       

        private readonly List<ProductClassDetail> _productClassDetails = new(); // 私有集合，避免外部直接修改
        public IReadOnlyCollection<ProductClassDetail> productClassDetails => _productClassDetails.AsReadOnly(); // 暴露只读视图


        // 新增产品（封装关联规则）
        public void AddProductClassDetail(ProductClassDetail product)
        {
            if (product == null)
                throw new DomainException("产品不能为null");
            if (_productClassDetails.Any(p => p.Id == product.Id))
                throw new DomainException("该产品已存在于分类中");

            _productClassDetails.Add(product);
        }

        // 删除产品
        public void RemoveProductClassDetail(int productId)
        {
            var product = _productClassDetails.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                throw new DomainException("产品不存在于分类中");
            if (_productClassDetails.Count == 1)
                throw new DomainException("分类下至少保留一个产品"); // 业务规则示例

            _productClassDetails.Remove(product);
        }
      
        // 修改下属产品
        public void UpdateProductClassDetail(ProductClassDetail product)
        {
            var detail = _productClassDetails.FirstOrDefault(p => p.Id == product.Id)
                ?? throw new DomainException("产品不存在于分类中");

            _productClassDetails.Remove(detail);
            _productClassDetails.Add(product); // 调用产品自身的修改方法
        }
    }
}
