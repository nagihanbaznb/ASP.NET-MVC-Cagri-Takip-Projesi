using BOSSAProje.Models;
using Microsoft.EntityFrameworkCore;

namespace BOSSAProje.Contexts
{
    public class CihazContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=Cihaz;Trusted_Connection=true");//buraya direk "constring" yazılaiblir.
        }

        DbSet<Cihaz> Cihaz { get; set; }
        DbSet<Hareket> Hareket { get; set; }
        DbSet<Hesap> Hesap { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)//sil
        {
            modelBuilder.Entity<Cihaz>(a =>
            {
                a.ToTable("Cihaz").HasKey(p => p.SERI_NO); //sil


            });// primary key ne olacaksa onunla degistir.
            modelBuilder.Entity<Hareket>(a =>
            {
                a.ToTable("Hareket").HasKey(p => p.HAREKET_NUMARASI); //sil


            });// primary key ne olacaksa onunla degistir.
            modelBuilder.Entity<Hesap>(a =>
            {
                a.ToTable("Hesap").HasKey(p => p.KULLANICI_ADI); //sil


            });// primary key ne olacaksa onunla degistir.
        }
    }
}
