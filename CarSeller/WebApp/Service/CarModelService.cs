﻿using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class CarModelService : ICarModelService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<CarModelDTO> _dataShaper;
        public CarModelService(IRepositoryManager repository,
                               ILoggerManager logger,
                               IMapper mapper,
                               IDataShaper<CarModelDTO> dataShaper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<(IEnumerable<ExpandoObject> carModels, MetaData metaData )> GetCarModelsAsync
            (Guid carBrandId, CarModelParameters carModelParameters, bool trackChanges)
        {
            var carBrand = await _repository
                .CarBrand
                .GetCarBrandAsync(carBrandId, trackChanges);

            if (carBrand == null)
                throw new CarBrandNotFoundException(carBrandId);
            var carModelsWithMetaData = await _repository
                .CarModel
                .GetCarModelsAsync(carBrandId, carModelParameters ,trackChanges);

            var carModelsDTO = _mapper.Map<IEnumerable<CarModelDTO>>(carModelsWithMetaData);
            var shapeData = _dataShaper.ShapeData(carModelsDTO, carModelParameters.Fields);
            return (carModels : shapeData, metaData : carModelsWithMetaData.MetaData);
        }

        public async Task<CarModelDTO> GetCarModelAsync(Guid carModelId,Guid carBrandId, bool trackChanges)
        {
            var carBrand = await _repository
                .CarBrand
                .GetCarBrandAsync(carBrandId, trackChanges);

            if (carBrand == null)
                throw new CarBrandNotFoundException(carBrandId);

            var carModel = await _repository
                .CarModel
                .GetCarModelAsync(carModelId, carBrandId, trackChanges);

            if (carModel == null)
                throw new CarModelNotFoundException(carModelId);

            var carModelDTO = _mapper.Map<CarModelDTO>(carModel);
            return carModelDTO;
        }

        public async Task<CarModelDTO> CreateCarModelAsync(Guid carBrandId, CarModelForCreationDTO carModelForCreation, bool trackChanges)
        {
            var carBrand = await _repository.CarBrand.GetCarBrandAsync(carBrandId, trackChanges);
            if (carBrand == null)
                throw new CarBrandNotFoundException(carBrandId);

            var carModelEntity = _mapper.Map<CarModel>(carModelForCreation);
            _repository.CarModel.CreateCarModel(carBrandId, carModelEntity);
            await _repository.SaveAsync();

            var carModelDTO = _mapper.Map<CarModelDTO>(carModelEntity);
            return carModelDTO;
        }

        public async Task DeleteCarModelAsync(Guid carBrandId, Guid carModelId, bool trackChanges) 
        {
            var carBrand = await _repository.CarBrand.GetCarBrandAsync(carBrandId, trackChanges);
            if (carBrand is null)
                throw new CarBrandNotFoundException(carBrandId);

            var carModel = await _repository.CarModel.GetCarModelAsync(carModelId, carBrandId, trackChanges);
            if (carModel is null)
                throw new CarModelNotFoundException(carModelId);

            _repository.CarModel.DeleteCarModel(carModel);
            await _repository.SaveAsync();
        }

        public async Task UpdateCarModelAsync(Guid carBrandId, Guid carModelId, CarModelForUpdateDTO carModelForUpdateDTO,
                                   bool brandTrackChanges, bool modelTrackChanges)
        {
            var carBrand = await _repository.CarBrand.GetCarBrandAsync(carBrandId, brandTrackChanges);
            if (carBrand is null)
                throw new CarBrandNotFoundException(carBrandId);

            var carModel = await _repository.CarModel.GetCarModelAsync(carModelId, carBrandId, modelTrackChanges);
            if (carModel is null)
                throw new CarModelNotFoundException(carModelId);
            _mapper.Map(carModelForUpdateDTO,carModel);

            await _repository.SaveAsync();
        }

        public async Task<(CarModelForUpdateDTO carModelToPatch, CarModel carModelEntity)> GetCarModelForPatchAsync(
            Guid carBrandId, Guid carModelId, bool brandTrackChanges, bool modelTrackChanges)
        {
            var carBrand = await _repository.CarBrand.GetCarBrandAsync(carBrandId, brandTrackChanges);
            if (carBrand is null)
                throw new CarBrandNotFoundException(carBrandId);

            var carModelEntity = await _repository.CarModel.GetCarModelAsync(carModelId, carBrandId, modelTrackChanges);
            if (carModelEntity is null)
                throw new CarModelNotFoundException(carModelId);

            var carModelToPatch = _mapper.Map<CarModelForUpdateDTO>(carModelEntity);

            return (carModelToPatch, carModelEntity);
        }

        public async Task SaveChangesForPatchAsync(CarModelForUpdateDTO carModelToPatch, CarModel carModelEntity)
        {
            _mapper.Map(carModelToPatch, carModelEntity);
            await _repository.SaveAsync();
        }
    }
}
