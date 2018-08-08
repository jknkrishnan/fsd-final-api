using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBench;
using System.Net.Http;
using System.Web.Http.Hosting;
using System.Web.Http;
using ProjectManagement_API.Controllers;

namespace ProjectManagement_APITestsAPI.Performance
{
    public class Performace
    {
        private const string parentCounterName = "Performance Test";
        private Counter parentCounter;
        private int key;
        private const int AcceptableMinAddThroughput = 100;
        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            parentCounter = context.GetCounter(parentCounterName);
            key = 0;
        }

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput, RunTimeMilliseconds = 600000, TestMode = TestMode.Measurement)]
        [CounterMeasurement(parentCounterName)]
        [CounterThroughputAssertion(parentCounterName, MustBe.GreaterThan, AcceptableMinAddThroughput)]
        public void UserGetBenchMark(BenchmarkContext context)
        {
            UserController usr = new UserController();
            usr.Request = new HttpRequestMessage();
            usr.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            usr.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage http;
            http = usr.Get();
            parentCounter.Increment();
        }
    }
}
