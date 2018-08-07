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
    public class UserTestController
    {
        public static IEnumerable GetUserData
        {
            get
            {
                string FileLoc = @"TestData\User.json";
                string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "").Replace("\\bin\\Debug", "");

                var jsonText = File.ReadAllText(Path.Combine(FilePath, FileLoc));
                var user = JsonConvert.DeserializeObject<User>(jsonText);
                yield return user;
            }
        }

        [Test, TestCaseSource("GetUserData")]
        public void GetUser(User usr)
        {
            var context = new TaskTestContext();
            context.User.Add(usr);
            UserController controller = new UserController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Get();
            Assert.AreEqual(HttpStatusCode.OK, http.StatusCode);
        }

        [Test, TestCaseSource("GetUserData")]
        public void GetUser_NULLCheck(User usr)
        {

        }

        [Test, TestCaseSource("GetUserData")]
        public void GetUserByID(User usr)
        {
            var context = new TaskTestContext();
            context.User.Add(usr);
            UserController controller = new UserController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Get(usr.User_Id);
            Assert.AreEqual(HttpStatusCode.OK, http.StatusCode);
            var response = http.Content.ReadAsStringAsync().Result
                                               .Replace("\\", "")
                                               .Trim(new char[1] { '"' });
            List<User> _list = JsonConvert.DeserializeObject<List<User>>(response);
            Assert.IsNotNull(_list);
            Assert.AreEqual(usr.User_Id, _list[0].User_Id);

        }

        [Test, TestCaseSource("GetUserData")]
        public void GetUserByID_NULLCheck(User usr)
        {
            var context = new TaskTestContext();
            context.User.Add(usr);
            UserController controller = new UserController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Get(-1);
            Assert.AreEqual(HttpStatusCode.NotFound, http.StatusCode);
        }

        [Test, TestCaseSource("GetUserData")]
        public void PostUser(User usr)
        {
            var context = new TaskTestContext();
            context.User.Add(usr);
            UserController controller = new UserController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Post(usr);
            Assert.AreEqual(HttpStatusCode.Created, http.StatusCode);
            var response = http.Content.ReadAsStringAsync().Result
                                               .Replace("\\", "")
                                               .Trim(new char[1] { '"' });
            List<User> _list = JsonConvert.DeserializeObject<List<User>>(response);
            Assert.IsNotNull(_list);
            Assert.AreEqual(usr.First_Name, _list[0].First_Name);
            Assert.AreEqual(usr.Last_Name, _list[0].Last_Name);
            Assert.AreEqual(usr.Employee_Id, _list[0].Employee_Id);
        }

        [Test, TestCaseSource("GetUserData")]
        public void PostUser_NULLCheck(User usr)
        {
            var context = new TaskTestContext();
            context.User.Add(usr);
            UserController controller = new UserController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Post(null);
            Assert.AreEqual(HttpStatusCode.Conflict, http.StatusCode);
        }

        [Test, TestCaseSource("GetUserData")]
        public void PutUser(User usr)
        {
            var context = new TaskTestContext();
            context.User.Add(usr);
            UserController controller = new UserController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Put(usr.User_Id, usr);
            Assert.AreEqual(HttpStatusCode.Created, http.StatusCode);
            var response = http.Content.ReadAsStringAsync().Result
                                               .Replace("\\", "")
                                               .Trim(new char[1] { '"' });
            List<User> _list = JsonConvert.DeserializeObject<List<User>>(response);
            Assert.IsNotNull(_list);
            Assert.AreEqual(usr.First_Name, _list[0].First_Name);
            Assert.AreEqual(usr.Last_Name, _list[0].Last_Name);
            Assert.AreEqual(usr.Employee_Id, _list[0].Employee_Id);
            Assert.AreEqual(usr.User_Id, _list[0].User_Id);
        }

        [Test, TestCaseSource("GetUserData")]
        public void PuttUser_NULLCheck(User usr)
        {
            var context = new TaskTestContext();
            context.User.Add(usr);
            UserController controller = new UserController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Put(-1,null);
            Assert.AreEqual(HttpStatusCode.Conflict, http.StatusCode);

        }

        [Test, TestCaseSource("GetUserData")]
        public void DeleteUser(User usr)
        {
            var context = new TaskTestContext();
            context.User.Add(usr);
            UserController controller = new UserController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Delete(usr.User_Id);
            Assert.AreEqual(HttpStatusCode.OK, http.StatusCode);
            var response = http.Content.ReadAsStringAsync().Result
                                               .Replace("\\", "")
                                               .Trim(new char[1] { '"' });
            Assert.AreEqual(usr.User_Id.ToString(), response);
        }

        [Test, TestCaseSource("GetUserData")]
        public void DeleteUser_NULLCheck(User usr)
        {
            var context = new TaskTestContext();
            context.User.Add(usr);
            UserController controller = new UserController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            controller.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = controller.Delete(-1);
            Assert.AreEqual(HttpStatusCode.Conflict, http.StatusCode);
        }


    }
}
