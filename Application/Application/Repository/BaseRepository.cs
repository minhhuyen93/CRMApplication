using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Application.Repository
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        IDbSet<TEntity> _dbSet;

        public BaseRepository(IDbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        protected IList<TEntity> GetAll()
        {
            return this._dbSet.ToList();
        }
    }
}