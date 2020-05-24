using Application.Api.Interface.DBContext;
using Application.Api.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Api.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDbContext _context;
        private DbSet<TEntity> _entity;
        protected BaseRepository(IDbContext context)
        {
            _context = context;
        }

        protected DbContext DbContext => (DbContext)_context;
        private DbSet<TEntity> Entity
        {
            get
            {
                return _entity is null ? _entity = DbContext.Set<TEntity>() : _entity;
            }
        }
       
        public async Task<TEntity> Get(int id)
        {
            return await Entity.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Entity.ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entity.Where(predicate).ToListAsync();
        }

        public async Task Add(TEntity entity)
        {
           await Entity.AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            await Entity.AddRangeAsync(entities);
        }

        public void Remove(TEntity entity)
        {
             Entity.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
             Entity.RemoveRange(entities);
        }

        public async Task Complete()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
