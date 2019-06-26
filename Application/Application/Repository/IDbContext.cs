using System.Data.Entity;

namespace Application.Repository
{
    public interface IDbContext
    {
        IDbSet<TEntity> GetContextDbSet<TEntity>() where TEntity:class;
    }
}