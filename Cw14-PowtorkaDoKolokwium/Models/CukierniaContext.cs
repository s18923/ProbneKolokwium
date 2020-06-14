using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw14_PowtorkaDoKolokwium.Models
{
    public class CukierniaContext : DbContext
    {
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<WyrobCukierniczy> WyrobyCukiernicze { get; set; }
        public DbSet<Zamowienie_WyrobCukierniczy> Zamówienia_WyrobyCukiernicze { get; set; }


        public CukierniaContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>()
           .HasKey(e => new { e.IdWyrobu, e.IdZamowienia });


        }
    }
}
