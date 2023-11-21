using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICarBrandService
    {
        Task<IEnumerable<CarBrandDTO>> GetAllCarBrandsAsync(bool trackChanges);
        Task<CarBrandDTO> GetCarBrandAsync(Guid carBrandId, bool trackChanges);
        Task<CarBrandDTO> CreateCarBrandAsync(CarBrandForCreationDTO carBrand);
        Task DeleteCarBrandAsync(Guid carBrandId, bool trackChanges);
        Task UpdateCarBrandAsync(Guid carBrandId, CarBrandForUpdateDTO carBrandForUpdateDTO, bool trackChanges);
    }
}
