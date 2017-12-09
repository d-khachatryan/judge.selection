using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace stvsystem.Controllers
{
    public class SelectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CandidateSelection()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SelectionConfirmation()
        {
            return View();
        }
    }
}