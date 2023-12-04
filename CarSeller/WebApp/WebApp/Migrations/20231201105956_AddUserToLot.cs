using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToLot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45feb966-5d37-4fb0-b3a9-d948d2798000");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de79514b-b52c-4060-941d-51c5880c1fdb");

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "CarModelId",
                keyValue: new Guid("4df65d27-8f73-4e26-a91e-78f412c8d1e8"));

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "LotId",
                keyValue: new Guid("12f588d7-0e68-428e-a93f-7befc30823fb"));

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "LotId",
                keyValue: new Guid("a0d81da0-6e83-4965-bb0f-d7a0817e2c18"));

            migrationBuilder.AddColumn<Guid>(
                name: "User",
                table: "Lots",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "User",
                table: "Lots");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45feb966-5d37-4fb0-b3a9-d948d2798000", "767a9b5b-da23-45dc-9c4a-e00fa67b1d2b", "Admin", "ADMIN" },
                    { "de79514b-b52c-4060-941d-51c5880c1fdb", "7447fa1f-e595-4295-9d04-578fbc5fc2d4", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "CarModelId", "CarBrandId", "Name" },
                values: new object[] { new Guid("4df65d27-8f73-4e26-a91e-78f412c8d1e8"), new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "2114" });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "LotId", "CarBrandId", "CarModelId", "Description", "Millage", "PostDate", "Price", "ReleaseYear" },
                values: new object[,]
                {
                    { new Guid("12f588d7-0e68-428e-a93f-7befc30823fb"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Color = REd", 300000, new DateTime(2023, 11, 28, 15, 34, 46, 654, DateTimeKind.Local).AddTicks(2138), 1000000m, 1999 },
                    { new Guid("a0d81da0-6e83-4965-bb0f-d7a0817e2c18"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Description", 199213, new DateTime(2023, 11, 28, 15, 34, 46, 654, DateTimeKind.Local).AddTicks(2152), 1000000m, 2005 }
                });
        }
    }
}
