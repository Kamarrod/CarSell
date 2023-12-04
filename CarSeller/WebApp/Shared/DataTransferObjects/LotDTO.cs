using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record LotDTO
    {

        public Guid Id { get; init; }
        //public string? Color { get; init; }
        public DateTime PostDate { get; init; }
        public Guid CarBrandId { get; init; }

        public string? Description { get; init; }
        public Guid CarModelId { get; init; }
        public decimal Price { get; init; }
        public int ReleaseYear { get; init; }
        public int Millage { get; init; }
        public string UserId { get; init; }

    }

    //public record LotDTO(Guid Id, string Color, DateTime PostDate, DateTime PostTime, int RealeaseYear, int Millage);

}
