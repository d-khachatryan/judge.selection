using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace stvsystem.Controllers
{
    public class SettingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Template()
        {
            return View();
        }

        public IActionResult Initialize()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConfirmInitialization()
        {
            return View();
        }
    }
}