using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager: IServiceManager
    {
        private readonly Lazy<ILotService> _lotService;
        private readonly Lazy<ICarBrandService> _carBrandService;
        private readonly Lazy<ICarModelService> _carModelService;

        public ServiceManager(IRepositoryManager repositoryManager,
                              ILoggerManager loggerManager,
                              IMapper mapper,
                              IDataShaper<CarModelDTO> dataShaper)
        {
            _lotService = new Lazy<ILotService>(() => 
                new LotService(repositoryManager, loggerManager, mapper));

            _carModelService = new Lazy<ICarModelService>(() => 
                new CarModelService(repositoryManager, loggerManager, mapper, dataShaper )) ;

            _carBrandService = new Lazy<ICarBrandService>(() => 
                new CarBrandService(repositoryManager, loggerManager, mapper));
        }

        public ICarBrandService CarBrandService => _carBrandService.Value;

        public ILotService LotService => _lotService.Value;

        public ICarModelService CarModelService => _carModelService.Value;
    }
}
