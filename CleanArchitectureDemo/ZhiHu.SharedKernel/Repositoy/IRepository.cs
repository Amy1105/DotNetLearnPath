using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiHu.SharedKernel.Domain;
using ZhiHu.SharedKernel.Specification;

namespace ZhiHu.SharedKernel.Repositoy
{
    /// <summary>
    ///     <para>
    ///         <see cref="IRepository{T}" /> 用于查询和保存 <typeparamref name="T" />
    ///     </para>
    /// </summary>
    /// <typeparam name="T">该仓储操作的实体类型</typeparam>
    public interface IRepository<T> : IReadRepository<T> where T : class, IEntity, IAggregateRoot
    {
        /// <summary>
        ///     在数据库中添加实体
        /// </summary>
        /// <param name="entity">要添加的实体</param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        ///     在数据库中更新实体
        /// </summary>
        /// <param name="entity">要更新的实体</param>
        /// <returns></returns>
        void Update(T entity);

        /// <summary>
        ///     在数据库中删除实体
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        /// <returns></returns>
        void Delete(T entity);

        /// <summary>
        ///     批量删除实体
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> BatchDeleteAsync(ISpecification<T>? specification = null, CancellationToken cancellationToken = default);

        /// <summary>
        ///     持久化实体到数据库
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

}
