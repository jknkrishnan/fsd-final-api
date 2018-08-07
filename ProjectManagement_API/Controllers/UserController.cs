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
        private ITaskAppContext usercontext = new TaskContext();

        public UserController()
        {

        }

        public UserController(ITaskAppContext context)
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
            catch (Exception ex)
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
        public HttpResponseMessage Get(int id)
        {
            IEnumerable<User> dt = null;
            try
            {
                if (id <= 0)
                {
                    throw new Exception("User ID cannot be null");
                }
                else
                { 
                    dt = new UserBusiness(usercontext).GetUsers(id);
                }
            }
            catch (Exception ex)
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

        // POST: api/User
        public HttpResponseMessage Post([FromBody]User usr)
        {
            IEnumerable<User> key = null;
            string msg = "";
            try
            {
                if (usr == null)
                {
                    throw new Exception("User cannot be null");
                }
                else
                {
                    key = new UserBusiness(usercontext).Post(usr);
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent(string.Format(msg)),
                    ReasonPhrase = "Error"
                };
                return response;

            }
            return Request.CreateResponse(HttpStatusCode.Created, key);
        }

        // PUT: api/User/5
        public HttpResponseMessage Put(int id, [FromBody]User usr)
        {
            string msg = "";
            IEnumerable<User> key = null;
            HttpResponseMessage response;

            try
            {
                if ((usr == null) || (id <= 0))
                {
                    throw new Exception("Parameter cannot be null");
                }
                else
                {
                    key = new UserBusiness(usercontext).Put(usr);
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent(string.Format(msg)),
                    ReasonPhrase = "Error"
                };
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.Created, key);
        }

        // DELETE: api/User/5
        public HttpResponseMessage Delete(int id)
        {
            string msg = "";
            int key = 0;
            HttpResponseMessage response;
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Parameter cannot be null");
                }
                else
                {
                    key = new UserBusiness(usercontext).Delete(id);
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent(string.Format(msg)),
                    ReasonPhrase = "Error"
                };
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.OK, key);
        }
    }
}
