using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CarBrandDTO
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
    }
}
