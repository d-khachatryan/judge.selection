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
    public class CourtController : Controller
    {
        StvContext _db;
        CourtService service;        

        public CourtController(StvContext db)
        {
            _db = db;
            service = new CourtService(_db);
        }

        public IActionResult Index()
        {
            OrganizeViewBugs(_db);
            return View();
        }

        public ActionResult FilterCourt([DataSourceRequest]DataSourceRequest request, string name, string type)
        {
            DataSourceResult result = service.Search(name, type).ToDataSourceResult(request);
            return Json(result);
        }

        public IActionResult Template(int? courtID = null)
        {
            OrganizeViewBugs(_db);
            try
            {
                var item = service.GetCourt(courtID);
                if (item == null)
                {
                    //return this.ErrorHandler(service.ServiceException);
                }
                return View("Template", item);
            }
            catch (Exception ex)
            {
                //return this.ErrorHandler(ex);
                return Json(ex);
            }
        }

        [HttpPost]
        public IActionResult Save(CourtItem item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (item.CourtID == null)
                    {
                        item = service.InsertCourt(item);
                    }
                    else
                    {
                        item = service.UpdateCourt(item);
                    }
                    return RedirectToAction("Index", "Court");
                }
                else
                {
                    return View("Template", item);
                }
            }
            catch (Exception ex)
            {
                //return this.ErrorHandler(ex);
                return Json(ex);
            }
        }

        public IActionResult DeleteConfirmation(int courtID)
        {
            var item = service.GetCourt(courtID);
            return View("DeleteConfirmation", item);
        }

        public IActionResult Delete(int id)
        {
            service.DeleteCourt(id);
            return RedirectToAction("Index", "Court");
        }

        private void OrganizeViewBugs(StvContext db)
        {
            var lCourtTypes = new List<SelectListItem>();
            lCourtTypes = db.CourtTypes.Select(x => new SelectListItem { Text = x.CourtTypeName, Value = x.CourtTypeID.ToString() }).ToList();
            ViewBag.vbCourtTypes = lCourtTypes;
        }
    }
}