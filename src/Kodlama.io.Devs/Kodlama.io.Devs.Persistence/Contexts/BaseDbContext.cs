using Core.Security.Entities;
using Kodlama.io.Devs.Domain.Entities;
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

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

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

            modelBuilder.Entity<RefreshToken>(p =>
            {
                p.ToTable("RefreshTokens").HasKey(p => p.Id);
                p.Property(p => p.UserId).HasColumnName("UserId");
                p.Property(p => p.Token).HasColumnName("Token");
                p.Property(p => p.Expires).HasColumnName("Expires");
                p.Property(p => p.Created).HasColumnName("Created");
                p.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
                p.Property(p => p.Revoked).HasColumnName("Revoked");
                p.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
                p.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
                p.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");
                p.HasOne(p => p.User);
            });

            modelBuilder.Entity<OperationClaim>(p =>
            {
                p.ToTable("OperationClaims").HasKey(p => p.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<User>(p =>
            {
                p.ToTable("Users").HasKey(p => p.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.FirstName).HasColumnName("FirstName");
                p.Property(p => p.LastName).HasColumnName("LastName");
                p.Property(p => p.Email).HasColumnName("Email");
                p.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                p.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                p.Property(p => p.Status).HasColumnName("Status");
                p.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
            });

            modelBuilder.Entity<UserOperationClaim>(p =>
            {
                p.ToTable("UserOperationClaims").HasKey(p => p.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.UserId).HasColumnName("UserId");
                p.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                p.HasOne(p => p.User);
                p.HasOne(p => p.OperationClaim);
            });
        }
    }
}