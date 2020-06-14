using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw14_PowtorkaDoKolokwium.DTOs.Requests
{
    public class ZamowienieRequest
    {
        public int IdZamowienia { get; set; }

        public DateTime DataPrzyjecia { get; set; }

        public DateTime? DataRealizacji { get; set; }

        public string? Uwagi { get; set; }

        public int IdKlient { get; set; }

        public int IdPracownik { get; set; }

        public List<WyrobRequest> Zawartosc { get; set; }
    }
}
