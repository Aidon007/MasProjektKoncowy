using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.Models
{
    public class Programista : Pracownik
    {
        public ICollection<ProgramistaProjekt_asoc> ProgramistaProjekt_Asocs { get; set; }
    }
}
