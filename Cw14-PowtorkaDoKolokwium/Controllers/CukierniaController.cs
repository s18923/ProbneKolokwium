using Cw14_PowtorkaDoKolokwium.DTOs.Requests;
using Cw14_PowtorkaDoKolokwium.Models;
using Cw14_PowtorkaDoKolokwium.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw14_PowtorkaDoKolokwium.Controllers
{
    [Route("api/cukiernia")]
    public class CukierniaController : ControllerBase
    {
        private IDbService service;
        public CukierniaController(IDbService service)
        {
            this.service = service;
        }

        [HttpGet("{nazwisko}")]
        public IActionResult GetOrderListWithName(string nazwisko)
        {
                var result = service.GetOrderListWithName(nazwisko);
                return Ok(result);
        }

        [HttpGet]
        public IActionResult GetOrderListWithoutName()
        {
                var result = service.GetOrderListWithoutName();
                return Ok(result);          
        }

        [HttpPost("{Id}")]
        public IActionResult AddNewOrder(int Id, ZamowienieRequest zamowienieRequest)
        {
            if (service.AddNewOrder(Id, zamowienieRequest) == null)
            {
                return BadRequest("Podany klient lub produkt nie istnieje!");
            }           
            return Ok("Zamowienie zostało złozone!");
        }
    }
}
