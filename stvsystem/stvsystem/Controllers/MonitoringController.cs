﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace stvsystem.Controllers
{
    public class MonitoringController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Complete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConfirmComplete()
        {
            return View();
        }
    }
}