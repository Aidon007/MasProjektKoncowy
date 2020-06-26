using MasProjektKoncowy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.ViewModels
{
    public class ZamowienieViewModel
    {
        public Zamowienie Zamowienie { get; set; }
        public Projekt Projekt { get; set; }
        public int OsobaId { get; set; }
        public Osoba Osoba { get; set; }
        public Klient Klient { get; set; }
    }
}
