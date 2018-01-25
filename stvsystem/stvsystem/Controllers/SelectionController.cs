using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using stvsystem.Data;

namespace stvsystem.Controllers
{
    public class SelectionController : Controller
    {
        StvContext _db;
        CandidateService candidateService;
        CredentialService credentialService;
        SelectionService selectionService;
        SettingService settingService;
        CourtService courtService;

        public SelectionController(StvContext db)
        {
            _db = db;
            candidateService = new CandidateService(db);
            credentialService = new CredentialService(db);
            selectionService = new SelectionService(db);
            settingService = new SettingService(db);
            courtService = new CourtService(db);
        }

        public JsonResult GetCourts()
        {
            var result = courtService.GetCourtDropDownItems();
            return Json(result);
        }

        public JsonResult GetCandidates(int? courtID, string candidateName, int credentialID)
        {
            var result = candidateService.GetFilteredCandidateDropDownItems(courtID, candidateName, credentialID);
            return Json(result);
        }

        public IActionResult Index()
        {
            PasswordItem item = new PasswordItem
            {
                Status = PasswordStatus.Initialization
            };
            return View("Index", item);

        }

        [HttpPost]
        public IActionResult VerifyPassword(PasswordItem item)
        {
            var passwordStatus = selectionService.ValidatePassword(item);

            if (passwordStatus == PasswordStatus.Success)
            {
                InitializeViewBugs();
                int? credentialID = credentialService.GetCredentialIDByPassword(item.Password);
                return RedirectToAction("SelectCandidate", "Selection", new { credentialID = credentialID, candidateIndex = 1 });
            }
            else if (passwordStatus == PasswordStatus.DoubleLogin)
            {
                ModelState.AddModelError("doublepassword", "Այս ծածկագիրը արդեն կիրառվել է ընտրություն իրականացնելու համար:");
                item.Password = String.Empty;
                return View("Index", item);
            }
            else
            {
                ModelState.AddModelError("wrongpassword", "Ծածկագիրը սխալ է");
                item.Password = String.Empty;
                return View("Index", item);

            }
        }


        public async Task<IActionResult> SelectCandidate(int? credentialID, int candidateIndex, string submitButton)
        {

            SettingItem settingItem = await settingService.GetLatestSetting();

            SelectionItem selectionItem = new SelectionItem
            {
                CredentialID = credentialID,
                CandidateIndex = candidateIndex,
                SelectionCount = settingItem.SelectionCount
            };
            return View("SelectCandidate", selectionItem);
        }

        // this action runs in the Index page as a POST action
        [HttpPost]
        public IActionResult SaveSelectionItem(SelectionItem selectionItem, string submitButton)
        {
            bool? operationResult= null;

            if (submitButton == "Continue")
            {
                operationResult = selectionService.SaveSelectionItem(selectionItem);
                return RedirectToAction("SelectCandidate", "Selection", new { credentialID = selectionItem.CredentialID, candidateIndex = selectionItem.CandidateIndex + 1 });
            }
            else if(submitButton == "Confirm")
            {
                operationResult = selectionService.SaveSelectionItem(selectionItem);
                return RedirectToAction("ConfirmSelection", "Selection", new { credentialID = selectionItem.CredentialID });
            }
            else
            {
                operationResult = selectionService.CancelSelections((int)selectionItem.CredentialID);
                return RedirectToAction("Index", "Selection");
            }

        }

        public IActionResult ConfirmSelection(int credentialID)
        {
            List<SelectionConfirmationItem> selectionConfirmationItems = selectionService.GetSelectionConfirmationItems(credentialID);
            ViewBag.CandidateSelections = selectionConfirmationItems;

            CredentialItem credentialItem = credentialService.GetCredential(credentialID);
            return View("ConfirmSelection", credentialItem);
        }

        // this action runs in the Index page as a POST action
        [HttpPost]
        public IActionResult SaveSelections(int credentialID, string submitButton)
        {
            if (submitButton == "Confirm")
            {
                var operationResult = selectionService.SaveSelections(credentialID);
                return RedirectToAction("Index", "Selection");
            }
            else
            {
                var operationResult = selectionService.CancelSelections(credentialID);
                return RedirectToAction("Index", "Selection");
            }

            
        }

        private void InitializeViewBugs()
        {
            ViewBag.vbCandidates = candidateService.GetCandidateDropDownItems();
        }
    }
}