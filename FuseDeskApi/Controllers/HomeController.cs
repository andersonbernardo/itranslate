using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FuseDeskApi.Models;
using FuseDeskApi.Repository;
using FuseDeskApi.Application;
using FuseDeskApi.Helper;

namespace FuseDeskApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFuseDeskAppService _fuseDeskAppService;

        public HomeController(IFuseDeskAppService fuseDeskAppService)
        {
            _fuseDeskAppService = fuseDeskAppService;
        }

        public IActionResult Index()
        {            
            return View("Tickets", new ApiFilter { Limit = 150 });
        }

        [HttpPost]
        public async Task<IActionResult> Tickets(ApiFilter model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _fuseDeskAppService.ObterTickets(model);

                    return ExportCsvHelper.GetCsv(result, $"tickets-{DateTime.Now.ToString("dd-MM-yyyy-hh:mm")}");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }
    }
}
