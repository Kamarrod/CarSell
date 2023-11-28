using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "CarModelId",
                keyValue: new Guid("30ed9803-1bab-43e3-848c-0866691092b7"));

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "LotId",
                keyValue: new Guid("4dd81212-cdeb-46a2-b304-6c2ad7225fc7"));

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "LotId",
                keyValue: new Guid("c1d5848f-0231-4bdf-abc5-cf09495835b7"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "CarModelId", "CarBrandId", "Name" },
                values: new object[] { new Guid("30ed9803-1bab-43e3-848c-0866691092b7"), new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "2114" });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "LotId", "CarBrandId", "CarModelId", "Description", "Millage", "PostDate", "Price", "ReleaseYear" },
                values: new object[,]
                {
                    { new Guid("4dd81212-cdeb-46a2-b304-6c2ad7225fc7"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Description", 199213, new DateTime(2023, 11, 27, 21, 15, 13, 460, DateTimeKind.Local).AddTicks(1422), 1000000, 2005 },
                    { new Guid("c1d5848f-0231-4bdf-abc5-cf09495835b7"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Color = REd", 300000, new DateTime(2023, 11, 27, 21, 15, 13, 460, DateTimeKind.Local).AddTicks(1407), 1000000, 1999 }
                });
        }
    }
}
