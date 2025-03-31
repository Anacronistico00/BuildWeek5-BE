using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuildWeek5_BE.Migrations
{
    /// <inheritdoc />
    public partial class modified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13822178-261e-4e72-82a9-b43dc2f9dd2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f18c47b8-197e-489b-93b3-b736cc44ef96");

            migrationBuilder.DropColumn(
                name: "CodiceFiscaleCliente",
                table: "Vendite");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Vendite",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "011bde2d-1ad8-4ec4-965a-5a96c6d8e8f7", "011bde2d-1ad8-4ec4-965a-5a96c6d8e8f7", "User", "USER" },
                    { "27436a26-ace1-4143-bc00-8255c8d7b2fc", "27436a26-ace1-4143-bc00-8255c8d7b2fc", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendite_UserId",
                table: "Vendite",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendite_AspNetUsers_UserId",
                table: "Vendite",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendite_AspNetUsers_UserId",
                table: "Vendite");

            migrationBuilder.DropIndex(
                name: "IX_Vendite_UserId",
                table: "Vendite");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "011bde2d-1ad8-4ec4-965a-5a96c6d8e8f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27436a26-ace1-4143-bc00-8255c8d7b2fc");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Vendite");

            migrationBuilder.AddColumn<string>(
                name: "CodiceFiscaleCliente",
                table: "Vendite",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13822178-261e-4e72-82a9-b43dc2f9dd2f", "13822178-261e-4e72-82a9-b43dc2f9dd2f", "User", "USER" },
                    { "f18c47b8-197e-489b-93b3-b736cc44ef96", "f18c47b8-197e-489b-93b3-b736cc44ef96", "Admin", "ADMIN" }
                });
        }
    }
}
