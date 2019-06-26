namespace Application.Common.Factory
{
    using Application.Common.Attr;
    using Application.Common.Helper;
    using Application.Repository;
    public class DataBaseFactory
    {
        internal static IDbContext Create<TEntity>() where TEntity : class
        {
            DbContextAttribute dbContextAttribute = AssemblyHelper.GetClassAttribute<DbContextAttribute>(typeof(IDbContext));
            IDbContext dbContext = AssemblyHelper.Create(dbContextAttribute.Use);
            return dbContext;
        }
    }
}