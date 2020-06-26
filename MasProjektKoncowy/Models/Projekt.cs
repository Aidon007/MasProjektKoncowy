using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.Models
{
    public abstract class Projekt
    {
        [Key]
        public int ProjektId { get; set; }
        [Display(Name = "Nazwa")]
        [MaxLength(50)]
        public string Nazwa { get; set; }
        [Display(Name = "Numer")]
        [MaxLength(50)]
        public int Numer { get; set; }
        [Display(Name = "Typ projektu")]
        [MaxLength(50)]
        public string TypProjektu { get; set; }
        [Display(Name = "Opis")]
        [MaxLength(255)]
        public string Opis { get; set; }

        public int OsobaId { get; set; } 
        public Menedzer Menedzer { get; set; }
        public ICollection<TesterkoduProjekt_asoc> TesterkoduProjekt_Asocs { get; set; }
        public ICollection<ProgramistaProjekt_asoc> ProgramistaProjekt_Asocs { get; set; } //nie wolno uzywac filtrowanie-extensji, poprawic GUI(lista programistow odrazu)
    }
}
