using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.Models
{
    public class AplikacjaKomputerowa : Projekt
    {
        public TypSystemu TypSystemu { get; set; }
    }

    public enum TypSystemu
    {
        Windows,
        Linux,
        MacOS
    }
}
