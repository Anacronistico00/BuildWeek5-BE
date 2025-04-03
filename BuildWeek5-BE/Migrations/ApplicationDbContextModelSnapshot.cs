﻿// <auto-generated />
using System;
using BuildWeek5_BE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BuildWeek5_BE.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BuildWeek5_BE.Models.Animale", b =>
                {
                    b.Property<int>("PuppyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PuppyId"));

                    b.Property<string>("ColoreMantello")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DataNascita")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataRegistrazione")
                        .HasColumnType("date");

                    b.Property<bool>("MicrochipPresente")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumeroMicrochip")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Tipologia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PuppyId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("NumeroMicrochip")
                        .IsUnique()
                        .HasFilter("[NumeroMicrochip] IS NOT NULL");

                    b.HasIndex("Nome", "CustomerId")
                        .IsUnique()
                        .HasFilter("[CustomerId] IS NOT NULL");

                    b.ToTable("Puppies");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Auth.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "45722990-5591-4864-8001-3890d7001517",
                            ConcurrencyStamp = "45722990-5591-4864-8001-3890d7001517",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "149927eb-dbc7-484f-96cb-05407f4a70a0",
                            ConcurrencyStamp = "149927eb-dbc7-484f-96cb-05407f4a70a0",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Auth.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FiscalCode")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Auth.ApplicationUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodiceFiscale")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DataDiNascita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Indirizzo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ProdottoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Clienti");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Farmacia.Armadietto", b =>
                {
                    b.Property<int>("ArmadiettoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArmadiettoId"));

                    b.HasKey("ArmadiettoId");

                    b.ToTable("Armadietti");

                    b.HasData(
                        new
                        {
                            ArmadiettoId = 1
                        },
                        new
                        {
                            ArmadiettoId = 2
                        },
                        new
                        {
                            ArmadiettoId = 3
                        });
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Farmacia.Cassetto", b =>
                {
                    b.Property<int>("CassettoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CassettoId"));

                    b.Property<int>("ArmadiettoId")
                        .HasColumnType("int");

                    b.HasKey("CassettoId");

                    b.HasIndex("ArmadiettoId");

                    b.ToTable("Cassetti");

                    b.HasData(
                        new
                        {
                            CassettoId = 1,
                            ArmadiettoId = 1
                        },
                        new
                        {
                            CassettoId = 2,
                            ArmadiettoId = 1
                        },
                        new
                        {
                            CassettoId = 3,
                            ArmadiettoId = 1
                        },
                        new
                        {
                            CassettoId = 4,
                            ArmadiettoId = 1
                        },
                        new
                        {
                            CassettoId = 5,
                            ArmadiettoId = 1
                        },
                        new
                        {
                            CassettoId = 6,
                            ArmadiettoId = 2
                        },
                        new
                        {
                            CassettoId = 7,
                            ArmadiettoId = 2
                        },
                        new
                        {
                            CassettoId = 8,
                            ArmadiettoId = 2
                        },
                        new
                        {
                            CassettoId = 9,
                            ArmadiettoId = 2
                        },
                        new
                        {
                            CassettoId = 10,
                            ArmadiettoId = 2
                        },
                        new
                        {
                            CassettoId = 11,
                            ArmadiettoId = 3
                        },
                        new
                        {
                            CassettoId = 12,
                            ArmadiettoId = 3
                        },
                        new
                        {
                            CassettoId = 13,
                            ArmadiettoId = 3
                        },
                        new
                        {
                            CassettoId = 14,
                            ArmadiettoId = 3
                        },
                        new
                        {
                            CassettoId = 15,
                            ArmadiettoId = 3
                        });
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Farmacia.Fornitore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Indirizzo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Recapito")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Fornitori");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Indirizzo = "Via Roma 10",
                            Nome = "Farmaceutica ABC",
                            Recapito = "123456789"
                        },
                        new
                        {
                            Id = 2,
                            Indirizzo = "Via Milano 20",
                            Nome = "VetCare Ltd.",
                            Recapito = "987654321"
                        },
                        new
                        {
                            Id = 3,
                            Indirizzo = "Via Torino 30",
                            Nome = "SalutePet",
                            Recapito = "555666777"
                        });
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Farmacia.Prodotto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArmadiettoId")
                        .HasColumnType("int");

                    b.Property<int>("CassettoId")
                        .HasColumnType("int");

                    b.Property<int>("FornitoreId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsiProdotto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArmadiettoId");

                    b.HasIndex("CassettoId");

                    b.HasIndex("FornitoreId");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Prodotti");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArmadiettoId = 1,
                            CassettoId = 1,
                            FornitoreId = 1,
                            Nome = "Antibiotico X",
                            UsiProdotto = "Antibiotico per la cura di infezioni dovute ai parassiti"
                        },
                        new
                        {
                            Id = 2,
                            ArmadiettoId = 2,
                            CassettoId = 2,
                            FornitoreId = 2,
                            Nome = "Antiparassitario Y",
                            UsiProdotto = "Protegge da pulci, zecche e pappataci"
                        },
                        new
                        {
                            Id = 3,
                            ArmadiettoId = 3,
                            CassettoId = 3,
                            FornitoreId = 3,
                            Nome = "Integratore Z",
                            UsiProdotto = "Stimola la circolazione e aiuta a integrare le vitamine e minerali mancanti"
                        });
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Farmacia.UtenteProdotto", b =>
                {
                    b.Property<int>("utenteId")
                        .HasColumnType("int");

                    b.Property<int>("prodottoId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DataAcquisto")
                        .HasColumnType("date");

                    b.Property<string>("NumeroRicettaMedica")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("utenteId", "prodottoId");

                    b.HasIndex("prodottoId");

                    b.ToTable("UtentiProdotti");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Farmacia.Vendita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataVendita")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroRicettaMedica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdottoId")
                        .HasColumnType("int");

                    b.Property<string>("RicettaMedica")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdottoId");

                    b.HasIndex("UserId");

                    b.ToTable("Vendite");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Ricovero", b =>
                {
                    b.Property<int>("RicoveroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RicoveroId"));

                    b.Property<DateOnly?>("DataFineRicovero")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataInizioRicovero")
                        .HasColumnType("date");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PuppyId")
                        .HasColumnType("int");

                    b.HasKey("RicoveroId");

                    b.HasIndex("PuppyId");

                    b.ToTable("Ricoveri");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Visita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataVisita")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescrizioneCura")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ObiettivoEsame")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PuppyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PuppyId");

                    b.ToTable("Visite");
                });

            modelBuilder.Entity("ClienteProdotto", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ClienteProdotto");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Animale", b =>
                {
                    b.HasOne("BuildWeek5_BE.Models.Cliente", "Customer")
                        .WithMany("Animali")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Auth.ApplicationUserRole", b =>
                {
                    b.HasOne("BuildWeek5_BE.Models.Auth.ApplicationRole", "Role")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildWeek5_BE.Models.Auth.ApplicationUser", "User")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Farmacia.Cassetto", b =>
                {
                    b.HasOne("BuildWeek5_BE.Models.Farmacia.Armadietto", "Armadietto")
                        .WithMany("Cassetti")
                        .HasForeignKey("ArmadiettoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Armadietto");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Farmacia.Prodotto", b =>
                {
                    b.HasOne("BuildWeek5_BE.Models.Farmacia.Armadietto", "Armadietto")
                        .WithMany()
                        .HasForeignKey("ArmadiettoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildWeek5_BE.Models.Farmacia.Cassetto", "Cassetto")
                        .WithMany("prodotti")
                        .HasForeignKey("CassettoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BuildWeek5_BE.Models.Farmacia.Fornitore", "Fornitore")
                        .WithMany("Prodotti")
                        .HasForeignKey("FornitoreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Armadietto");

                    b.Navigation("Cassetto");

                    b.Navigation("Fornitore");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Farmacia.UtenteProdotto", b =>
                {
                    b.HasOne("BuildWeek5_BE.Models.Farmacia.Prodotto", "Prodotto")
                        .WithMany("UtenteProdotto")
                        .HasForeignKey("prodottoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildWeek5_BE.Models.Cliente", "Cliente")
                        .WithMany("UtenteProdotto")
                        .HasForeignKey("utenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Prodotto");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Farmacia.Vendita", b =>
                {
                    b.HasOne("BuildWeek5_BE.Models.Farmacia.Prodotto", "Prodotto")
                        .WithMany()
                        .HasForeignKey("ProdottoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildWeek5_BE.Models.Cliente", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prodotto");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Ricovero", b =>
                {
                    b.HasOne("BuildWeek5_BE.Models.Animale", "Puppy")
                        .WithMany("Ricoveri")
                        .HasForeignKey("PuppyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Puppy");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Visita", b =>
                {
                    b.HasOne("BuildWeek5_BE.Models.Animale", "Animale")
                        .WithMany("Visite")
                        .HasForeignKey("PuppyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animale");
                });

            modelBuilder.Entity("ClienteProdotto", b =>
                {
                    b.HasOne("BuildWeek5_BE.Models.Cliente", null)
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildWeek5_BE.Models.Farmacia.Prodotto", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("BuildWeek5_BE.Models.Auth.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BuildWeek5_BE.Models.Auth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BuildWeek5_BE.Models.Auth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BuildWeek5_BE.Models.Auth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Animale", b =>
                {
                    b.Navigation("Ricoveri");

                    b.Navigation("Visite");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Auth.ApplicationRole", b =>
                {
                    b.Navigation("ApplicationUserRoles");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Auth.ApplicationUser", b =>
                {
                    b.Navigation("ApplicationUserRoles");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Cliente", b =>
                {
                    b.Navigation("Animali");

                    b.Navigation("UtenteProdotto");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Farmacia.Armadietto", b =>
                {
                    b.Navigation("Cassetti");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Farmacia.Cassetto", b =>
                {
                    b.Navigation("prodotti");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Farmacia.Fornitore", b =>
                {
                    b.Navigation("Prodotti");
                });

            modelBuilder.Entity("BuildWeek5_BE.Models.Farmacia.Prodotto", b =>
                {
                    b.Navigation("UtenteProdotto");
                });
#pragma warning restore 612, 618
        }
    }
}
