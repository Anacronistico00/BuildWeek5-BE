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

        public DbSet<Puppy> Animali { get; set; }
        public DbSet<Visita> Visite { get; set; }
        public DbSet<Ricovero> Ricoveri { get; set; }
        public DbSet<Prodotto> Prodotti { get; set; }
        public DbSet<Cassetto> Cassetti { get; set; }
        public DbSet<Armadietto> Armadietti { get; set; }
        public DbSet<Vendita> Vendite { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUserRole>().Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()").IsRequired(true);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(p => p.User).WithMany(p => p.ApplicationUserRoles).HasForeignKey(p => p.UserId).IsRequired(true);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(p => p.Role).WithMany(p => p.ApplicationUserRoles).HasForeignKey(p => p.RoleId).IsRequired(true);

            modelBuilder.Entity<Puppy>().HasMany(a => a.Visite).WithOne(p => p.Puppy).HasForeignKey("PuppyId");
            modelBuilder.Entity<Puppy>().HasMany(r => r.Ricoveri).WithOne(p => p.Puppy).HasForeignKey("PuppyId");
            modelBuilder.Entity<Puppy>().HasIndex(u => u.NumeroMicrochip).IsUnique();
            modelBuilder.Entity<Puppy>().HasIndex(u => new { u.Nome, u.UserId }).IsUnique();

            modelBuilder.Entity<Prodotto>().HasIndex(p => p.Nome).IsUnique();
            modelBuilder.Entity<Prodotto>().HasOne(p => p.Cassetto).WithMany(p => p.prodotti).HasForeignKey(p => p.CassettoId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cassetto>().HasOne(c => c.Armadietto).WithMany(a => a.Cassetti).HasForeignKey(c => c.ArmadiettoId);

            modelBuilder.Entity<Vendita>().HasOne(v => v.Prodotto).WithMany(v => v.vendite).HasForeignKey(v => v.ProdottoId).OnDelete(DeleteBehavior.Restrict);


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
        }
    }
}
