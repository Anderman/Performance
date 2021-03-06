﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

#if DNX451
using System;
using System.Net.Http;
using Benchmarks.Framework;
using Microsoft.AspNet.Server.Testing;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Microsoft.AspNet.Tests.Performance
{
    public class IISStartup : IBenchmarkTest, IClassFixture<IISTestManager>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IISTestManager _testManager;

        public IISStartup(IISTestManager testManager)
        {
            _loggerFactory = new LoggerFactory();
            _loggerFactory.AddConsole();

            _testManager = testManager;
            _testManager.Initialize(_loggerFactory);
        }

        public IMetricCollector Collector { get; set; } = new NullMetricCollector();

        [Benchmark(Iterations = 1, WarmupIterations = 0)]
        [BenchmarkVariation("StarterMvc_IISScenario", "StarterMvc", RuntimeFlavor.Clr, Framework = "DNX.Clr")]
        [BenchmarkVariation("StarterMvc_IISScenario", "StarterMvc", RuntimeFlavor.CoreClr, Framework = "DNX.CoreClr")]
        public void IISHttpPlatformHandlerScenario(string sampleName, RuntimeFlavor runtimeFlavor)
        {
            var testName = $"{sampleName}.{runtimeFlavor}.{nameof(IISHttpPlatformHandlerScenario)}";
            var logger = _loggerFactory.CreateLogger(testName);
            var siteUrl = _testManager.GetSite(sampleName, runtimeFlavor, restart: true);
            Assert.NotNull(siteUrl);

            var client = new HttpClient();

            using (Collector.StartCollection())
            {
                var responseTask = client.GetAsync(siteUrl);
                Assert.True(responseTask.Wait(TimeSpan.FromMinutes(10)));
                logger.LogInformation($"Response {responseTask.Result.StatusCode}");
                responseTask.Result.EnsureSuccessStatusCode();
            }
        }
    }
}
#endif
