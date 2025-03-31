using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuildWeek5_BE.Migrations
{
    /// <inheritdoc />
    public partial class AggiungiDataFineRicovero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d08864b-fc4b-43f9-a636-74400088f0cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a5686f2-8875-4758-88e5-1db55543cac1");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataFineRicovero",
                table: "Ricoveri",
                type: "date",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "163e6953-e5bd-494c-806b-41333a7b8d33", "163e6953-e5bd-494c-806b-41333a7b8d33", "User", "USER" },
                    { "e72f2a43-34a8-4b8a-a256-0a91db69b09c", "e72f2a43-34a8-4b8a-a256-0a91db69b09c", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "163e6953-e5bd-494c-806b-41333a7b8d33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e72f2a43-34a8-4b8a-a256-0a91db69b09c");

            migrationBuilder.DropColumn(
                name: "DataFineRicovero",
                table: "Ricoveri");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d08864b-fc4b-43f9-a636-74400088f0cc", "4d08864b-fc4b-43f9-a636-74400088f0cc", "Admin", "ADMIN" },
                    { "8a5686f2-8875-4758-88e5-1db55543cac1", "8a5686f2-8875-4758-88e5-1db55543cac1", "User", "USER" }
                });
        }
    }
}
