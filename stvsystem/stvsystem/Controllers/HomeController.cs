using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stvsystem.Data;

namespace stvsystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly StvContext _context;

        public HomeController(StvContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            CandidateService service = new CandidateService(_context);
            Candidate mock = new Candidate
            {
                FirstName = "FirstName",
                LastName = "LastName",
                MiddleName = "MiddleName"
            };
            service.InsertCandidate(mock);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
