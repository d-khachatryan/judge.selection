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
    public class CandidateController : Controller
    {
        CandidateService service;
        StvContext db;

        public CandidateController(StvContext context)
        {
            db = context;
            service = new CandidateService();
        }


        public IActionResult Index()
        {
            return View();
        }

        public ActionResult FilterCandidate([DataSourceRequest]DataSourceRequest request, string firstName, string lastName)
        {
            //ViewBag.ScreenWidth = Request.Browser.ScreenPixelsWidth;
            //var candidateSearch = new CandidateItem { FirstName = firstName, LastName = lastName };
            //Session["candidateSearch"] = candidateSearch;
            DataSourceResult result = service.SearchCandidates(firstName, lastName).ToDataSourceResult(request);
            return Json(result);
        }

        public IActionResult Template(int? candidateID = null)
        {
            OrganizeViewBugs(db);
            try
            {
                var item = service.GetCandidate(candidateID);
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
        public IActionResult Save(CandidateItem item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (item.CandidateID == null)
                    {
                        item = service.InsertCandidate(item);
                    }
                    else
                    {
                        item = service.UpdateCandidate(item);
                    }

                    //if (item.ResidentDestinationType == ResidentDestinationTypes.ResidentList)
                    //{
                    //    //Simply go to Rresident
                    return RedirectToAction("Index", "Candidate");
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

        public IActionResult DeleteConfirmation(int candidateID)
        {
            var item = service.GetCandidate(candidateID);
            return View("DeleteConfirmation", item);
        }

        //[HttpPost]
        public IActionResult Delete(int id)
        {
            service.DeleteCandidate(id);
            //return View();
            return RedirectToAction("Index", "Candidate");
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