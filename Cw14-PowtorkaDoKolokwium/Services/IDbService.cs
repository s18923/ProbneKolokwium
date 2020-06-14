using Cw14_PowtorkaDoKolokwium.DTOs.Requests;
using Cw14_PowtorkaDoKolokwium.DTOs.Responses;
using Cw14_PowtorkaDoKolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw14_PowtorkaDoKolokwium.Services
{
    public interface IDbService
    {
        public List<ZamowieniaResponse> GetOrderListWithName(string nazwisko);
        public List<ZamowieniaResponse> GetOrderListWithoutName();
        public ZamowieniaResponse AddNewOrder(int? Id, ZamowienieRequest zamowienieRequest);
    }
}
