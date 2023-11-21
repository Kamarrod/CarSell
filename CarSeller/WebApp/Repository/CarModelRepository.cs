﻿using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository
{
    public class CarModelRepository : RepositoryBase<CarModel>, ICarModelRepository
    {
        public CarModelRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }

        public async Task<CarModel> GetCarModelAsync(Guid carModelId, Guid carBrandId, bool trackChanges) => await
            FindByCondition(x => x.CarBrandId.Equals(carBrandId) && x.Id.Equals(carModelId), trackChanges)
            .SingleOrDefaultAsync();


        public async Task<IEnumerable<CarModel>> GetCarModelsAsync(Guid carBrandId,
                CarModelParameters carModelParameters, bool trackChanges) => await
            FindByCondition(x => x.CarBrandId.Equals(carBrandId), trackChanges)
            .OrderBy(x => x.Name)
            .Skip((carModelParameters.PageNumber - 1) * carModelParameters.PageSize)
            .Take(carModelParameters.PageSize)
            .ToListAsync();

        public void CreateCarModel(Guid carBrandId, CarModel carModel)
        {
            carModel.CarBrandId = carBrandId;
            Create(carModel);
        }

        public void DeleteCarModel(CarModel carModel) =>
            Delete(carModel);
    }
}
