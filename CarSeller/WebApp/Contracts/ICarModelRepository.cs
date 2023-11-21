using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICarModelRepository
    {
        Task<IEnumerable<CarModel>> GetCarModelsAsync(Guid carBrandId, bool trackChanges);
        Task<CarModel> GetCarModelAsync(Guid carModelId, Guid carBrandId, bool trackChanges);
        void CreateCarModel(Guid carBrandId, CarModel carModel);
        void DeleteCarModel(CarModel carModel);
    }
}
