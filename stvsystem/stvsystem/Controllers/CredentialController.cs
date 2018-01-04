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
    public class CredentialController : Controller
    {
        CredentialService service;
        SettingService settingService;
        StvContext db;

        public CredentialController(StvContext context)
        {
            db = context;
            service = new CredentialService();
            settingService = new SettingService();
        }

        public IActionResult Index()
        {
            if(db.Settings.Count() != 0) {
                var setting = db.Settings.First();
                return View(setting);
            }
            else
            {
                return View();
            }
        }

        public ActionResult FilterCredential([DataSourceRequest]DataSourceRequest request, string password, string idStr)
        {
            DataSourceResult result = service.Search(password, idStr).ToDataSourceResult(request);
            return Json(result);
        }

        public IActionResult Detail(string start, string end)
        {
            IList<CredentialItem> credentials = service.Details(start, end);
            Task<SettingItem> setting = settingService.GetLatestSetting();
            ViewBag.Setting = setting.Result;
            //ViewBag.Setting = db.Settings.Last();
            return View(credentials);
        }

        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        [HttpPost ]
        public IActionResult Export()
        {
            return View();
        }
    }
}