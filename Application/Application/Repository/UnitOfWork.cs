namespace Application.Repository
{
    using Application.Common.Factory;
    using System;
    using System.Data.Entity;
    public class UnitOfWork<TEntity> : IDisposable where TEntity : class
    {
        IDbContext _context;
        public UnitOfWork()
        {
            this._context = DataBaseFactory.Create<TEntity>();
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