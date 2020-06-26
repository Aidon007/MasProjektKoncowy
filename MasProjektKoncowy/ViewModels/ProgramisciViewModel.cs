using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.ViewModels
{
    public class ProgramisciViewModel
    {
        public ProjektViewModel Projekt {get; set;}
        public List<ProgramistaViewModel> Programisci { get; set; }
    }
}
