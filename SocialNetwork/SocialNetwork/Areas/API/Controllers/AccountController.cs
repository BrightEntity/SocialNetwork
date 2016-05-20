using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SocialNetwork.Models;

namespace SocialNetwork.Areas.API.Controllers
{
    public class AccountController : ApiController
    {
        ApplicationDbContext ctx;

        public AccountController():base()
        {
            ctx = new ApplicationDbContext();
        }

        // GET: api/Account
        public IEnumerable<ApplicationUser> Get()
        {
            IEnumerable<ApplicationUser> users = ctx.Users;
            return users;
        }

        // GET: api/Account/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Account
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Account/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Account/5
        public void Delete(int id)
        {
        }
    }
}
