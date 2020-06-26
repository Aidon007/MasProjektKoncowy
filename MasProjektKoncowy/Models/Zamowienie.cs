using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.Models
{
    public class Zamowienie
    {
        [Key]
        [Display(Name = "Zamówienia ID")]
        public int ZamowienieId { get; set; }
        [Display(Name = "Cena")]
        public double Cena { get; set; }
        public Status Status { get; set; }
        [Display(Name = "Termin planowy")]
        public DateTime PlanowyTerminRealizacji { get; set; }
        [Display(Name = "Termin zrealizowany")]
        public DateTime TerminZrealizowany { get; set; }
        public Projekt Projekt { get; set; }
        public int OsobaId { get; set; }
        public Klient Klient { get; set; }
    }
    public enum Status
    {
        zlozone,
        oczekuje_na_przydzielenie_menedzera,
        oczekuje_na_przydzielenie_programistow,
        realizowane,
        zrealizowane,
        anulowane
    }
}
