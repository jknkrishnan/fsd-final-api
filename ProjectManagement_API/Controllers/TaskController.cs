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
    public class TaskController : ApiController
    {
        private ITaskAppContext taskcontext = new TaskContext();

        public TaskController()
        {

        }

        public TaskController(ITaskAppContext context)
        {
            taskcontext = context;
        }

        // GET: api/Task
        public HttpResponseMessage Get()
        {
            IEnumerable<Task> dt = null;
            try
            {
                dt = new TaskBusiness(taskcontext).GetTasks();
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

        // GET: api/Task/5
        public HttpResponseMessage Get(int id)
        {
            IEnumerable<Task> dt = null;
            try
            {
                if (id < 0)
                { throw new Exception("Task cannot be null"); }
                else { 
                dt = new TaskBusiness(taskcontext).GetTasks(id);
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

        // POST: api/Task
        public HttpResponseMessage Post([FromBody]Task ts)
        {
            IEnumerable<Task> key = null;
            string msg = "";
            try
            {
                if (ts == null)
                {
                    throw new Exception("Task cannot be null");
                }
                else
                {
                    key = new TaskBusiness(taskcontext).Post(ts);
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

        // PUT: api/Task/5
        public HttpResponseMessage Put(int id, [FromBody]Task ts)
        {
            string msg = "";
            IEnumerable<Task> key = null;
            HttpResponseMessage response;

            try
            {
                if ((ts == null) || (id <= 0))
                {
                    throw new Exception("Parameter cannot be null");
                }
                else
                {
                    key = new TaskBusiness(taskcontext).Put(ts);
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

        // DELETE: api/Task/5
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
                    key = new TaskBusiness(taskcontext).Delete(id);
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
