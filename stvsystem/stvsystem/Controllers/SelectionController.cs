using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stvsystem.Data;

namespace stvsystem.Controllers
{
    public class SelectionController : Controller
    {
        CandidateService candidateService;
        CredentialService credentialService;
        SelectionService selectionService;
        public SelectionController()
        {
            candidateService = new CandidateService();
            credentialService = new CredentialService();
            selectionService = new SelectionService();
        }

        public IActionResult Index()
        {
            PasswordItem item = new PasswordItem
            {
                Status = PasswordStatus.Initialization
            };
            return View("Index", item);

        }

        // this action runs in the Index page as a POST action
        [HttpPost]
        public async Task<IActionResult> SelectCandidates(PasswordItem item)
        {
            SelectionService service = new SelectionService();
            var passwordStatus = service.ValidatePassword(item);
            if (passwordStatus == PasswordStatus.Success)
            {
                InitializeViewBugs();
                SelectionItem selectionItem = new SelectionItem { Password = item.Password, CandidateCount = await candidateService.Count() };
                return View("SelectCandidates", selectionItem);
            }
            else if (passwordStatus == PasswordStatus.DoubleLogin )
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

        // this action runs in the SelectCandidates page as a POST action
        [HttpPost]
        public IActionResult ConfirmSelection(SelectionItem selectionItem)
        {
            var item = selectionService.FillSelectionItemNames(selectionItem);
            return View("ConfirmSelection", item);
        }

        // this action runs in the ConfirmSeletion page as a POST action
        [HttpPost]
        public IActionResult SaveSelection(SelectionItem selectionItem)
        {
            var operationResult = selectionService.SaveSelection(selectionItem, credentialService);
            PasswordItem passwordItem = new PasswordItem
            {
                Status = PasswordStatus.Initialization
            };
            return RedirectToAction("Index", "Selection");
        }

        private void InitializeViewBugs()
        {
            ViewBag.vbCandidates = candidateService.GetCandidateDropDownItems();
        }
    }
}