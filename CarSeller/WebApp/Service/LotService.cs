using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Dynamic;
using System.Security.Claims;

namespace Service
{
    internal sealed class LotService : ILotService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<LotDTO> _dataShaper;
        public LotService(IRepositoryManager repository,
                          ILoggerManager logger,
                          IMapper mapper,
                          IDataShaper<LotDTO> dataShaper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<(IEnumerable<ExpandoObject> lots, MetaData metaData)> GetAllLotsAsync
            (LotParameters lotParameters ,bool trackChanges)
        {
            var lotWithMetaData = await _repository
                .Lot
                .GetAllLotsAsync(lotParameters, trackChanges);

            var lotDTO = _mapper.Map<IEnumerable<LotDTO>>(lotWithMetaData);
            var shapeData = _dataShaper.ShapeData(lotDTO, lotParameters.Fields);
            return (lots : shapeData, metaData : lotWithMetaData.MetaData);
               
        }

        public async Task<LotDTO> GetLotAsync(Guid lotId, bool trackChanges) 
        {
            var lot = await _repository.Lot.GetLotAsync(lotId, trackChanges);
            if (lot == null)
                throw new LotNotFoundException(lotId);

            var lotDTO = _mapper.Map<LotDTO>(lot);
            return lotDTO;
        }

        public async Task UpdateLotAsync(Guid lotId, LotForUpdateDTO lotForUpdate, bool trackChanges)
        {
            var lot = await _repository.Lot.GetLotAsync(lotId, trackChanges);
            if (lot is null)
                throw new LotNotFoundException(lotId);

            _mapper.Map(lotForUpdate, lot);
            await _repository.SaveAsync();
        }

        public async Task<LotDTO> CreateLotAsync(LotForCreationDTO lotForCreation, bool trackChanges)
        {
            var carBrand = await _repository
                .CarBrand
                .GetCarBrandAsync(lotForCreation.CarBrandId, trackChanges : false);

            if (carBrand is null)
                throw new CarBrandNotFoundException(lotForCreation.CarBrandId);

            var carModel = await _repository
                .CarModel
                .GetCarModelAsync(lotForCreation.CarModelId, lotForCreation.CarBrandId, trackChanges: false);

            if (carModel is null)
                throw new CarModelNotFoundException(lotForCreation.CarModelId);

            var lotEntity = _mapper.Map<Lot>(lotForCreation);
            lotEntity.PostDate = DateTime.Now;
            
            _repository.Lot.CreateLot(lotEntity.CarBrandId, lotEntity.CarModelId, lotEntity);
            _repository.SaveAsync();

            var lotDTO = _mapper.Map<LotDTO>(lotEntity);
            return lotDTO;
        }

        public async Task DeleteLotAsync(Guid lotId, bool trackChanges)
        {
            var lot = await _repository.Lot.GetLotAsync(lotId, trackChanges: false);
            if (lot is null)
                throw new LotNotFoundException(lotId);

            _repository.Lot.DeleteLot(lot);
            await _repository.SaveAsync();
        }

        public async Task<(LotForUpdateDTO lotToPatch, Lot lotEntity)> GetLotForPatchAsync(Guid lotId, bool trackChanges)
        {
            var lotEntity = await _repository.Lot.GetLotAsync(lotId, trackChanges);
            if (lotEntity is null)
                throw new LotNotFoundException(lotId);

            var lotToPatch = _mapper.Map<LotForUpdateDTO>(lotEntity);
            return(lotToPatch, lotEntity);
        }
        public async Task SaveChangesForPatchAsync(LotForUpdateDTO lotToPatch, Lot lotEntity)
        {
            _mapper.Map(lotToPatch, lotEntity);
            await _repository.SaveAsync();
        }
    }
}
