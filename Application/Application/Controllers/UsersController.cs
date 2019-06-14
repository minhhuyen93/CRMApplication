namespace Application.Controllers
{
    using Application.Entity;
    using Application.Repository;
    using System.Collections.Generic;
    using System.Web.Http;
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [HttpGet()]
        [Route("")]
        public IList<User> GetUsers()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                UserRepository repo = new UserRepository(uow);
                return repo.GetUsers();
            }

        }
    }
}
