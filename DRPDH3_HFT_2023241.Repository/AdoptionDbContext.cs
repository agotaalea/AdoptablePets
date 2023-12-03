using DRPDH3_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;

namespace DRPDH3_HFT_2023241.Repository
{
    public class AdoptionDbContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Adoption> Adoptions { get; set;}
        public DbSet<Species> Species { get; set; }

        public AdoptionDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseInMemoryDatabase("AdoptationDb").UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Egy fajba több kisállat tartozik
            //egy kisállatnak több gazdája lehet (visszahozzák a menhelyre)
            modelBuilder.Entity<Pet>(pet => pet
                .HasOne(pet => pet.Species)
                .WithMany(type => type.Pets)
                .HasForeignKey(pet => pet.SpeciesId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Adoption>()
                .HasOne(rec => rec.Pet)
                .WithMany(pet => pet.Adoptions);

            modelBuilder.Entity<Species>().HasData(new Species[]
            {
                //ID;Name;Descripiton
                new Species("1;Vadaszgoreny;Budosek es sokat rosszalkodnak"),
                new Species("2;Kutya;Okos"),
                new Species("3;Macska;Szep"),
                new Species("4;Madar;Hangos"),
                new Species("5;Prerikutya;Aranyos"),
            });

            modelBuilder.Entity<Pet>().HasData(new Pet[]
            {
                //ID;SpeciesId;Name;Age;Description
                new Pet("1;1;Shiba;4;Rossz"),
                new Pet("2;2;Bella;5;Jo kutya"),
                new Pet("3;3;Bendzsi;2;Okos"),
                new Pet("4;4;Kakukk;3;Hangos madarka"),
                new Pet("5;5;Eszter;2;Sokat maszik"),
                new Pet("6;4;Kiscsibe;1;Mindig ehes"),
                new Pet("7;2;Vuk;7;Ravasz"),
                new Pet("8;3;Sanyi;1;Fekete szoru"),
            });

            modelBuilder.Entity<Adoption>().HasData(new Adoption[]
            {   
                //Id;PetId;AdopterName;AdoptionDate;Contact
                new Adoption("1;1;Lea;2023.01.01;+36301234567"),
                new Adoption("2;2;Lea;2023.01.02;+36301234567"),
                new Adoption("3;3;Lea;2023.01.03;+36301234567"),
                new Adoption("4;8;Sanyi;2023.05.25;sanyika.sanyi@gmail.com"),
            });
        }
    }
}
