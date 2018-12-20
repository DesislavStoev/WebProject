using App.Web.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.Data
{
    public class DbRepository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity:class
    {
        private DbSet<TEntity> _dbSet;
        private AppRContext _context;

        public DbRepository(AppRContext appRContext) 
        {
            _context = appRContext;
            _dbSet = _context.Set<TEntity>();
        }

        public Task AddAsync(TEntity entity)
        {
          return _dbSet.AddAsync(entity);
        }

        public IQueryable<TEntity> All()
        {
            return _dbSet;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> SafeChangesAsync()
        {
           return _context.SaveChangesAsync();
        }
    }
}
