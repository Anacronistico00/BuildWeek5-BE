using BuildWeek5_BE.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net.Sockets;
using BuildWeek5_BE.Models.Farmacia;
using BuildWeek5_BE.Models;

namespace BuildWeek5_BE.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }

        public DbSet<Animale> Puppies { get; set; }
        public DbSet<Visita> Visite { get; set; }
        public DbSet<Ricovero> Ricoveri { get; set; }
        public DbSet<Prodotto> Prodotti { get; set; }
        public DbSet<Cassetto> Cassetti { get; set; }
        public DbSet<Armadietto> Armadietti { get; set; }
        public DbSet<Vendita> Vendite { get; set; }
        public DbSet<Fornitore> Fornitori { get; set; }
        public DbSet<UsoProdotto> UsiProdotti { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUserRole>().Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()").IsRequired(true);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(p => p.User).WithMany(p => p.ApplicationUserRoles).HasForeignKey(p => p.UserId).IsRequired(true);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(p => p.Role).WithMany(p => p.ApplicationUserRoles).HasForeignKey(p => p.RoleId).IsRequired(true);

            modelBuilder.Entity<Animale>().HasMany(a => a.Visite).WithOne(p => p.Animale).HasForeignKey("PuppyId");
            modelBuilder.Entity<Animale>().HasMany(r => r.Ricoveri).WithOne(p => p.Puppy).HasForeignKey("PuppyId");
            modelBuilder.Entity<Animale>().HasIndex(u => u.NumeroMicrochip).IsUnique();
            modelBuilder.Entity<Animale>().HasIndex(u => new { u.Nome, u.UserId }).IsUnique();

            modelBuilder.Entity<Prodotto>().HasIndex(p => p.Nome).IsUnique();
            modelBuilder.Entity<Prodotto>().HasOne(p => p.Cassetto).WithMany(p => p.prodotti).HasForeignKey(p => p.CassettoId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Prodotto>().HasOne(p => p.Fornitore).WithMany(p => p.Prodotti).HasForeignKey(p => p.FornitoreId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cassetto>().HasOne(c => c.Armadietto).WithMany(a => a.Cassetti).HasForeignKey(c => c.ArmadiettoId);

            modelBuilder.Entity<Vendita>().HasOne(v => v.Prodotto).WithMany(v => v.vendite).HasForeignKey(v => v.ProdottoId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsoProdotto>().HasOne(u => u.Prodotto).WithMany(p => p.Usi).HasForeignKey(u => u.ProdottoId);

            var adminId = Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();

            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole
                {
                    Id = adminId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = adminId
                },
                new ApplicationRole
                {
                    Id = userId,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = userId
                }
            );

            modelBuilder.Entity<Armadietto>().HasData(
                new Armadietto { ArmadiettoId = 1 },
                new Armadietto { ArmadiettoId = 2 },
                new Armadietto { ArmadiettoId = 3 }
            );

            modelBuilder.Entity<Cassetto>().HasData(
                new Cassetto { CassettoId = 1, ArmadiettoId = 1 },
                new Cassetto { CassettoId = 2, ArmadiettoId = 1 },
                new Cassetto { CassettoId = 3, ArmadiettoId = 1 },
                new Cassetto { CassettoId = 4, ArmadiettoId = 1 },
                new Cassetto { CassettoId = 5, ArmadiettoId = 1 },
                new Cassetto { CassettoId = 6, ArmadiettoId = 2 },
                new Cassetto { CassettoId = 7, ArmadiettoId = 2 },
                new Cassetto { CassettoId = 8, ArmadiettoId = 2 },
                new Cassetto { CassettoId = 9, ArmadiettoId = 2 },
                new Cassetto { CassettoId = 10, ArmadiettoId = 2 },
                new Cassetto { CassettoId = 11, ArmadiettoId = 3 },
                new Cassetto { CassettoId = 12, ArmadiettoId = 3 },
                new Cassetto { CassettoId = 13, ArmadiettoId = 3 },
                new Cassetto { CassettoId = 14, ArmadiettoId = 3 },
                new Cassetto { CassettoId = 15, ArmadiettoId = 3 }
            );

            modelBuilder.Entity<Fornitore>().HasData(
               new Fornitore { Id = 1, Nome = "Farmaceutica ABC", Recapito = "123456789", Indirizzo = "Via Roma 10" },
               new Fornitore { Id = 2, Nome = "VetCare Ltd.", Recapito = "987654321", Indirizzo = "Via Milano 20" },
               new Fornitore { Id = 3, Nome = "SalutePet", Recapito = "555666777", Indirizzo = "Via Torino 30" }
           );

            modelBuilder.Entity<Prodotto>().HasData(
                new Prodotto { Id = 1, Nome = "Antibiotico X", FornitoreId = 1, CassettoId = 1, ArmadiettoId = 1 },
                new Prodotto { Id = 2, Nome = "Antiparassitario Y", FornitoreId = 2, CassettoId = 2, ArmadiettoId = 2 },
                new Prodotto { Id = 3, Nome = "Integratore Z", FornitoreId = 3, CassettoId = 3, ArmadiettoId = 3 }
            );
        }
    }
}
