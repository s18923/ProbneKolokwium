using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cw14_PowtorkaDoKolokwium.Models
{
    public class WyrobCukierniczy
    {
        [Key]
        public int IdWyrobu { get; set; }

        [MaxLength(100)]

        public string Nazwa { get; set; }

        public float CenaZaSzt { get; set; }

        [MaxLength(40)]

        public string Typ { get; set; }
    }
}
