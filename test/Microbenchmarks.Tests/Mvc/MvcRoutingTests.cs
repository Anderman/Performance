﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Benchmarks.Framework;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace Microbenchmarks.Tests.Mvc
{
    public class MvcRoutingTests : BenchmarkTestBase
    {
        [Benchmark]
        public async Task RouteToAction()
        {
            var builder = new WebApplicationBuilder()
                .Configure(app => app.UseMvcWithDefaultRoute())
                .ConfigureServices(services => services.AddMvc());
            using (var testServer = new TestServer(builder))
            {
                using (var client = testServer.CreateClient())
                {
                    client.BaseAddress = new Uri("http://localhost");

                    using (Collector.StartCollection())
                    {
                        var result = await client.GetAsync("Home");
                        var stringResponse = await result.Content.ReadAsStringAsync();
                    }
                }
            }
        }
    }
}
