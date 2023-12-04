using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddFKTouserFromLot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bc9677e-b3e3-4062-853a-43aa07260913");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5f399c7-52ea-4759-a03d-82e4a0dc3a38");

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "CarModelId",
                keyValue: new Guid("50f401a0-aa89-4680-bff1-0722b40a4462"));

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "LotId",
                keyValue: new Guid("13353d47-4ce9-42ea-892f-8e397b6ef6d0"));

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "LotId",
                keyValue: new Guid("43e89a5f-24f8-495c-abfc-9b7468d4e5d3"));

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Lots",
                newName: "UserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d5261d1-e7ef-4379-8613-52279e823ea8", "4c57b84b-7a71-4770-b0cc-8b4bb00cde0a", "User", "User" },
                    { "7702e995-c088-48d3-a0f7-0beac1e28f66", "a471e2ff-d289-4c35-b6e5-4d6fcd1742ab", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "CarModelId", "CarBrandId", "Name" },
                values: new object[] { new Guid("8150541e-34a5-4858-afb1-248bd5b1b90a"), new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "2114" });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "LotId", "CarBrandId", "CarModelId", "Description", "Millage", "PostDate", "Price", "ReleaseYear", "UserId" },
                values: new object[,]
                {
                    { new Guid("14920df0-477d-4d49-9284-0070a7e2c418"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Color = REd", 300000, new DateTime(2023, 12, 1, 14, 17, 22, 622, DateTimeKind.Local).AddTicks(4786), 1000000m, 1999, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("19aad677-1b64-499b-8917-91ba7d4bc4ff"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Description", 199213, new DateTime(2023, 12, 1, 14, 17, 22, 622, DateTimeKind.Local).AddTicks(4807), 1000000m, 2005, new Guid("00000000-0000-0000-0000-000000000000") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d5261d1-e7ef-4379-8613-52279e823ea8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7702e995-c088-48d3-a0f7-0beac1e28f66");

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "CarModelId",
                keyValue: new Guid("8150541e-34a5-4858-afb1-248bd5b1b90a"));

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "LotId",
                keyValue: new Guid("14920df0-477d-4d49-9284-0070a7e2c418"));

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "LotId",
                keyValue: new Guid("19aad677-1b64-499b-8917-91ba7d4bc4ff"));

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Lots",
                newName: "User");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4bc9677e-b3e3-4062-853a-43aa07260913", "ae108995-351a-4b9f-8329-5e54f1d90d76", "Admin", "ADMIN" },
                    { "f5f399c7-52ea-4759-a03d-82e4a0dc3a38", "cf713572-f9a4-4f0e-80d9-633efca64069", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "CarModelId", "CarBrandId", "Name" },
                values: new object[] { new Guid("50f401a0-aa89-4680-bff1-0722b40a4462"), new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "2114" });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "LotId", "CarBrandId", "CarModelId", "Description", "Millage", "PostDate", "Price", "ReleaseYear", "User" },
                values: new object[,]
                {
                    { new Guid("13353d47-4ce9-42ea-892f-8e397b6ef6d0"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Color = REd", 300000, new DateTime(2023, 12, 1, 13, 59, 55, 834, DateTimeKind.Local).AddTicks(9431), 1000000m, 1999, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("43e89a5f-24f8-495c-abfc-9b7468d4e5d3"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Description", 199213, new DateTime(2023, 12, 1, 13, 59, 55, 834, DateTimeKind.Local).AddTicks(9598), 1000000m, 2005, new Guid("00000000-0000-0000-0000-000000000000") }
                });
        }
    }
}
