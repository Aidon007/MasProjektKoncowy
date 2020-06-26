using MasProjektKoncowy.Models;
using MasProjektKoncowy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.Services.Interfaces
{
    public interface IDbZamowienia
    {
        public IEnumerable<ZamowienieViewModel> GetZamowienia();
        public ZamowienieViewModel GetSzczegolyZamowienie(int ?id);
        public ProjektViewModel GetProjekt(int? id);
        public IEnumerable<ProgramistaViewModel> GetProgramisciWProjekcie(int? id);
    }
}
