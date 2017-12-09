using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace stvsystem.Controllers
{
    public class CredentialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}