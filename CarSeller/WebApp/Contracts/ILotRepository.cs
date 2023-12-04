using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ILotRepository
    {
        Task<PagedList<Lot>> GetAllLotsAsync(LotParameters lotParameters, bool trackChanges);
        Task<Lot> GetLotAsync(Guid lotId, bool trackChanges);
        void CreateLot(Guid carModelId, Guid carBrandId, Lot lot);
        void DeleteLot(Lot lot);
    }
}
