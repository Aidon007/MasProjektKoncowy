using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.Models
{
    public class AplikacjaMobilna : Projekt
    {
        public TypAplikacji TypAplikacji { get; set; }
    }

    public enum TypAplikacji
    {
        Android,
        IOS
    }
}
