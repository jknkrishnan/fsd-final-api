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
    public class ParentController : ApiController
    {
        private ITaskAppContext parentcontext = new TaskContext();

        public ParentController()
        {

        }

        public ParentController(ITaskAppContext context)
        {
            parentcontext = context;
        }

        // GET: api/Parent
        public HttpResponseMessage Get()
        {
            IEnumerable<Parent> dt = null;
            try
            {
                dt = new ParentBusiness(parentcontext).GetParents();
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

        // GET: api/Parent/5
        public HttpResponseMessage Get(int id)
        {
            IEnumerable<Parent> dt = null;
            try
            {
                dt = new ParentBusiness(parentcontext).GetParents(id);
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
        
        // POST: api/Parent
        public HttpResponseMessage Post([FromBody]Parent ts)
        {
            IEnumerable<Parent> key = null;
            string msg = "";
            try
            {
                if (ts == null)
                {
                    throw new Exception("Task cannot be null");
                }
                else
                {
                    key = new ParentBusiness(parentcontext).Post(ts);
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

        // PUT: api/Parent/5
        public HttpResponseMessage Put(int id, [FromBody]Parent ts)
        {
            string msg = "";
            IEnumerable<Parent> key = null;
            HttpResponseMessage response;

            try
            {
                if ((ts == null) || (id <= 0))
                {
                    throw new Exception("Parameter cannot be null");
                }
                else
                {
                    key = new ParentBusiness(parentcontext).Put(ts);
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

        // DELETE: api/Parent/5
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
                    key = new ParentBusiness(parentcontext).Delete(id);
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
