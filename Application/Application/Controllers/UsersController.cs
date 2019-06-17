namespace Application.Controllers
{
    using Application.Common.Data;
    using Application.Common.IoC;
    using Application.Entity;
    using Application.Services;
    using System.Collections.Generic;
    using System.Web.Http;
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [HttpGet()]
        [Route("")]
        [ResponseWrapper()]
        public IList<User> GetUsers()
        {
            IUserService service = IoC.Resolve<IUserService>();//new UserService();
            return service.GetUsers();
        }
    }
}
