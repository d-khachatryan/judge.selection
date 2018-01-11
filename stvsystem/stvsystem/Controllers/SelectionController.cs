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
        CandidateService candidateService;
        CredentialService credentialService;
        SelectionService selectionService;
        SettingService settingService;
        CourtService courtService;

        public SelectionController()
        {
            candidateService = new CandidateService();
            credentialService = new CredentialService();
            selectionService = new SelectionService();
            settingService = new SettingService();
            courtService = new CourtService();
        }

        public JsonResult GetCourts()
        {
            var result = courtService.GetCourtDropDownItems();
            return Json(result);
        }

        public JsonResult GetCandidates(int? courtID, string candidateName)
        {
            var result = candidateService.GetFilteredCandidateDropDownItems(courtID, candidateName);
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
                return RedirectToAction("SelectCandidate", "Selection", new { credentialID, candidateIndex = 1 });
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


        public async Task<IActionResult> SelectCandidate(int? credentialID, int candidateIndex)
        {
            SettingItem settingItem =  await settingService.GetLatestSetting();

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
            var operationResult = selectionService.SaveSelection(selectionItem, credentialService);
            return RedirectToAction("SelectCandidate", "Selection", new { credentialID= selectionItem.CredentialID, candidateIndex = selectionItem.CandidateIndex +1 });
        }

        public IActionResult ConfirmSelection(int credentialID)
        {
            List<SelectionConfirmationItem> selectionConfirmationItems = selectionService.GetSelectionConfirmationItems(credentialID);
            return View("ConfirmSelection", selectionConfirmationItems);
        }

        

        





        //// this action runs in the ConfirmSeletion page as a POST action
        //[HttpPost]
        //public IActionResult SaveSelection(SelectionItem selectionItem)
        //{
        //    var operationResult = selectionService.SaveSelection(selectionItem, credentialService);
        //    PasswordItem passwordItem = new PasswordItem
        //    {
        //        Status = PasswordStatus.Initialization
        //    };
        //    return RedirectToAction("Index", "Selection");
        //}

        private void InitializeViewBugs()
        {
            ViewBag.vbCandidates = candidateService.GetCandidateDropDownItems();
        }
    }
}