using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benchmarks.Framework;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;

namespace Microbenchmarks.Tests
{
    public class HostingTests : BenchmarkTestBase
    {
        [Benchmark]
        public void MainToConfigureOverhead()
        {
            var args = new string[0];

            using (Collector.StartCollection())
            {
                TestStartup.Main(args);
            }
        }

        private class TestStartup
        {
            public void Configure(IApplicationBuilder app)
            {

                // Stop
            }

            public static void Main(string[] args) => WebApplication.Run<TestStartup>(args);
        }
    }
}
