using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineClearanceWeb.Controllers
{
    public class StatictableController : Controller
    {
        public IActionResult ReportIncident()
        {
            return View();
        }

        public IActionResult Department()
        {
            return View();
        }
        public IActionResult reporterpage()
        {
            return View();
        }

        public IActionResult IncidentRecord()
        {
            return View();
        }
        public IActionResult ViewIncident()
        {
            return View();
        }
    }
}