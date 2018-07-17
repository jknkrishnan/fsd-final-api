using ProjectManagement_Business;
using ProjectManagement_DataContext;
using ProjectManagement_DataContext.Interface;
using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManagement_API.Controllers
{
    public class UserController : ApiController
    {
        private IUserAppContext usercontext = new UserContext();

        public UserController()
        {

        }

        public UserController(IUserAppContext context)
        {
            usercontext = context;
        }
        // GET: api/User
        public HttpResponseMessage Get()
        {
            IEnumerable<User> dt = null;
            try
            {
                dt = new UserBusiness(usercontext).GetUsers();
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format(ex.Message)),
                    ReasonPhrase = "Error"
                };
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
