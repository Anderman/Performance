﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;

namespace Microbenchmarks.Tests.Mvc
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("/Mvc/Views/Home/Index.cshtml");
        }
    }
}
