using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuildWeek5_BE.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Prodotti_UserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Prodotti_Clienti_ClienteId",
                table: "Prodotti");

            migrationBuilder.DropIndex(
                name: "IX_Prodotti_ClienteId",
                table: "Prodotti");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab682615-380a-4076-9e14-7f9873e531da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d00e4f18-c9b0-408f-9f16-90f0292420ea");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Prodotti");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "ClienteProdotto",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteProdotto", x => new { x.ClienteId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ClienteProdotto_Clienti_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteProdotto_Prodotti_UserId",
                        column: x => x.UserId,
                        principalTable: "Prodotti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cdd50339-7fb2-45c2-b5fa-d82670b3051f", "cdd50339-7fb2-45c2-b5fa-d82670b3051f", "Admin", "ADMIN" },
                    { "d689b786-d367-4271-877b-6ddbd8241ce4", "d689b786-d367-4271-877b-6ddbd8241ce4", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteProdotto_UserId",
                table: "ClienteProdotto",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteProdotto");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdd50339-7fb2-45c2-b5fa-d82670b3051f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d689b786-d367-4271-877b-6ddbd8241ce4");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Prodotti",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ab682615-380a-4076-9e14-7f9873e531da", "ab682615-380a-4076-9e14-7f9873e531da", "Admin", "ADMIN" },
                    { "d00e4f18-c9b0-408f-9f16-90f0292420ea", "d00e4f18-c9b0-408f-9f16-90f0292420ea", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Prodotti",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClienteId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Prodotti",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClienteId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Prodotti",
                keyColumn: "Id",
                keyValue: 3,
                column: "ClienteId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_ClienteId",
                table: "Prodotti",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Prodotti_UserId",
                table: "AspNetUsers",
                column: "UserId",
                principalTable: "Prodotti",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prodotti_Clienti_ClienteId",
                table: "Prodotti",
                column: "ClienteId",
                principalTable: "Clienti",
                principalColumn: "Id");
        }
    }
}
