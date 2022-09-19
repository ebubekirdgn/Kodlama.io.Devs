﻿using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kodlama.io.Devs.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<ProgrammingTechnology> ProgrammingTechnologies { get; set; }
        public DbSet<GithubAccount> GithubAccounts { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id); // Entity'e ait prop'ların Veritabanı tablosundaki özellikleri
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");

                a.HasMany(p => p.ProgrammingTechnologies);
            });

            modelBuilder.Entity<ProgrammingTechnology>(a =>
            {
                a.ToTable("ProgrammingTechnologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.Property(p => p.Name).HasColumnName("Name");

                a.HasOne(p => p.ProgramingLanguage);
            });
            ProgrammingTechnology[] programmingTechnologiesEntitySeeds = { new(1, 3, "Spring") }; //test datası oluşturması için
            modelBuilder.Entity<ProgrammingTechnology>().HasData(programmingTechnologiesEntitySeeds);


            modelBuilder.Entity<GithubAccount>(a =>
            {
                a.ToTable("GithubAccounts").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.GithubUrl).HasColumnName("GithubUrl");

                a.HasOne(g => g.User);
            });

          
            ProgrammingLanguage[] programmingLanguagesEntitySeeds = { new(1, "C#"), new(2, "Pyhton"), new(3, "Java") }; //test datası oluşturması için
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguagesEntitySeeds);
        }
    }
}