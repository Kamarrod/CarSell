﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CarBrand
    {
        [Column("CarBrandId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Brand name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 35 characters.")]
        public string? Name { get; set; }

        public ICollection<CarModel>? Models { get; set; }
    }
}
