using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class CarBrandService : ICarBrandService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CarBrandService(IRepositoryManager repository,
                               ILoggerManager logger,
                               IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<CarBrandDTO> carBrands, MetaData metaData)> GetAllCarBrandsAsync
            ( CarBrandParameters carBrandParameters, bool trackChanges)
        {
                var carBrandWithMetaData = await _repository.CarBrand.GetAllCarBrandsAsync(carBrandParameters, trackChanges);

                var carBrandsDTO = _mapper.Map<IEnumerable<CarBrandDTO>>(carBrandWithMetaData);
            return (carBrands: carBrandsDTO, metaData: carBrandWithMetaData.MetaData);
        }

        public async Task<CarBrandDTO> GetCarBrandAsync(Guid carBrandId, bool trackChanges)
        {
            var carBrand = await _repository.CarBrand.GetCarBrandAsync(carBrandId, trackChanges);
            if (carBrand == null)
                throw new CarBrandNotFoundException(carBrandId);
            var carBrandDTO = _mapper.Map<CarBrandDTO>(carBrand);
            return carBrandDTO;
        }

        public async Task<CarBrandDTO> CreateCarBrandAsync(CarBrandForCreationDTO carBrand)
        {
            var carBrandEntity = _mapper.Map<CarBrand>(carBrand);
            _repository.CarBrand.CreateCarBrand(carBrandEntity);
            await _repository.SaveAsync();

            var carBradtDTO = _mapper.Map<CarBrandDTO>(carBrandEntity);
            return carBradtDTO;
        }

        public async Task DeleteCarBrandAsync(Guid carBrandId, bool trackChanges) 
        {
            var carBrand = await _repository.CarBrand.GetCarBrandAsync(carBrandId, trackChanges);
            if (carBrand is null)
                throw new CarBrandNotFoundException(carBrandId);

            _repository.CarBrand.DeleteCarBrand(carBrand);
            await _repository.SaveAsync();
        }

        public async Task UpdateCarBrandAsync(Guid carBrandId, CarBrandForUpdateDTO carBrandForUpdateDTO, bool trackChanges)
        {
            var carBrand = await _repository.CarBrand.GetCarBrandAsync(carBrandId, trackChanges);
            if (carBrand is null)
                throw new CarBrandNotFoundException(carBrandId);

            _mapper.Map(carBrandForUpdateDTO, carBrand);
            await _repository.SaveAsync();
        }
    }
}
