﻿using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;
using System.Security.Cryptography.X509Certificates;

namespace Repository
{
    public class CarModelRepository : RepositoryBase<CarModel>, ICarModelRepository
    {
        public CarModelRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }

        public async Task<CarModel> GetCarModelAsync(Guid carModelId, Guid carBrandId, bool trackChanges) => await
            FindByCondition(x => x.CarBrandId.Equals(carBrandId) && x.Id.Equals(carModelId), trackChanges)
            .SingleOrDefaultAsync();


        public async Task<PagedList<CarModel>> GetCarModelsAsync(Guid carBrandId,
                CarModelParameters carModelParameters, bool trackChanges)
        {
            var carModels = await FindByCondition(x => x.CarBrandId.Equals(carBrandId), trackChanges)
            .Search(carModelParameters.SearchTerm)
            .Sort(carModelParameters.OrderBy)
            .ToListAsync();

            return PagedList<CarModel>.ToPagedList(carModels,
                carModelParameters.PageNumber, carModelParameters.PageSize);
        }

        public void CreateCarModel(Guid carBrandId, CarModel carModel)
        {
            carModel.CarBrandId = carBrandId;
            Create(carModel);
        }

        public void DeleteCarModel(CarModel carModel) =>
            Delete(carModel);
    }
}
