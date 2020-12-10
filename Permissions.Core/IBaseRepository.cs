using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Permissions.Core
{
    public interface IBaseRepository<T> where T : class, IEntityBase, new()
    {
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task<T> FindAsync(int id, params Expression<Func<T, object>>[] includeProperties);
        Task AddAsync(T value);
        Task AddRangeAsync(T[] values);
        void Update(T value);
        void Remove(T value);
        Task SaveAsync();
    }
}
