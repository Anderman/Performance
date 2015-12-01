// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading;
using Benchmarks.Framework;

namespace Microbenchmarks.Tests
{
    public class CalibrationTests : BenchmarkTestBase
    {
        [Benchmark]
        public void Calibration_100ms()
        {
            using (Collector.StartCollection())
            {
                Thread.Sleep(100);
            }
        }

        [Benchmark]
        public void Calibration_100ms_controlled()
        {
            Thread.Sleep(100);
            using (Collector.StartCollection())
            {
                Thread.Sleep(100);
            }
        }
    }
}

