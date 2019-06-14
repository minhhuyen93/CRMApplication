using System.Collections.Generic;
using Application.Entity;

namespace Application.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(UnitOfWork uow) : base(uow.GetDbSet<User>()) { }

        internal IList<User> GetUsers()
        {
            return this.GetAll();
        }
    }
}