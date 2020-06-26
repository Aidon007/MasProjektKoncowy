using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.Models
{
    public class ProgramistaProjekt_asoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProgramistaProjektId { get; set; }

        public int OsobaId { get; set; }
        public Programista Programista { get; set; }

        public int ProjektId { get; set; }
        public Projekt Projekt { get; set; }
    }
}
