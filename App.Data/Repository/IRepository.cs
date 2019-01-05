using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IRepository<TEntity>
        where TEntity: class
    {
        IEnumerable<TEntity> All();

        Task AddAsync(TEntity entity);

        void Delete(TEntity entity);

        Task<int> SafeChangesAsync();

        int SafeChanges();
    }
}
