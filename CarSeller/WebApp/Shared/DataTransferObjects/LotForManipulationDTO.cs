using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record LotForManipulationDTO
    {
        [Required]
        public Guid CarBrandId { get; init; }
        [Required]
        public Guid CarModelId { get; init; }
        [MaxLength(300, ErrorMessage = "Максимальная длина описнаия 300 символов")]
        public string Description { get; init; }
        //[Required(ErrorMessage = "")]
        //public string PostDate { get; init; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be a non-negative number.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "Укажите сумму!")]
        public decimal Price { get; init; }

        [Required(ErrorMessage = "Укжите год выпуска")]
        [Range(1860, int.MaxValue, ErrorMessage = "ReleaseYear  must be a non-negative number.")]
        public int ReleaseYear { get; init; }

        [Required(ErrorMessage = "Укажите пробег")]
        [Range(0, int.MaxValue, ErrorMessage = "Millage must be a non-negative number.")]
        public int Millage { get; init; }

        public string UserId { get; init; }
    }
}
