using MasProjektKoncowy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasProjektKoncowy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Osoba> Osoby { get; set; }
        public DbSet<Pracownik> Pracowniki { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Menedzer> Menedzery { get; set; }
        public DbSet<Programista> Programisci { get; set; }
        public DbSet<Konsultant> Konsultanci { get; set; }
        public DbSet<TesterKodu> TesteryKodu { get; set; }
        public DbSet<ProgramistaProjekt_asoc> ProgProjectAsoc { get; set; }
        public DbSet<Projekt> Projekty { get; set; }
        public DbSet<AplikacjaKomputerowa> AplikacjeKomputerowe { get; set; }
        public DbSet<AplikacjaBazodanowa> AplikacjeBazodanowe { get; set; }
        public DbSet<AplikacjaMobilna> AplikacjeMobilne { get; set; } 

        public DbSet<Zamowienie> Zamowienia { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //kompozycja zamowienie <- projekt
            //modelBuilder.Entity<Zamowienie>().OwnsOne(p => p.Projekt, od =>
            //{
            //    od.OwnsOne(c => c.);
            //    od.OwnsOne(c => c.ShippingAddress);
            //});

            //dla wyloczenia autogeneracji kluczy (ValueGeneratedNever)
            modelBuilder.Entity<Pracownik>().Property(x => x.OsobaId).ValueGeneratedNever();
            modelBuilder.Entity<Klient>().Property(x => x.OsobaId).ValueGeneratedNever();
            //polaczenia pracownika 0..1 i klienta 0..1 do osoby 1
            modelBuilder.Entity<Osoba>().HasOne(e => e.Pracownik).WithOne().HasForeignKey<Pracownik>(e => e.OsobaId).OnDelete(DeleteBehavior.Cascade); ;
            modelBuilder.Entity<Osoba>().HasOne(e => e.Klient).WithOne().HasForeignKey<Klient>(e => e.OsobaId).OnDelete(DeleteBehavior.Cascade); ;
            //polaczenia zamowienia(<>) 1 - 1 projektu
            modelBuilder.Entity<Zamowienie>()
                   .HasOne(e => e.Projekt).WithOne().HasForeignKey<Projekt>(e => e.ProjektId)
                   .OnDelete(DeleteBehavior.Cascade);
            //enum dla aplikacje
            modelBuilder.Entity<AplikacjaKomputerowa>().Property(e => e.TypSystemu)
                .HasConversion(v => v.ToString(), v => (TypSystemu)Enum.Parse(typeof(TypSystemu), v));
            modelBuilder.Entity<AplikacjaMobilna>().Property(e => e.TypAplikacji)
                .HasConversion(v => v.ToString(), v => (TypAplikacji)Enum.Parse(typeof(TypAplikacji), v));
            //enum dla zamowien
            modelBuilder.Entity<Zamowienie>().Property(e => e.Status)
                .HasConversion(v => v.ToString(), v => (Status)Enum.Parse(typeof(Status), v));
            //klient 1 - * zamowienie
            modelBuilder.Entity<Zamowienie>()
                .HasOne(p => p.Klient).WithMany(b => b.Zamowienia).HasForeignKey(p => p.OsobaId);
            //menedzer 1 - * projekt
            modelBuilder.Entity<Projekt>()
                .HasOne(p => p.Menedzer).WithMany(b => b.Projekty).HasForeignKey(p => p.OsobaId).OnDelete(DeleteBehavior.NoAction);
            //programista 1 - * asoc * - 1 projekt
            modelBuilder.Entity<ProgramistaProjekt_asoc>()
                .HasOne(p => p.Programista).WithMany(b => b.ProgramistaProjekt_Asocs).HasForeignKey(p => p.OsobaId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProgramistaProjekt_asoc>()
                .HasOne(p => p.Projekt).WithMany(b => b.ProgramistaProjekt_Asocs).HasForeignKey(p => p.ProjektId).OnDelete(DeleteBehavior.NoAction);
            //testerKodu 1 - * asoc * - 1 projekt
            modelBuilder.Entity<TesterkoduProjekt_asoc>()
                .HasOne(p => p.TesterKodu).WithMany(b => b.TesterkoduProjekt_Asocs).HasForeignKey(p => p.OsobaId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<TesterkoduProjekt_asoc>()
                .HasOne(p => p.Projekt).WithMany(b => b.TesterkoduProjekt_Asocs).HasForeignKey(p => p.ProjektId).OnDelete(DeleteBehavior.NoAction);

        }

    }
}
