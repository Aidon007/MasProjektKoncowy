using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.Models
{
    public class TesterkoduProjekt_asoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TesterkoduProjektId { get; set; }

        public int OsobaId { get; set; }
        public TesterKodu TesterKodu { get; set; }

        public int ProjektId { get; set; }
        public Projekt Projekt { get; set; }
    }
}