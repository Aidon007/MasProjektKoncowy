using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.Models
{
    public abstract class Pracownik
    {
        [Key]
        public int OsobaId { get; set; }
        [Display(Name = "Numer")]
        [MaxLength(40)]
        public int Numer { get; set; }
        [Display(Name = "Data Zatrudnienia")]
        public DateTime DataZatrudnienia { get; set; }
        [Display(Name = "Data Zwolnienia")]
        public DateTime? DataZwolnienia { get; set; }
        [Display(Name = "Specjalizacja")]
        [MaxLength(40)]
        public string Specjalizacja { get; set; }
        [Display(Name = "Pensja")]
        public double Pensja { get; set; }

    }
}
