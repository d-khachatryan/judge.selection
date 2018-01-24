using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.UI;
using stvsystem.Data;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace stvsystem.Controllers
{
    public class SummaryController : Controller
    {
        StvContext _db;
        SelectionService service;

        public SummaryController(StvContext db)
        {
            _db = db;
            service = new SelectionService(_db);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult GetSummary([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                DataSourceResult result = service.GetResults().ToDataSourceResult(request);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }

        }
    }
}