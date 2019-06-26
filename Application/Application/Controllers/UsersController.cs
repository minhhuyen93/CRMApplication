﻿namespace Application.Controllers
{
    using Application.Common.Data;
    using Application.Entity;
    using Application.Repository;
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
            using (UnitOfWork<User> uow = new UnitOfWork<User>())
            {
                UserRepository repo = new UserRepository(uow);
                return repo.GetUsers();
            }
        }
    }
}
