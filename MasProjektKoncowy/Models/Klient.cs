using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.Models
{
    public class Klient
    {
        [Key]
        public int OsobaId { get; set; }
        public ICollection<Zamowienie> Zamowienia { get; set; }
    }
}
