using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stvsystem.Data;

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

        [HttpPost]
        public IActionResult SaveSetting()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteSetting()
        {
            return View();
        }

        public IActionResult Initialize()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StartSelection()
        {
            return View();
        }
    }
}