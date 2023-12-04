using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configurations
{
    public class LotConfigurations : IEntityTypeConfiguration<Lot>
    {
        public void Configure(EntityTypeBuilder<Lot> builder)
        {

            builder.HasData(
                new Lot
                {
                Id = Guid.NewGuid(),
                    Description = "Color = REd",
                    Price = 1000000,
                    PostDate = DateTime.Now,
                    ReleaseYear = 1999,
                    Millage = 300000,
                    CarBrandId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    CarModelId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    UserId = new string("3bdb34fe-9d78-47db-b25c-7eaa17a8661f")
                },
                new Lot
                {
                    Id = Guid.NewGuid(),
                    Description = "Description",
                    PostDate = DateTime.Now,
                    ReleaseYear = 2005,
                    Price = 1000000,
                    Millage = 199213,
                    CarBrandId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    CarModelId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    UserId = new string("3bdb34fe-9d78-47db-b25c-7eaa17a8661f")
                }
                );
        }
    }
}
