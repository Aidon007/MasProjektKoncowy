using MasProjektKoncowy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.ViewModels
{
    public class ProjektViewModel
    {
       public Osoba Osoba { get; set; }
       public Menedzer Menedzer { get; set; }
       public Projekt Projekt { get; set; }
    }
}
