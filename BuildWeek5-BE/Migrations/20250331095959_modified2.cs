using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuildWeek5_BE.Migrations
{
    /// <inheritdoc />
    public partial class modified2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Animali_Nome_ProprietarioNome_ProprietarioCognome",
                table: "Animali");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "011bde2d-1ad8-4ec4-965a-5a96c6d8e8f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27436a26-ace1-4143-bc00-8255c8d7b2fc");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProprietarioCognome",
                table: "Animali");

            migrationBuilder.DropColumn(
                name: "ProprietarioNome",
                table: "Animali");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Animali",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Animali_UserId",
                table: "Animali",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animali_AspNetUsers_UserId",
                table: "Animali",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.DropIndex(
                name: "IX_Animali_UserId",
                table: "Animali");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af4ec8b3-bee8-4d5a-aa40-0a0cb4406cb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e66f7444-e0d1-4bdd-8387-8a44c1f65ae3");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Animali");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProprietarioCognome",
                table: "Animali",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProprietarioNome",
                table: "Animali",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "011bde2d-1ad8-4ec4-965a-5a96c6d8e8f7", "011bde2d-1ad8-4ec4-965a-5a96c6d8e8f7", "User", "USER" },
                    { "27436a26-ace1-4143-bc00-8255c8d7b2fc", "27436a26-ace1-4143-bc00-8255c8d7b2fc", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animali_Nome_ProprietarioNome_ProprietarioCognome",
                table: "Animali",
                columns: new[] { "Nome", "ProprietarioNome", "ProprietarioCognome" },
                unique: true,
                filter: "[ProprietarioNome] IS NOT NULL AND [ProprietarioCognome] IS NOT NULL");
        }
    }
}
