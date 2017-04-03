using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sesamit.Controllers
{
    public class OmSesamController : Controller
    {
        // GET: /<controller>/
        public IActionResult VadArSesam()
        {
            return View();
        }

        public IActionResult Handlingar()
        {
            return View();
        }

        public IActionResult Styrelsen()
        {
            return View();
        }

        public IActionResult Utskott()
        {
            return View();
        }

        public IActionResult Val()
        {
            return View();
        }

        public IActionResult Campusmassan()
        {
            return View();
        }

        public IActionResult FullmaktigeLedamoter()
        {
            return View();
        }

        public IActionResult Arkiv()
        {
            return View();
        }

        public IActionResult Vardegrund()
        {
            return View();
        }

    }
}
