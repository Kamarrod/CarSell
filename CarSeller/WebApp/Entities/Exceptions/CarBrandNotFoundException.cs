using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CarBrandNotFoundException : NotFoundException
    {
        public CarBrandNotFoundException(Guid carBrandId)
            : base($"The car brand with id: {carBrandId} doesn't exist in the database.")
        { }
    }
}
