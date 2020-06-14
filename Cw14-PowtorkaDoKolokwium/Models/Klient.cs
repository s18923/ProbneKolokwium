using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cw14_PowtorkaDoKolokwium.Models
{
    public class Klient
    {
        [Key]
        public int IdKlient { get; set; }

        [MaxLength(50)]

        public string Imie { get; set; }

        [MaxLength(60)]

        public string Nazwisko { get; set; }
    }
}
