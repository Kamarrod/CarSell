using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        ICarBrandService CarBrandService { get; }
        ILotService LotService { get; }
        ICarModelService CarModelService { get; }

    }
}
