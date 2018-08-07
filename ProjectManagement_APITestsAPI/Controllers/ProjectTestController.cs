using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class ProjectTestController
    {
        public static IEnumerable GetProjectData
        {
            get
            {
                string FileLoc = @"TestData\Project.json";
                string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "").Replace("\\bin\\Debug", "");

                var jsonText = File.ReadAllText(Path.Combine(FilePath, FileLoc));
                var proj = JsonConvert.DeserializeObject<Project>(jsonText);
                yield return proj;
            }
        }

        [Test, TestCaseSource("GetProjectData")]
        public void GetProject(Project pro)
        {
            var context = new TaskTestContext();
            context.Project.Add(pro);
            ProjectController controller = new ProjectController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Get();
            Assert.AreEqual(HttpStatusCode.OK, http.StatusCode);
        }

        [Test, TestCaseSource("GetProjectData")]
        public void GetProjectNullCheck(Project pro)
        {

        }
        [Test, TestCaseSource("GetProjectData")]
        public void GetProjectByID(Project pro)
        {
            var context = new TaskTestContext();
            context.Project.Add(pro);
            ProjectController controller = new ProjectController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Get(pro.Project_Id);
            Assert.AreEqual(HttpStatusCode.OK, http.StatusCode);
            var response = http.Content.ReadAsStringAsync().Result
                                               .Replace("\\", "")
                                               .Trim(new char[1] { '"' });
            List<Project> _list = JsonConvert.DeserializeObject<List<Project>>(response);
            Assert.IsNotNull(_list);
            Assert.AreEqual(pro.Project_Id, _list[0].Project_Id);

        }

        [Test, TestCaseSource("GetProjectData")]
        public void GetProjectByIDNULLCheck(Project pro)
        {
            var context = new TaskTestContext();
            context.Project.Add(pro);
            ProjectController controller = new ProjectController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Get(-1);
            Assert.AreEqual(HttpStatusCode.NotFound, http.StatusCode);
        }

        [Test, TestCaseSource("GetProjectData")]
        public void PostProject(Project pro)
        {

        }

        [Test, TestCaseSource("GetProjectData")]
        public void PostProjectNullCheck(Project pro)
        {

        }

        [Test, TestCaseSource("GetProjectData")]
        public void Putproject(Project pro)
        {

        }

        [Test, TestCaseSource("GetProjectData")]
        public void PutProjectNullCheck(Project pro)
        {

        }

        [Test, TestCaseSource("GetProjectData")]
        public void DeleteProject(Project pro)
        {

        }

        [Test, TestCaseSource("GetProjectData")]
        public void DeleteProjectNullCheck(Project pro)
        {

        }









    }
}
