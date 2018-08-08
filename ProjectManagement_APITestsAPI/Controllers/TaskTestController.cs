using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using System.Web.Http.Hosting;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using System.Collections;
using Newtonsoft.Json;
using ProjectManagement_Entities;
using ProjectManagement_API.Tests.Context;
using ProjectManagement_API.Controllers;

namespace ProjectManagement_API.Tests.Controllers
{
    [TestFixture]
    public class TaskTestController
    {
        public static IEnumerable GetTaskData
        {
            get
            {
                string FileLoc = @"TestData\Task.json";
                string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "").Replace("\\bin\\Debug", "");

                var jsonText = File.ReadAllText(Path.Combine(FilePath, FileLoc));
                var task = JsonConvert.DeserializeObject<ProjectManagement_Entities.Task>(jsonText);
                yield return task;
            }
        }

        [Test, TestCaseSource("GetTaskData")]
        public void GetTask(Task pro)
        {
            var context = new TaskTestContext();
            context.Task.Add(pro);
            TaskController controller = new TaskController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Get();
            Assert.AreEqual(HttpStatusCode.OK, http.StatusCode);
        }

        [Test, TestCaseSource("GetTaskData")]
        public void GetProjectNullCheck(Task pro)
        {

        }

        [Test, TestCaseSource("GetTaskData")]
        public void GetTaskByID(Task pro)
        {
            var context = new TaskTestContext();
            context.Task.Add(pro);
            TaskController controller = new TaskController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Get(pro.Task_Id);
            Assert.AreEqual(HttpStatusCode.OK, http.StatusCode);
            var response = http.Content.ReadAsStringAsync().Result
                                               .Replace("\\", "")
                                               .Trim(new char[1] { '"' });
            List<Task> _list = JsonConvert.DeserializeObject<List<Task>>(response);
            Assert.IsNotNull(_list);
            Assert.AreEqual(pro.Task_Id, _list[0].Task_Id);
        }

        [Test, TestCaseSource("GetTaskData")]
        public void GetProjectByIDNULLCheck(Task pro)
        {
            var context = new TaskTestContext();
            context.Task.Add(pro);
            TaskController controller = new TaskController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Get(-1);
            Assert.AreEqual(HttpStatusCode.NotFound, http.StatusCode);
        }

        [Test, TestCaseSource("GetTaskData")]
        public void PostTask(Task pro)
        {
            var context = new TaskTestContext();
            context.Task.Add(pro);
            TaskController controller = new TaskController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Post(pro);
            Assert.AreEqual(HttpStatusCode.Created, http.StatusCode);
            var response = http.Content.ReadAsStringAsync().Result
                                               .Replace("\\", "")
                                               .Trim(new char[1] { '"' });
            List<Task> _list = JsonConvert.DeserializeObject<List<Task>>(response);
            Assert.IsNotNull(_list);
            Assert.AreEqual(pro.Parent_Id, _list[0].Parent_Id);
            Assert.AreEqual(pro.TaskDesc, _list[0].TaskDesc);
            Assert.AreEqual(pro.StartDate, _list[0].StartDate);
            Assert.AreEqual(pro.EndDate, _list[0].EndDate);
            Assert.AreEqual(pro.Priority, _list[0].Priority);
            Assert.AreEqual(pro.Status, _list[0].Status);
            Assert.AreEqual(pro.User_Id, _list[0].User_Id);
            Assert.AreEqual(pro.Project_Id, _list[0].Project_Id);
        }

        [Test, TestCaseSource("GetTaskData")]
        public void PostTaskNullCheck(Task pro)
        {
            var context = new TaskTestContext();
            context.Task.Add(pro);
            TaskController controller = new TaskController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Post(null);
            Assert.AreEqual(HttpStatusCode.Conflict, http.StatusCode);
        }

        [Test, TestCaseSource("GetTaskData")]
        public void Puttask(Task pro)
        {
            var context = new TaskTestContext();
            context.Task.Add(pro);
            TaskController controller = new TaskController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Put(pro.Project_Id, pro);
            Assert.AreEqual(HttpStatusCode.Created, http.StatusCode);
            var response = http.Content.ReadAsStringAsync().Result
                                               .Replace("\\", "")
                                               .Trim(new char[1] { '"' });
            List<Task> _list = JsonConvert.DeserializeObject<List<Task>>(response);
            Assert.IsNotNull(_list);
            Assert.AreEqual(pro.Parent_Id, _list[0].Parent_Id);
            Assert.AreEqual(pro.TaskDesc, _list[0].TaskDesc);
            Assert.AreEqual(pro.StartDate, _list[0].StartDate);
            Assert.AreEqual(pro.EndDate, _list[0].EndDate);
            Assert.AreEqual(pro.Priority, _list[0].Priority);
            Assert.AreEqual(pro.Status, _list[0].Status);
            Assert.AreEqual(pro.User_Id, _list[0].User_Id);
            Assert.AreEqual(pro.Project_Id, _list[0].Project_Id);
            Assert.AreEqual(pro.Task_Id, _list[0].Task_Id);
        }

        [Test, TestCaseSource("GetTaskData")]
        public void PuttaskNullCheck(Task pro)
        {
            var context = new TaskTestContext();
            context.Task.Add(pro);
            TaskController controller = new TaskController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Put(-1, pro);
            Assert.AreEqual(HttpStatusCode.Conflict, http.StatusCode);
        }

        [Test, TestCaseSource("GetTaskData")]
        public void Deletetask(Task pro)
        {
            var context = new TaskTestContext();
            context.Task.Add(pro);
            TaskController controller = new TaskController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Delete(pro.Task_Id);
            Assert.AreEqual(HttpStatusCode.OK, http.StatusCode);
            var response = http.Content.ReadAsStringAsync().Result
                                               .Replace("\\", "")
                                               .Trim(new char[1] { '"' });
            Assert.AreEqual(pro.Task_Id.ToString(), response);
        }

        [Test, TestCaseSource("GetTaskData")]
        public void DeletetaskNullCheck(Task pro)
        {
            var context = new TaskTestContext();
            context.Task.Add(pro);
            TaskController controller = new TaskController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Delete(-1);
            Assert.AreEqual(HttpStatusCode.Conflict, http.StatusCode);
        }
    }
}
