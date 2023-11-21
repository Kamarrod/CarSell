using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ILotRepository Lot { get; }
        ICarModelRepository CarModel { get; }
        ICarBrandRepository CarBrand { get; }
        Task SaveAsync();
    }
}
