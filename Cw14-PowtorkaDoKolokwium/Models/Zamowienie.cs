using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cw14_PowtorkaDoKolokwium.Models
{
    public class Zamowienie
    {
        [Key]
        public int IdZamowienia { get; set; }

        public DateTime DataPrzyjecia { get; set; }

        public DateTime? DataRealizacji { get; set; }

        [MaxLength(100)]
        public string? Uwagi { get; set; }

        [ForeignKey("Klient")]
        public int IdKlient { get; set; }

        [ForeignKey("Pracownik")]
        public int IdPracownik { get; set; }

    }
}
