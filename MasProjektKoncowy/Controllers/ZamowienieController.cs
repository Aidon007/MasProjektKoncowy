using MasProjektKoncowy.Services.Interfaces;
using MasProjektKoncowy.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.Views.Shared.Zamowienie.Controllers
{
    public class ZamowienieController : Controller
    {
        //W KLASIE PROJEKT POPRAWIC ZEBY BYLO Projekt.ProgProjektasoc

        private readonly IDbZamowienia _dbZamowienia;
        public ZamowienieController(IDbZamowienia dbZamowienia)
        {
            this._dbZamowienia = dbZamowienia;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_dbZamowienia.GetZamowienia());
        }

        [HttpGet]
        [Route("Zamowienie/{id}", Name = "Szczegoly")]
        public IActionResult Szczegoly(int ?id)
        {
            if(id == null) {
                return Index();
            }

            return View(_dbZamowienia.GetSzczegolyZamowienie(id));
        }

        [HttpGet]
        [Route("Zamowienie/InfoProjekt/{id}", Name = "InfoProjekt")]
        public IActionResult ProjektyWZamowieniach(int? id)
        {
            if (id == null)
            {
                return Index();
            }

            return View(_dbZamowienia.GetProjekt(id));
        }

        [HttpGet]
        [Route("Zamowienie/InfoProgramisci/{id}", Name = "InfoProgramisci")]
        public IActionResult ProgramisciWProjektach(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var project = _dbZamowienia.GetProjekt(id);
            
            var programisci = _dbZamowienia.GetProgramisciWProjekcie(id).ToList();
            var result = new ProgramisciViewModel { Projekt = project, Programisci = programisci };

            return View(result);
        }
    }
}
