using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalUserFiledsForRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fb0317b-3147-40ab-848e-e1912b627671");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd5f17f9-74aa-4141-9b37-178b6663655e");

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "CarModelId",
                keyValue: new Guid("a1e15bc1-03c9-46aa-a066-0adad5aac6e0"));

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "LotId",
                keyValue: new Guid("1486b6d4-33c7-400f-8690-6a6b3b0c8ecb"));

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "LotId",
                keyValue: new Guid("ef0c44c5-b0e9-496b-9e44-1863bf84ad42"));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                    { new Guid("12f588d7-0e68-428e-a93f-7befc30823fb"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Color = REd", 300000, new DateTime(2023, 11, 28, 15, 34, 46, 654, DateTimeKind.Local).AddTicks(2138), 1000000, 1999 },
                    { new Guid("a0d81da0-6e83-4965-bb0f-d7a0817e2c18"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Description", 199213, new DateTime(2023, 11, 28, 15, 34, 46, 654, DateTimeKind.Local).AddTicks(2152), 1000000, 2005 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2fb0317b-3147-40ab-848e-e1912b627671", "cbdf9dcc-ca38-43a8-9b2a-c7bbffc3ba88", "User", "User" },
                    { "bd5f17f9-74aa-4141-9b37-178b6663655e", "5cb3cf45-e90d-4850-a286-967c85115e27", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "CarModelId", "CarBrandId", "Name" },
                values: new object[] { new Guid("a1e15bc1-03c9-46aa-a066-0adad5aac6e0"), new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "2114" });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "LotId", "CarBrandId", "CarModelId", "Description", "Millage", "PostDate", "Price", "ReleaseYear" },
                values: new object[,]
                {
                    { new Guid("1486b6d4-33c7-400f-8690-6a6b3b0c8ecb"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Color = REd", 300000, new DateTime(2023, 11, 28, 11, 32, 22, 544, DateTimeKind.Local).AddTicks(4105), 1000000, 1999 },
                    { new Guid("ef0c44c5-b0e9-496b-9e44-1863bf84ad42"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Description", 199213, new DateTime(2023, 11, 28, 11, 32, 22, 544, DateTimeKind.Local).AddTicks(4125), 1000000, 2005 }
                });
        }
    }
}
