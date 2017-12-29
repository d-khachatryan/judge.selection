using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stvsystem.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace stvsystem.Controllers
{
    public class CourtController : Controller
    {
        CourtService service;
        StvContext db;

        public CourtController(StvContext context)
        {
            db = context;
            service = new CourtService();
        }

        public JsonResult CourtList()
        {
            return Json(service.GetCourts());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CourtSelect([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetCourts().ToDataSourceResult(request));
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CourtCreate([DataSourceRequest] DataSourceRequest request, CourtItem courtItem)
        {
            if (courtItem != null && ModelState.IsValid)
            {
                service.CreateCourt(courtItem);
            }
            return Json(new[] { courtItem }.ToDataSourceResult(request, ModelState));
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CourtUpdate([DataSourceRequest] DataSourceRequest request, CourtItem courtItem)
        {
            if (courtItem != null && ModelState.IsValid)
            {
                service.UpdateCourt(courtItem);
            }
            return Json(new[] { courtItem }.ToDataSourceResult(request, ModelState));
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CourtDelete([DataSourceRequest] DataSourceRequest request, CourtItem courtItem)
        {
            if (courtItem != null)
            {
                service.DeleteCourt(courtItem);
            }
            return Json(new[] { courtItem }.ToDataSourceResult(request, ModelState));
        }
    }
}