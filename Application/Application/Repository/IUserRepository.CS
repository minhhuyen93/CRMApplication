namespace Application.Repository
{
    using Application.Entity;
    using System.Collections.Generic;
    public interface IUserRepository
    {
        IList<User> GetUsers();
    }
}