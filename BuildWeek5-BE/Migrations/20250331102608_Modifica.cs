using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuildWeek5_BE.Migrations
{
    /// <inheritdoc />
    public partial class Modifica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "338b798d-014a-484c-8b9f-92cee680985c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c29f332f-09e8-431a-956f-b98c36e35218");

            migrationBuilder.AddColumn<int>(
                name: "ArmadiettoId",
                table: "Prodotti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d08864b-fc4b-43f9-a636-74400088f0cc", "4d08864b-fc4b-43f9-a636-74400088f0cc", "Admin", "ADMIN" },
                    { "8a5686f2-8875-4758-88e5-1db55543cac1", "8a5686f2-8875-4758-88e5-1db55543cac1", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Prodotti",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArmadiettoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Prodotti",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArmadiettoId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Prodotti",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArmadiettoId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_ArmadiettoId",
                table: "Prodotti",
                column: "ArmadiettoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prodotti_Armadietti_ArmadiettoId",
                table: "Prodotti",
                column: "ArmadiettoId",
                principalTable: "Armadietti",
                principalColumn: "ArmadiettoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prodotti_Armadietti_ArmadiettoId",
                table: "Prodotti");

            migrationBuilder.DropIndex(
                name: "IX_Prodotti_ArmadiettoId",
                table: "Prodotti");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d08864b-fc4b-43f9-a636-74400088f0cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a5686f2-8875-4758-88e5-1db55543cac1");

            migrationBuilder.DropColumn(
                name: "ArmadiettoId",
                table: "Prodotti");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "338b798d-014a-484c-8b9f-92cee680985c", "338b798d-014a-484c-8b9f-92cee680985c", "User", "USER" },
                    { "c29f332f-09e8-431a-956f-b98c36e35218", "c29f332f-09e8-431a-956f-b98c36e35218", "Admin", "ADMIN" }
                });
        }
    }
}
