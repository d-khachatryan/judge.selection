using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stvsystem.Data;

namespace stvsystem.Controllers
{
    public class MonitoringController : Controller
    {
        CredentialService credentialService;
        SettingService settingService;
        public MonitoringController()
        {
            credentialService = new CredentialService();
            settingService = new SettingService();
        }
        public IActionResult Index()
        {
            Task<SettingItem> item = settingService.GetLatestSetting();
            return View(item.Result);
        }

        public ActionResult GetCredentialStatistics()
        {
            var data = credentialService.GetCredentialStatistics();
            return Json(data);
        }

        public IActionResult Complete()
        {
            Task<SettingItem> item = settingService.GetLatestSetting();
            return View(item.Result);
        }

        [HttpPost]
        public async Task<IActionResult> FinishSelection()
        {
            bool result = await settingService.FinishSelection();
            if (result)
            {
                Task<SettingItem> item = settingService.GetLatestSetting();
                return View("Index", item.Result);                
            }
            else
            {
                Task<SettingItem> item = settingService.GetLatestSetting();
                return View("Complete", item.Result);
            }
        }
    }
}