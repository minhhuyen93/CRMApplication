using System.Collections.Generic;
using Application.Entity;

namespace Application.Services
{
    public interface IUserService
    {
        IList<User> GetUsers();
    }
}