using Entities.Models;
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
    public interface ICarModelService
    {
        Task<(IEnumerable<ExpandoObject> carModels, MetaData metaData)> GetCarModelsAsync
            (Guid carBrandId, CarModelParameters carModelParameters ,bool trackChanges);
        Task<CarModelDTO> GetCarModelAsync(Guid carModelId, Guid carBrandId, bool trackChanges);
        Task<CarModelDTO> CreateCarModelAsync
            (Guid carBrandId, CarModelForCreationDTO carModelForCreation, bool trackChanges);
        Task DeleteCarModelAsync(Guid carBrandId, Guid carModelId, bool trackChanges);
        Task UpdateCarModelAsync(Guid carBrandId, Guid carModelId, CarModelForUpdateDTO carModelForUpdate,
                            bool brandTrackChanges, bool modelTrackChanges);
        Task<(CarModelForUpdateDTO carModelToPatch, CarModel carModelEntity)> GetCarModelForPatchAsync(
            Guid carBrandId, Guid carModelId, bool brandTrackChanges, bool modelTrackChanges);
        Task SaveChangesForPatchAsync(CarModelForUpdateDTO carModelToPatch, CarModel carModelEntity);

    }
}
