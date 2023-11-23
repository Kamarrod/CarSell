using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICarBrandRepository
    {
        Task<PagedList<CarBrand>> GetAllCarBrandsAsync(CarBrandParameters carBrandParameters, bool trackChanges);
        Task<CarBrand> GetCarBrandAsync(Guid carbrandId, bool trackChanges);
        void CreateCarBrand(CarBrand carBrand);
        void DeleteCarBrand(CarBrand carBrand);
    }
}
