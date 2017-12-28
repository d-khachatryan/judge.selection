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
    public class JudgeController : Controller
    {
        JudgeService service;
        StvContext db;

        public JudgeController(StvContext context)
        {
            db = context;
            service = new JudgeService();
        }


        public IActionResult Index()
        {
            return View();
        }

        public ActionResult FilterJudge([DataSourceRequest]DataSourceRequest request, string firstName, string lastName)
        {
            //ViewBag.ScreenWidth = Request.Browser.ScreenPixelsWidth;
            //var judgeSearch = new JudgeItem { FirstName = firstName, LastName = lastName };
            //Session["judgeSearch"] = judgeSearch;
            DataSourceResult result = service.SearchJudges(firstName, lastName).ToDataSourceResult(request);
            return Json(result);
        }

        public IActionResult Template(int? judgeID = null)
        {
            OrganizeViewBugs(db);
            try
            {
                var item = service.GetJudge(judgeID);
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
        public IActionResult Save(JudgeItem item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (item.JudgeID == null)
                    {
                        item = service.InsertJudge(item);
                    }
                    else
                    {
                        item = service.UpdateJudge(item);
                    }

                    //if (item.ResidentDestinationType == ResidentDestinationTypes.ResidentList)
                    //{
                    //    //Simply go to Rresident
                    return RedirectToAction("Index", "Judge");
                    //}
                    //else
                    //{
                    //    //Go to Issue data enty to continue wisard
                    //    return RedirectToAction("Template", "Issue", new { residentID = item.ResidentID, consultationType = item.ConsultationType });
                    //}
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

        public IActionResult DeleteConfirmation(int judgeID)
        {
            var item = service.GetJudge(judgeID);
            return View("DeleteConfirmation", item);
        }

        //[HttpPost]
        public IActionResult Delete(int id)
        {
            service.DeleteJudge(id);
            //return View();
            return RedirectToAction("Index", "Judge");
        }

        private void OrganizeViewBugs(StvContext db)
        {
            var lGenders = new List<SelectListItem>();
            lGenders = db.Genders.Select(x => new SelectListItem { Text = x.GenderName, Value = x.GenderID.ToString() }).ToList();
            ViewBag.vbGenders = lGenders;

            var lCourts = new List<SelectListItem>();
            lCourts = db.Courts.Select(x => new SelectListItem { Text = x.CourtName, Value = x.CourtID.ToString() }).ToList();
            ViewBag.vbCourts = lCourts;

            var lSpecializations = new List<SelectListItem>();
            lSpecializations = db.Specializations.Select(x => new SelectListItem { Text = x.SpecializationName, Value = x.SpecializationID.ToString() }).ToList();
            ViewBag.vbSpecializations = lSpecializations;
        }
    }
}