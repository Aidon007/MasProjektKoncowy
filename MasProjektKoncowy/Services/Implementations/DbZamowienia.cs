using MasProjektKoncowy.Data;
using MasProjektKoncowy.Models;
using MasProjektKoncowy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MasProjektKoncowy.ViewModels;

namespace MasProjektKoncowy.Services.Implementations
{
    public class DbZamowienia : IDbZamowienia
    {
        private readonly ApplicationDbContext _context;

        public DbZamowienia(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<ZamowienieViewModel> GetZamowienia()
        {

            var result = (from zamowienie in _context.Zamowienia
                          join klient in _context.Klienci on zamowienie.OsobaId equals klient.OsobaId join osoba in _context.Osoby on klient.OsobaId equals osoba.OsobaId
                          select new { Zamowienia = zamowienie, Klienci = klient, Osoba = osoba })
                          .Select(p => new ZamowienieViewModel{
                                Zamowienie = p.Zamowienia,
                                Klient = p.Klienci,
                                Osoba = p.Osoba
                          }).ToList();

            return result; //result
        }

        public ZamowienieViewModel GetSzczegolyZamowienie(int ?id)
        {
            var result = (from Zamowienie in _context.Zamowienia
                          join Klient in _context.Klienci on Zamowienie.OsobaId equals Klient.OsobaId
                          join Osoba in _context.Osoby on Klient.OsobaId equals Osoba.OsobaId
                          select new { Zamowienia = Zamowienie, Klienci = Klient, Osoba = Osoba })
                          .Where(p => p.Zamowienia.ZamowienieId == id)
                          .Select(p => new ZamowienieViewModel
                          {
                              Zamowienie = p.Zamowienia,
                              Klient = p.Klienci,
                              Osoba = p.Osoba
                          }).FirstOrDefault();


            return result; //result
        }

        public ProjektViewModel GetProjekt(int? id)
        {
            var result = (from Projekt in _context.Projekty
                          join Menedzer in _context.Menedzery on Projekt.OsobaId equals Menedzer.OsobaId
                          join Osoba in _context.Osoby on Menedzer.OsobaId equals Osoba.OsobaId
                          select new { Projekt = Projekt, Menedzer = Menedzer, Osoba = Osoba })
                          .Where(p => p.Projekt.ProjektId == id)
                          .Select(p => new ProjektViewModel
                          {
                              Projekt = p.Projekt,
                              Menedzer = p.Menedzer,
                              Osoba = p.Osoba
                          }).FirstOrDefault();

            return result;
        }

        public IEnumerable<ProgramistaViewModel> GetProgramisciWProjekcie(int? id)
        {
            var result = (from Projekt in _context.Projekty
                          join PPA in _context.ProgProjectAsoc on Projekt.ProjektId equals PPA.ProjektId
                          join Programista in _context.Programisci on PPA.OsobaId equals Programista.OsobaId
                          join Osoba in _context.Osoby on Programista.OsobaId equals Osoba.OsobaId
                          select new { Projekt = Projekt, Programista = Programista, Osoba = Osoba })
                          .Where(p => p.Projekt.ProjektId == id)
                          .Select(p => new ProgramistaViewModel
                          {
                              Programista = p.Programista,
                              Osoba = p.Osoba
                          }).ToList();

            return result;
        }

        
    }
}
