using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stvsystem.Data;

namespace stvsystem.Controllers
{
    public class SettingController : Controller
    {
        SettingService settingService;
        public SettingController()
        {
            settingService = new SettingService();
        }

        public IActionResult Index()
        {
            Task<SettingItem> item = settingService.GetLatestSetting();
            return View(item.Result);
        }

        public IActionResult InitInsert()
        {
            SettingItem item = new SettingItem
            {
                SettingID = -1,
                SelectionStatus = SettingStatus.InPreparation
            };
            return View("Template", item);
        }

        public IActionResult InitUpdate()
        {
            Task<SettingItem> item = settingService.GetLatestSetting();
            return View("Template", item.Result);
        }

        [HttpPost]
        public IActionResult SaveSetting(SettingItem item)
        {
            if (item.SettingID == -1)
            {
                item = settingService.InsertSetting(item);
            }
            else
            {
                item = settingService.UpdateSetting(item);
            }
            return View("Index", item);
        }

        public IActionResult Delete()
        {
            Task<SettingItem> newItem = settingService.GetLatestSetting();
            return View(newItem.Result);
        }

        [HttpPost]
        public IActionResult DeleteSetting(SettingItem item)
        {
            settingService.DeleteSetting(item);
            Task<SettingItem> newItem = settingService.GetLatestSetting();
            return View("Index",newItem.Result);
        }

        public IActionResult Initialize()
        {
            Task<SettingItem> item = settingService.GetLatestSetting();
            return View("Initialize",item.Result);
        }

        [HttpPost]
        public IActionResult StartSelection()
        {
            Task<SettingItem> item = settingService.GetLatestSetting();
            item.Result.SelectionStatus = SettingStatus.InProcess;
            settingService.UpdateSetting(item.Result);
            return View("Index", item.Result);
        }
    }
}