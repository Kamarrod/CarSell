using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ILotRepository
    {
        Task<IEnumerable<Lot>> GetAllLotsAsync(bool trackChanges);
        Task<Lot> GetLotAsync(Guid lotId, bool trackChanges);
    }
}
