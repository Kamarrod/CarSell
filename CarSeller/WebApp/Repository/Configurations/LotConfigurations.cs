using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    Color = "Black",
                    PostDate = DateTime.Now,
                    PostTime= DateTime.Now,
                    ReleaseYear = 1999,
                    Millage = 300000,
                    CarBrandId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    CarModelId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new Lot
                {
                    Id = Guid.NewGuid(),
                    Color = "White",
                    PostDate = DateTime.Now,
                    PostTime = DateTime.Now,
                    ReleaseYear = 2005,
                    Millage = 199213,
                    CarBrandId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    CarModelId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                }
                );
        }
    }
}
