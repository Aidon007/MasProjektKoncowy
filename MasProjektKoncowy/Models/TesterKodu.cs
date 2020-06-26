using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.Models
{
    public class TesterKodu : Pracownik
    {
        public ICollection<TesterkoduProjekt_asoc> TesterkoduProjekt_Asocs { get; set; }
    }
}
