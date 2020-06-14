using Cw14_PowtorkaDoKolokwium.DTOs.Requests;
using Cw14_PowtorkaDoKolokwium.DTOs.Responses;
using Cw14_PowtorkaDoKolokwium.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw14_PowtorkaDoKolokwium.Services
{
    public class DbService : IDbService
    {
        CukierniaContext context;
        public DbService(CukierniaContext context)
        {
            this.context = context;
        }

        public List<ZamowieniaResponse> GetOrderListWithName(string nazwisko)
        {
            List<ZamowieniaResponse> list = new List<ZamowieniaResponse>();
            
                var klient = context.Klienci.FirstOrDefault(e => e.Nazwisko == nazwisko);
                var idZamowieniaKlienta = from K in context.Klienci
                                         join Z in context.Zamowienia on K.IdKlient equals Z.IdKlient
                                         where K.Nazwisko == nazwisko
                                         select Z.IdZamowienia;
                var listaIdZamowien = idZamowieniaKlienta.ToList();

                foreach (var item in listaIdZamowien)
                {
                    var szukaneZamowienie = context.Zamowienia.FirstOrDefault(e => e.IdZamowienia == item);

                    var wynik = from Z in context.Zamowienia
                                join ZW in context.Zamówienia_WyrobyCukiernicze on Z.IdZamowienia equals ZW.IdZamowienia
                                join W in context.WyrobyCukiernicze on ZW.IdWyrobu equals W.IdWyrobu
                                where Z.IdZamowienia == szukaneZamowienie.IdZamowienia
                                select W.Nazwa;
                    var r = wynik.ToList();

                    var tmp = new ZamowieniaResponse()
                    {
                        IdZamowienia = item,
                        IdKlient = klient.IdKlient,
                        IdPracownik = szukaneZamowienie.IdPracownik,
                        DataPrzyjecia = szukaneZamowienie.DataPrzyjecia,
                        DataRealizacji = szukaneZamowienie.DataRealizacji,
                        Uwagi = szukaneZamowienie.Uwagi,
                        Zawartosc = r
                    };
                    list.Add(tmp);
                }                
            
            return list;
        }

        public List<ZamowieniaResponse> GetOrderListWithoutName()
        {
            List<ZamowieniaResponse> list = new List<ZamowieniaResponse>();

            var idZamowien = from Z in context.Zamowienia                                      
                                      select Z.IdZamowienia;
            var listaIdZamowien = idZamowien.ToList();

            foreach (var item in listaIdZamowien)
            {
                var szukaneZamowienie = context.Zamowienia.FirstOrDefault(e => e.IdZamowienia == item);

                var wynik = from Z in context.Zamowienia
                            join ZW in context.Zamówienia_WyrobyCukiernicze on Z.IdZamowienia equals ZW.IdZamowienia
                            join W in context.WyrobyCukiernicze on ZW.IdWyrobu equals W.IdWyrobu
                            where Z.IdZamowienia == szukaneZamowienie.IdZamowienia
                            select W.Nazwa;
                var r = wynik.ToList();

                var tmp = new ZamowieniaResponse()
                {
                    IdZamowienia = item,
                    IdKlient = szukaneZamowienie.IdKlient,
                    IdPracownik = szukaneZamowienie.IdPracownik,
                    DataPrzyjecia = szukaneZamowienie.DataPrzyjecia,
                    DataRealizacji = szukaneZamowienie.DataRealizacji,
                    Uwagi = szukaneZamowienie.Uwagi,
                    Zawartosc = r
                };
                list.Add(tmp);
            }
            return list;
        }

        public ZamowieniaResponse AddNewOrder(int? Id, ZamowienieRequest zamowienieRequest)
        {
            if (Id == null)
            {
                return null;
            }

            //foreach (var item in zamowienieRequest.Zawartosc)
            //{
            //    if (string.IsNullOrWhiteSpace(item.Nazwa))
            //    {
            //        return null;
            //    }
            //};

            var zamowienie = new Zamowienie()
            {
                DataPrzyjecia = zamowienieRequest.DataPrzyjecia,
                DataRealizacji = zamowienieRequest.DataRealizacji,
                IdPracownik = zamowienieRequest.IdPracownik,
                Uwagi = zamowienieRequest.Uwagi,
                IdKlient = (int)Id
            };
            context.Zamowienia.Add(zamowienie);
            context.SaveChanges();

            List<string> list = new List<string>();    
            foreach (var item in zamowienieRequest.Zawartosc)
            {
                var szukaneIdWyrobu = context.WyrobyCukiernicze.FirstOrDefault(e => e.Nazwa == item.Nazwa);

                var zamowienieWyrob = new Zamowienie_WyrobCukierniczy()
                {
                    IdWyrobu = szukaneIdWyrobu.IdWyrobu,
                    Uwagi = item.Uwagi,
                    Ilosc = item.Ilosc,
                    IdZamowienia = zamowienie.IdZamowienia
                };
                context.Zamówienia_WyrobyCukiernicze.Add(zamowienieWyrob);
                list.Add(item.Nazwa);
            }
            context.SaveChanges();

            var result = new ZamowieniaResponse()
            {
                DataPrzyjecia = zamowienieRequest.DataPrzyjecia,
                DataRealizacji = zamowienieRequest.DataRealizacji,
                IdPracownik = zamowienieRequest.IdPracownik,
                Uwagi = zamowienieRequest.Uwagi,
                IdKlient = (int)Id,
                IdZamowienia = 10, // dla tstu wpisana randomowa liczba
                Zawartosc = list
            };


            return result;
        }
    }
}
