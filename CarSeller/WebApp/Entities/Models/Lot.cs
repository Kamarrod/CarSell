using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Lot
    {
        [Column("LotId")]
        public Guid Id { get; set; }

        //public string? Color { get; set; }
        public string? Description { get; set; }
        public DateTime PostDate { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be a non-negative number.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        // Нужно изменить макс значние 
        [Range(1860, int.MaxValue, ErrorMessage = "ReleaseYear  must be a non-negative number.")]
        public int ReleaseYear { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Millage must be a non-negative number.")]
        public int Millage { get; set; }

        [ForeignKey(nameof(CarBrand))]
        public Guid CarBrandId { get; set;}
        public CarBrand? Brand { get; set; }

        [ForeignKey(nameof(CarModel))]
        [Required]
        public Guid CarModelId { get; set;}

        public CarModel? Model { get; set; }
    }
}
