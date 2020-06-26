using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.Models
{
    public class Osoba
    {
        [Key]
        public int OsobaId { get; set; }
        [Display(Name = "Imie")]
        [MaxLength(25)]
        public string Imie { get; set; }
        [Display(Name = "Nazwisko")]
        [MaxLength(25)]
        public string Nazwisko { get; set; }
        [Display(Name = "Login")]
        [MaxLength(25)]
        public string Login { get; set; }
        [Display(Name = "Haslo")]
        [MaxLength(50)]
        public string Haslo { get; set; }

        public Klient Klient { get; set; }
        public Pracownik Pracownik { get; set; }

    }
}
