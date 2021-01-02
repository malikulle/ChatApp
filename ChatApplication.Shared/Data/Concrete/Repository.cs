using ChatApplication.Shared.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Sahred.Data.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class,  new()
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity Entity)
        {
            await _context.Set<TEntity>().AddAsync(Entity);
            return Entity;
        }

        public async Task<bool> Any(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null ? await _context.Set<TEntity>().CountAsync() : await _context.Set<TEntity>().CountAsync(predicate);
        }

        public async Task DeleteAsync(TEntity Entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Remove(Entity));
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includesProperies)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includesProperies.Any())
            {
                foreach (var includeProp in includesProperies)
                {
                    query = query.Include(includeProp);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includesProperies)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includesProperies.Any())
            {
                foreach (var includeProp in includesProperies)
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.SingleOrDefaultAsync(predicate);

        }

        public IQueryable<TEntity> Queryable()
            => _context.Set<TEntity>().AsQueryable();

        public async Task<TEntity> UpdateAsync(TEntity Entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Update(Entity));
            return Entity;
        }
    }
}
