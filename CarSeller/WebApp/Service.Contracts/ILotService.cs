using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ILotService
    {
        Task<(IEnumerable<ExpandoObject> lots, MetaData metaData)> GetAllLotsAsync
            (LotParameters lotParameters, bool trackChanges);
        Task<LotDTO> GetLotAsync(Guid lotId, bool trackChanges);
        Task<LotDTO> CreateLotAsync(LotForCreationDTO lotForCreation, bool trackChanges);
        Task UpdateLotAsync(Guid lotId, LotForUpdateDTO lotForUpdate, bool trackChanges);

    }
}
