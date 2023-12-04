using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager,
                              ILoggerManager loggerManager,
                              IMapper mapper,
                              IDataShaper<CarModelDTO> dataShaperModel,
                              IDataShaper<LotDTO> dataShaperLot,
                              UserManager<User> userManager,
                              IConfiguration configuration)
        {
            _lotService = new Lazy<ILotService>(() => 
                new LotService(repositoryManager, loggerManager, mapper, dataShaperLot));

            _carModelService = new Lazy<ICarModelService>(() => 
                new CarModelService(repositoryManager, loggerManager, mapper, dataShaperModel )) ;

            _carBrandService = new Lazy<ICarBrandService>(() => 
                new CarBrandService(repositoryManager, loggerManager, mapper));

            _authenticationService = new Lazy<IAuthenticationService>( () =>
            new AuthenticationService(loggerManager, mapper,userManager ,configuration));
        }

        public ICarBrandService CarBrandService => _carBrandService.Value;

        public ILotService LotService => _lotService.Value;

        public ICarModelService CarModelService => _carModelService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
