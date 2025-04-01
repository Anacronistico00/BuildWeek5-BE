using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuildWeek5_BE.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armadietti",
                columns: table => new
                {
                    ArmadiettoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armadietti", x => x.ArmadiettoId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    FiscalCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornitori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Recapito = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornitori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cassetti",
                columns: table => new
                {
                    CassettoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmadiettoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cassetti", x => x.CassettoId);
                    table.ForeignKey(
                        name: "FK_Cassetti_Armadietti_ArmadiettoId",
                        column: x => x.ArmadiettoId,
                        principalTable: "Armadietti",
                        principalColumn: "ArmadiettoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Puppies",
                columns: table => new
                {
                    PuppyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRegistrazione = table.Column<DateOnly>(type: "date", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tipologia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ColoreMantello = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataNascita = table.Column<DateOnly>(type: "date", nullable: false),
                    MicrochipPresente = table.Column<bool>(type: "bit", nullable: false),
                    NumeroMicrochip = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puppies", x => x.PuppyId);
                    table.ForeignKey(
                        name: "FK_Puppies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Prodotti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FornitoreId = table.Column<int>(type: "int", nullable: false),
                    UsiProdotto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CassettoId = table.Column<int>(type: "int", nullable: false),
                    ArmadiettoId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodotti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prodotti_Armadietti_ArmadiettoId",
                        column: x => x.ArmadiettoId,
                        principalTable: "Armadietti",
                        principalColumn: "ArmadiettoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prodotti_Cassetti_CassettoId",
                        column: x => x.CassettoId,
                        principalTable: "Cassetti",
                        principalColumn: "CassettoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prodotti_Fornitori_FornitoreId",
                        column: x => x.FornitoreId,
                        principalTable: "Fornitori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ricoveri",
                columns: table => new
                {
                    RicoveroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PuppyId = table.Column<int>(type: "int", nullable: false),
                    DataInizioRicovero = table.Column<DateOnly>(type: "date", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataFineRicovero = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ricoveri", x => x.RicoveroId);
                    table.ForeignKey(
                        name: "FK_Ricoveri_Puppies_PuppyId",
                        column: x => x.PuppyId,
                        principalTable: "Puppies",
                        principalColumn: "PuppyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataVisita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ObiettivoEsame = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescrizioneCura = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PuppyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visite_Puppies_PuppyId",
                        column: x => x.PuppyId,
                        principalTable: "Puppies",
                        principalColumn: "PuppyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserProdotto",
                columns: table => new
                {
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserProdotto", x => new { x.ClienteId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserProdotto_AspNetUsers_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserProdotto_Prodotti_UserId",
                        column: x => x.UserId,
                        principalTable: "Prodotti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UtentiProdotti",
                columns: table => new
                {
                    prodottoId = table.Column<int>(type: "int", nullable: false),
                    utenteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataAcquisto = table.Column<DateOnly>(type: "date", nullable: false),
                    NumeroRicettaMedica = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtentiProdotti", x => new { x.utenteId, x.prodottoId });
                    table.ForeignKey(
                        name: "FK_UtentiProdotti_AspNetUsers_utenteId",
                        column: x => x.utenteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UtentiProdotti_Prodotti_prodottoId",
                        column: x => x.prodottoId,
                        principalTable: "Prodotti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RicettaMedica = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProdottoId = table.Column<int>(type: "int", nullable: false),
                    NumeroRicettaMedica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataVendita = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendite_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendite_Prodotti_ProdottoId",
                        column: x => x.ProdottoId,
                        principalTable: "Prodotti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Armadietti",
                column: "ArmadiettoId",
                values: new object[]
                {
                    1,
                    2,
                    3
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0fde20e2-4ca8-4157-8d6e-f5622221cbda", "0fde20e2-4ca8-4157-8d6e-f5622221cbda", "Admin", "ADMIN" },
                    { "4e254e4e-514f-4548-bbd3-e92f200b3e8a", "4e254e4e-514f-4548-bbd3-e92f200b3e8a", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Fornitori",
                columns: new[] { "Id", "Indirizzo", "Nome", "Recapito" },
                values: new object[,]
                {
                    { 1, "Via Roma 10", "Farmaceutica ABC", "123456789" },
                    { 2, "Via Milano 20", "VetCare Ltd.", "987654321" },
                    { 3, "Via Torino 30", "SalutePet", "555666777" }
                });

            migrationBuilder.InsertData(
                table: "Cassetti",
                columns: new[] { "CassettoId", "ArmadiettoId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 3 },
                    { 12, 3 },
                    { 13, 3 },
                    { 14, 3 },
                    { 15, 3 }
                });

            migrationBuilder.InsertData(
                table: "Prodotti",
                columns: new[] { "Id", "ArmadiettoId", "CassettoId", "FornitoreId", "Nome", "UserId", "UsiProdotto" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, "Antibiotico X", null, "Antibiotico per la cura di infezioni dovute ai parassiti" },
                    { 2, 2, 2, 2, "Antiparassitario Y", null, "Protegge da pulci, zecche e pappataci" },
                    { 3, 3, 3, 3, "Integratore Z", null, "Stimola la circolazione e aiuta a integrare le vitamine e minerali mancanti" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserProdotto_UserId",
                table: "ApplicationUserProdotto",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cassetti_ArmadiettoId",
                table: "Cassetti",
                column: "ArmadiettoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_ArmadiettoId",
                table: "Prodotti",
                column: "ArmadiettoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_CassettoId",
                table: "Prodotti",
                column: "CassettoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_FornitoreId",
                table: "Prodotti",
                column: "FornitoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_Nome",
                table: "Prodotti",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Puppies_Nome_UserId",
                table: "Puppies",
                columns: new[] { "Nome", "UserId" },
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Puppies_NumeroMicrochip",
                table: "Puppies",
                column: "NumeroMicrochip",
                unique: true,
                filter: "[NumeroMicrochip] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Puppies_UserId",
                table: "Puppies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ricoveri_PuppyId",
                table: "Ricoveri",
                column: "PuppyId");

            migrationBuilder.CreateIndex(
                name: "IX_UtentiProdotti_prodottoId",
                table: "UtentiProdotti",
                column: "prodottoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendite_ProdottoId",
                table: "Vendite",
                column: "ProdottoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendite_UserId",
                table: "Vendite",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Visite_PuppyId",
                table: "Visite",
                column: "PuppyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserProdotto");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Ricoveri");

            migrationBuilder.DropTable(
                name: "UtentiProdotti");

            migrationBuilder.DropTable(
                name: "Vendite");

            migrationBuilder.DropTable(
                name: "Visite");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Prodotti");

            migrationBuilder.DropTable(
                name: "Puppies");

            migrationBuilder.DropTable(
                name: "Cassetti");

            migrationBuilder.DropTable(
                name: "Fornitori");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Armadietti");
        }
    }
}
