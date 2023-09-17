using BOSSAProje.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;


namespace BOSSAProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public IActionResult CagriGiris(Cihaz cihaz)
        {
            //string serinogecici= db.Database.
            return RedirectToAction("GetCihaz", "Cihazlar");
            // return View();
        }
        public IActionResult CagriGiris()
        {
            return View();
        }
        public IActionResult LoginPage()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AdminPage()
        {
            return View();
        }
            public IActionResult Giris()
        {
            return View();
        }
        public IActionResult EskiCagrilar()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}