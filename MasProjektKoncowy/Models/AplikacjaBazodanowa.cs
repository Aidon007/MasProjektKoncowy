using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.Models
{
    public class AplikacjaBazodanowa : Projekt
    {
        [Display(Name = "TypBazy")]
        [MaxLength(50)]
        public string TypBazy { get; set; }
    }
}
