using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MasProjektKoncowy.Models;
using MasProjektKoncowy.Services.Interfaces;

namespace MasProjektKoncowy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbZamowienia _dbZamowienia;

        public HomeController(IDbZamowienia dbZamowienia)
        {
            this._dbZamowienia = dbZamowienia;
        }

        public IActionResult Index()
        {
            var result = _dbZamowienia.GetZamowienia();
            return View(result);
        }

        public IActionResult Privacy()
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
