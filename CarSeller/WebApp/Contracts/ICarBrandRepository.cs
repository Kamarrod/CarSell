using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICarBrandRepository
    {
        Task<IEnumerable<CarBrand>> GetAllCarBrandsAsync(bool trackChanges);
        Task<CarBrand> GetCarBrandAsync(Guid carbrandId, bool trackChanges);
        void CreateCarBrand(CarBrand carBrand);
        void DeleteCarBrand(CarBrand carBrand);
    }
}
