using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuildWeek5_BE.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendite_AspNetUsers_UserId",
                table: "Vendite");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdd50339-7fb2-45c2-b5fa-d82670b3051f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d689b786-d367-4271-877b-6ddbd8241ce4");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Vendite",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "982ef689-dac3-4d69-9fca-b063fd900f46", "982ef689-dac3-4d69-9fca-b063fd900f46", "Admin", "ADMIN" },
                    { "b7a3312a-8a5c-42e2-80aa-7e255e06bb77", "b7a3312a-8a5c-42e2-80aa-7e255e06bb77", "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Vendite_Clienti_UserId",
                table: "Vendite",
                column: "UserId",
                principalTable: "Clienti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendite_Clienti_UserId",
                table: "Vendite");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "982ef689-dac3-4d69-9fca-b063fd900f46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7a3312a-8a5c-42e2-80aa-7e255e06bb77");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Vendite",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cdd50339-7fb2-45c2-b5fa-d82670b3051f", "cdd50339-7fb2-45c2-b5fa-d82670b3051f", "Admin", "ADMIN" },
                    { "d689b786-d367-4271-877b-6ddbd8241ce4", "d689b786-d367-4271-877b-6ddbd8241ce4", "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Vendite_AspNetUsers_UserId",
                table: "Vendite",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
