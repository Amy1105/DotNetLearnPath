using ZhiHu.Core.ProductClassAggregate.Entites;
using ZhiHu.Core.QuestionAggregate.Entites;
using ZhiHu.SharedKernel.Specification;

namespace ZhiHu.Core.ProductClassAggregate.Specifications
{
    public class ProductClassByUpdateBy : Specification<ProductClass>
    {
        public ProductClassByUpdateBy(int PID, int userId)
        {
            FilterCondition = q => q.Id == PID && q.CreatedBy == userId;
            AddInclude(x => x.productClassDetails);
        }
    }
}