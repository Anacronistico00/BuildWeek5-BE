using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuildWeek5_BE.Migrations
{
    /// <inheritdoc />
    public partial class addedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "049613a5-748c-4efc-8d21-141ade6b3226");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6ef9b1b-98c3-49d6-b853-1268cfed10ff");

            migrationBuilder.AddColumn<string>(
                name: "FiscalCode",
                table: "AspNetUsers",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Animali",
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
                    ProprietarioNome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProprietarioCognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animali", x => x.PuppyId);
                });

            migrationBuilder.CreateTable(
                name: "Armadietti",
                columns: table => new
                {
                    Codice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armadietti", x => x.Codice);
                });

            migrationBuilder.CreateTable(
                name: "Fornitore",
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
                    table.PrimaryKey("PK_Fornitore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ricoveri",
                columns: table => new
                {
                    RicoveroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PuppyId = table.Column<int>(type: "int", nullable: false),
                    DataInizioRicovero = table.Column<DateOnly>(type: "date", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ricoveri", x => x.RicoveroId);
                    table.ForeignKey(
                        name: "FK_Ricoveri_Animali_PuppyId",
                        column: x => x.PuppyId,
                        principalTable: "Animali",
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
                        name: "FK_Visite_Animali_PuppyId",
                        column: x => x.PuppyId,
                        principalTable: "Animali",
                        principalColumn: "PuppyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cassetti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmadiettoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cassetti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cassetti_Armadietti_ArmadiettoId",
                        column: x => x.ArmadiettoId,
                        principalTable: "Armadietti",
                        principalColumn: "Codice",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prodotti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FornitoreId = table.Column<int>(type: "int", nullable: false),
                    CassettoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodotti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prodotti_Cassetti_CassettoId",
                        column: x => x.CassettoId,
                        principalTable: "Cassetti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prodotti_Fornitore_FornitoreId",
                        column: x => x.FornitoreId,
                        principalTable: "Fornitore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsoProdotto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProdottoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsoProdotto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsoProdotto_Prodotti_ProdottoId",
                        column: x => x.ProdottoId,
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
                    CodiceFiscaleCliente = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    ProdottoId = table.Column<int>(type: "int", nullable: false),
                    NumeroRicettaMedica = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendite_Prodotti_ProdottoId",
                        column: x => x.ProdottoId,
                        principalTable: "Prodotti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13822178-261e-4e72-82a9-b43dc2f9dd2f", "13822178-261e-4e72-82a9-b43dc2f9dd2f", "User", "USER" },
                    { "f18c47b8-197e-489b-93b3-b736cc44ef96", "f18c47b8-197e-489b-93b3-b736cc44ef96", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animali_Nome_ProprietarioNome_ProprietarioCognome",
                table: "Animali",
                columns: new[] { "Nome", "ProprietarioNome", "ProprietarioCognome" },
                unique: true,
                filter: "[ProprietarioNome] IS NOT NULL AND [ProprietarioCognome] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Animali_NumeroMicrochip",
                table: "Animali",
                column: "NumeroMicrochip",
                unique: true,
                filter: "[NumeroMicrochip] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cassetti_ArmadiettoId",
                table: "Cassetti",
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
                name: "IX_Ricoveri_PuppyId",
                table: "Ricoveri",
                column: "PuppyId");

            migrationBuilder.CreateIndex(
                name: "IX_UsoProdotto_ProdottoId",
                table: "UsoProdotto",
                column: "ProdottoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendite_ProdottoId",
                table: "Vendite",
                column: "ProdottoId");

            migrationBuilder.CreateIndex(
                name: "IX_Visite_PuppyId",
                table: "Visite",
                column: "PuppyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ricoveri");

            migrationBuilder.DropTable(
                name: "UsoProdotto");

            migrationBuilder.DropTable(
                name: "Vendite");

            migrationBuilder.DropTable(
                name: "Visite");

            migrationBuilder.DropTable(
                name: "Prodotti");

            migrationBuilder.DropTable(
                name: "Animali");

            migrationBuilder.DropTable(
                name: "Cassetti");

            migrationBuilder.DropTable(
                name: "Fornitore");

            migrationBuilder.DropTable(
                name: "Armadietti");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13822178-261e-4e72-82a9-b43dc2f9dd2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f18c47b8-197e-489b-93b3-b736cc44ef96");

            migrationBuilder.DropColumn(
                name: "FiscalCode",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "049613a5-748c-4efc-8d21-141ade6b3226", "049613a5-748c-4efc-8d21-141ade6b3226", "Admin", "ADMIN" },
                    { "f6ef9b1b-98c3-49d6-b853-1268cfed10ff", "f6ef9b1b-98c3-49d6-b853-1268cfed10ff", "User", "USER" }
                });
        }
    }
}
