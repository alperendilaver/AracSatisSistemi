using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using yazilim_mimari.Data.Models;

namespace yazilim_mimari.Data.Context
{
    public class AracSatisContext:DbContext
    {
        public AracSatisContext(DbContextOptions options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Kullanici>().HasData(new List<Kullanici>(){
                new(){
                Ad="Alperen",
                Eposta="alperendilaver.0@gmail.com",
                Password="Alperen.67",
                Role="Admin",
                Soyad="Dilaver",
                UserId=1
                },
                new(){
                Ad="Alperen",
                Eposta="alperendilaver@gmail.com",
                Password="Alperen.67",
                Role="Uye",
                Soyad="Dilaver",
                UserId=2
                } 
            });
        }
        public DbSet<Ilan> Ilanlar => Set<Ilan>();
    
        public DbSet<Kullanici> Kullanicilar => Set<Kullanici>();
        public DbSet<Istek> Istekler => Set<Istek>();

        public DbSet<Yorum> Yorumlar => Set<Yorum>();

        public DbSet<Marka> Markalar => Set<Marka>();

        public DbSet<AracModel> Modeller => Set<AracModel>();

        public DbSet<Arac> Araclar => Set<Arac>();
    }
}