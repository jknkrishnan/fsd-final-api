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
    public class ProjectController : ApiController
    {
                
        private ITaskAppContext projcontext = new TaskContext();

        public ProjectController()
        {

        }

        public ProjectController(ITaskAppContext context)
        {
            projcontext = context;
        }


        // GET: api/Project
        public HttpResponseMessage Get()
        {
            IEnumerable<Project> dt = null;
            try
            {
                dt = new ProjectBusiness(projcontext).GetProjects();
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

        // GET: api/Project/5
        public HttpResponseMessage Get(int id)
        {
            IEnumerable<Project> dt = null;
            try
            {
                dt = new ProjectBusiness(projcontext).GetProjects(id);
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

        // POST: api/Project
        public HttpResponseMessage Post([FromBody]Project proj)
        {
            IEnumerable<Project> key = null;
            string msg = "";
            try
            {
                if (proj == null)
                {
                    throw new Exception("User cannot be null");
                }
                else
                {
                    key = new ProjectBusiness(projcontext).Post(proj);
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

        // PUT: api/Project/5
        public HttpResponseMessage Put(int id, [FromBody]Project proj)
        {
            string msg = "";
            IEnumerable<Project> key = null;
            HttpResponseMessage response;

            try
            {
                if ((proj == null) || (id <= 0))
                {
                    throw new Exception("Parameter cannot be null");
                }
                else
                {
                    key = new ProjectBusiness(projcontext).Put(proj);
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

        // DELETE: api/Project/5
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
                    key = new ProjectBusiness(projcontext).Delete(id);
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
