using Application.Entity;
using System;
using System.Data.Entity;

namespace Application.Context
{
    public class UserMangementDbContext : DbContext
    {
        public UserMangementDbContext():base("UserMangementDbContext")
        {
            Database.SetInitializer<UserMangementDbContext>(new DropCreateDatabaseIfModelChanges<UserMangementDbContext>());
        }
        public IDbSet<User> Users { get; set; }

        internal IDbSet<TEntity> GetContextDbSet<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }
    }
}