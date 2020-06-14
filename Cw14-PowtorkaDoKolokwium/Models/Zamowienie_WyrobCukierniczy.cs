using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cw14_PowtorkaDoKolokwium.Models
{
    public class Zamowienie_WyrobCukierniczy
    {
        public int IdWyrobu { get; set; }

        public int IdZamowienia { get; set; }

        public int Ilosc { get; set; }

        [MaxLength(300)]
        public string? Uwagi { get; set; }
    }
}
