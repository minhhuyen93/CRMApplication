using Application.Entity;
using Application.Repository;
using System.Data.Entity;

namespace Application.Context
{
    public class UserMangementDbContext : DbContext, IDbContext
    {
        public UserMangementDbContext():base("UserMangementDbContext")
        {
            Database.SetInitializer<UserMangementDbContext>(new DropCreateDatabaseIfModelChanges<UserMangementDbContext>());
        }
        public IDbSet<User> Users { get; set; }

        public IDbSet<TEntity> GetContextDbSet<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }
    }
}