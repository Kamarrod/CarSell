using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class LotNotFoundException : NotFoundException
    {
        public LotNotFoundException(Guid lotId)
            : base($"The lot with id: {lotId} doesn't exist in the database.")
        { }
    }
}
