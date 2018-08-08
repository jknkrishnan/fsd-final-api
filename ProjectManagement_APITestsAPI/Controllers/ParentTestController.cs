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
    public class ParentTestController
    {
        public static IEnumerable GetParentData
        {
            get
            {
                string FileLoc = @"TestData\Parent.json";
                string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "").Replace("\\bin\\Debug", "");

                var jsonText = File.ReadAllText(Path.Combine(FilePath, FileLoc));
                var parent = JsonConvert.DeserializeObject<Parent>(jsonText);
                yield return parent;
            }
        }

        [Test, TestCaseSource("GetParentData")]
        public void GetParent(Parent pro)
        {
            var context = new TaskTestContext();
            context.Parent.Add(pro);
            ParentController controller = new ParentController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Get();
            Assert.AreEqual(HttpStatusCode.OK, http.StatusCode);
        }

        [Test, TestCaseSource("GetParentData")]
        public void GetParentNullCheck(Parent pro)
        {

        }
        [Test, TestCaseSource("GetParentData")]
        public void GetParentByID(Parent pro)
        {
            var context = new TaskTestContext();
            context.Parent.Add(pro);
            ParentController controller = new ParentController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Get(pro.Parent_Id);
            Assert.AreEqual(HttpStatusCode.OK, http.StatusCode);
            var response = http.Content.ReadAsStringAsync().Result
                                               .Replace("\\", "")
                                               .Trim(new char[1] { '"' });
            List<Parent> _list = JsonConvert.DeserializeObject<List<Parent>>(response);
            Assert.IsNotNull(_list);
            Assert.AreEqual(pro.Parent_Id, _list[0].Parent_Id);

        }

        [Test, TestCaseSource("GetParentData")]
        public void GetParentByIDNULLCheck(Parent pro)
        {
            var context = new TaskTestContext();
            context.Parent.Add(pro);
            ParentController controller = new ParentController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Get(-1);
            Assert.AreEqual(HttpStatusCode.NotFound, http.StatusCode);
        }

        [Test, TestCaseSource("GetParentData")]
        public void PostParent(Parent pro)
        {
            var context = new TaskTestContext();
            context.Parent.Add(pro);
            ParentController controller = new ParentController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Post(pro);
            Assert.AreEqual(HttpStatusCode.Created, http.StatusCode);
            var response = http.Content.ReadAsStringAsync().Result
                                               .Replace("\\", "")
                                               .Trim(new char[1] { '"' });
            List<Parent> _list = JsonConvert.DeserializeObject<List<Parent>>(response);
            Assert.IsNotNull(_list);
            Assert.AreEqual(pro.Parent_Task, _list[0].Parent_Task);            
        }

        [Test, TestCaseSource("GetParentData")]
        public void PostParentNullCheck(Parent pro)
        {
            var context = new TaskTestContext();
            context.Parent.Add(pro);
            ParentController controller = new ParentController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Post(null);
            Assert.AreEqual(HttpStatusCode.Conflict, http.StatusCode);
        }

        [Test, TestCaseSource("GetParentData")]
        public void PutParent(Parent pro)
        {
            var context = new TaskTestContext();
            context.Parent.Add(pro);
            ParentController controller = new ParentController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Put(pro.Parent_Id, pro);
            Assert.AreEqual(HttpStatusCode.Created, http.StatusCode);
            var response = http.Content.ReadAsStringAsync().Result
                                               .Replace("\\", "")
                                               .Trim(new char[1] { '"' });
            List<Parent> _list = JsonConvert.DeserializeObject<List<Parent>>(response);
            Assert.IsNotNull(_list);
            Assert.AreEqual(pro.Parent_Task, _list[0].Parent_Task);            
            Assert.AreEqual(pro.Project_Id, _list[0].Project_Id);
            Assert.AreEqual(pro.Parent_Id, _list[0].Parent_Id);
        }

        [Test, TestCaseSource("GetParentData")]
        public void PutParentNullCheck(Parent pro)
        {
            var context = new TaskTestContext();
            context.Parent.Add(pro);
            ParentController controller = new ParentController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Put(-1, pro);
            Assert.AreEqual(HttpStatusCode.Conflict, http.StatusCode);
        }

        [Test, TestCaseSource("GetParentData")]
        public void DeleteParent(Parent pro)
        {
            var context = new TaskTestContext();
            context.Parent.Add(pro);
            ParentController controller = new ParentController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Delete(pro.Parent_Id);
            Assert.AreEqual(HttpStatusCode.OK, http.StatusCode);
            var response = http.Content.ReadAsStringAsync().Result
                                               .Replace("\\", "")
                                               .Trim(new char[1] { '"' });
            Assert.AreEqual(pro.Parent_Id.ToString(), response);
        }

        [Test, TestCaseSource("GetParentData")]
        public void DeleteParentNullCheck(Parent pro)
        {
            var context = new TaskTestContext();
            context.Parent.Add(pro);
            ParentController controller = new ParentController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Delete(-1);
            Assert.AreEqual(HttpStatusCode.Conflict, http.StatusCode);
        }
    }
}
