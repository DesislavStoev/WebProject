using App.Web.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Data
{
    public class DbRepository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity:class
    {
        private AppRContext _context;

        public DbRepository(AppRContext appRContext) 
        {
            _context = appRContext;
        }

        public Task AddAsync(TEntity entity)
        {
          return _context.AddAsync(entity);
        }

        public IEnumerable<TEntity> All()
        {
            return _context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
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
