// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Benchmarks.Framework
{
    public abstract class BenchmarkTestBase
    {
        public IMetricCollector Collector { get; set; } = new NullMetricCollector();
    }
}
