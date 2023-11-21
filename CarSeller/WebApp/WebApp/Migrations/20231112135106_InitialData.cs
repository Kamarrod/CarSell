using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarBrands",
                columns: new[] { "CarBrandId", "Name" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "BMW" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "LADA" }
                });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "LotId", "CarBrandId", "CarModelId", "Color", "Millage", "PostDate", "PostTime", "ReleaseYear" },
                values: new object[,]
                {
                    { new Guid("9305c851-de77-4039-b600-5a0413591c3f"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "White", 199213, new DateTime(2023, 11, 12, 16, 51, 5, 873, DateTimeKind.Local).AddTicks(5270), new DateTime(2023, 11, 12, 16, 51, 5, 873, DateTimeKind.Local).AddTicks(5271), 2005 },
                    { new Guid("fa13d0ca-01d9-4c22-af18-b67b6f7294f5"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Black", 300000, new DateTime(2023, 11, 12, 16, 51, 5, 873, DateTimeKind.Local).AddTicks(5255), new DateTime(2023, 11, 12, 16, 51, 5, 873, DateTimeKind.Local).AddTicks(5265), 1999 }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "CarModelId", "CarBrandId", "Name" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "X5" },
                    { new Guid("8fc9bc40-e533-48fb-bb6f-2f5e6ac69a25"), new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "2114" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "M5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "CarModelId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "CarModelId",
                keyValue: new Guid("8fc9bc40-e533-48fb-bb6f-2f5e6ac69a25"));

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "CarModelId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "LotId",
                keyValue: new Guid("9305c851-de77-4039-b600-5a0413591c3f"));

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "LotId",
                keyValue: new Guid("fa13d0ca-01d9-4c22-af18-b67b6f7294f5"));

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "CarBrandId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "CarBrandId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));
        }
    }
}
