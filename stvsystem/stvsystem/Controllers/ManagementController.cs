using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace stvsystem.Controllers
{
    public class ManagementController : Controller
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
        public IActionResult Save()
        {
            return View();
        }

        public IActionResult DeleteConfirmation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete()
        {
            return View();
        }
    }
}