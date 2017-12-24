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
        SelectionService selectionService;
        public SelectionController()
        {
            candidateService = new CandidateService();
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
        public async Task<IActionResult> CandidateSelection(PasswordItem item)
        {
            SelectionService service = new SelectionService();

            if (service.ValidatePassword(item) == PasswordStatus.Success)
            {
                InitializeViewBugs();
                SelectionItem selectionItem = new SelectionItem { Password = item.Password, CandidateCount = await candidateService.Count() };
                return View("CandidateSelection", selectionItem);
            }
            else
            {
                ModelState.AddModelError("wrongpassword", "Password is wrong");
                item.Password = String.Empty;
                return View("Index", item);
            }

        }

        // this action runs in the CandidateSelection page as a POST action
        [HttpPost]
        public IActionResult SelectionConfirmation(SelectionItem selectionItem)
        {
            selectionService.SaveSelection(selectionItem);
            if (selectionItem != null)
            {
                PasswordItem passwordItem = new PasswordItem
                {
                    Status = PasswordStatus.Initialization
                };
                return View("Index", passwordItem);
            }
            else
            {
                InitializeViewBugs();
                return View("CandidateSelection", selectionItem);
            }
        }

        private void InitializeViewBugs()
        {
            ViewBag.vbCandidates = candidateService.GetCandidateDropDownItems();
        }
    }
}