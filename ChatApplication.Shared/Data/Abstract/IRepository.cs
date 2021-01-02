using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Shared.Data.Abstract
{
    public interface IRepository<T> where T : class, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includesProperies);

        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includesProperies);

        Task<T> AddAsync(T Entity);

        Task<T> UpdateAsync(T Entity);

        Task DeleteAsync(T Entity);

        Task<bool> Any(Expression<Func<T, bool>> predicate);

        Task<int> Count(Expression<Func<T, bool>> predicate = null);

        IQueryable<T> Queryable();
    }
}
