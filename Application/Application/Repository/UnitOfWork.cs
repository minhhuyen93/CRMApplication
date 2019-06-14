using Application.Context;
using System;
using System.Data.Entity;

namespace Application.Repository
{
    public class UnitOfWork : IDisposable
    {
        UserMangementDbContext _context;
        public UnitOfWork()
        {
            this._context = new UserMangementDbContext();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        internal IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return this._context.GetContextDbSet<TEntity>();
        }

    }
}