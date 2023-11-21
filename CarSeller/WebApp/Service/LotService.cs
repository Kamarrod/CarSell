using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class LotService : ILotService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public LotService(IRepositoryManager repository,
                          ILoggerManager logger,
                          IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<LotDTO> GetAllLots(bool trackChanges)
        {

                var lots = _repository.Lot.GetAllLots(trackChanges);
                
                var lotsDTO = _mapper.Map<IEnumerable<LotDTO>>(lots);
                return lotsDTO;
        }

        public LotDTO GetLot(Guid lotId, bool trackChanges) 
        {
            var lot = _repository.Lot.GetLot(lotId, trackChanges);
            if (lot == null)
                throw new LotNotFoundException(lotId);

            var lotDTO = _mapper.Map<LotDTO>(lot);
            return lotDTO;
        }
    }
}
