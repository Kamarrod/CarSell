using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CarModelNotFoundException : NotFoundException
    {
        public CarModelNotFoundException(Guid carModelId)
        : base($"The car model with id: {carModelId} doesn't exist in the database.")
        { }
    }
}
