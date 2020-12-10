using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Permissions.BL.IRepositories;
using Permissions.DAL.Context;
using Permissions.DAL.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Permissions.BL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly PermissionsContext _context;
        public DbSet<T> _set;

        public BaseRepository(PermissionsContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _set.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(T[] entities)
        {
            await _set.AddRangeAsync(entities);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _set.Where(predicate);
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsNoTracking();
        }

        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _set.AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public virtual void Remove(T entity)
        {
            _set.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public virtual async Task<T> FindAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _set.AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            var entity = await query.FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }

    }
}
