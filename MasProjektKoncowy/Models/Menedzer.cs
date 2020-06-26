using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.Models
{
    public class Menedzer : Pracownik
    {
        public ICollection<Projekt> Projekty { get; set; }
    }
}
