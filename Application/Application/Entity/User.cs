namespace Application.Entity
{
    using Application.Common.Attr;
    using Application.Repository;
    [DbContextAttribute(Use = typeof(IDbContext))]
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}