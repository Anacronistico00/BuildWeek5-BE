using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuildWeek5_BE.Migrations
{
    /// <inheritdoc />
    public partial class modified3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animali_AspNetUsers_UserId",
                table: "Animali");

            migrationBuilder.DropIndex(
                name: "IX_Animali_Nome_UserId",
                table: "Animali");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af4ec8b3-bee8-4d5a-aa40-0a0cb4406cb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e66f7444-e0d1-4bdd-8387-8a44c1f65ae3");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Animali",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14d388a4-2a03-40af-a7ca-100d1ad0daaf", "14d388a4-2a03-40af-a7ca-100d1ad0daaf", "User", "USER" },
                    { "33b6ccf2-26d1-4c0b-8778-202bd57f4766", "33b6ccf2-26d1-4c0b-8778-202bd57f4766", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animali_Nome_UserId",
                table: "Animali",
                columns: new[] { "Nome", "UserId" },
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Animali_AspNetUsers_UserId",
                table: "Animali",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animali_AspNetUsers_UserId",
                table: "Animali");

            migrationBuilder.DropIndex(
                name: "IX_Animali_Nome_UserId",
                table: "Animali");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14d388a4-2a03-40af-a7ca-100d1ad0daaf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33b6ccf2-26d1-4c0b-8778-202bd57f4766");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Animali",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "af4ec8b3-bee8-4d5a-aa40-0a0cb4406cb8", "af4ec8b3-bee8-4d5a-aa40-0a0cb4406cb8", "User", "USER" },
                    { "e66f7444-e0d1-4bdd-8387-8a44c1f65ae3", "e66f7444-e0d1-4bdd-8387-8a44c1f65ae3", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animali_Nome_UserId",
                table: "Animali",
                columns: new[] { "Nome", "UserId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Animali_AspNetUsers_UserId",
                table: "Animali",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
