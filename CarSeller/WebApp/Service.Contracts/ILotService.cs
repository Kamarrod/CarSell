using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ILotService
    {
        IEnumerable<LotDTO> GetAllLots(bool trackChanges);
        LotDTO GetLot(Guid lotId, bool trackChanges);
    }
}
