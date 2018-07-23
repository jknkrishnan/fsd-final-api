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
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        // POST: api/Parent
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Parent/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Parent/5
        public void Delete(int id)
        {
        }
    }
}
