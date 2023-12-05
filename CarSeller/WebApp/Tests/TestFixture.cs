using AutoMapper;
using Service.Contracts;
using Service;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects;
using LoggerService;
using Service.DataShaping;
using Repository;
using WebApp;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class TestFixture
    {
        public IServiceManager ServiceManager { get; }

        public TestFixture()
        {
            var configurationMap = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>(); // Добавляем ваш профиль маппинга
                                                  // Добавьте другие настройки по мере необходимости
            });


            var mapperMock = new Mapper(configurationMap);

            var repositoryManagerMock = new RepositoryManager( new RepositoryContext(builder.Options));
            var loggerManagerMock = new LoggerManager();
            var dataShaperM = new DataShaper<CarModelDTO>();
            var dataShaperL = new DataShaper<LotDTO>();
            IConfiguration configuration = null;
            UserManager<User> userManager = null;


            // Добавьте другие зависимости, если необходимо

            // Создайте экземпляр ServiceManager с фейковыми или моковыми зависимостями
            ServiceManager = new ServiceManager(
                repositoryManagerMock,
                loggerManagerMock,
                mapperMock,
                dataShaperM,
                dataShaperL,
                userManager,
                configuration
                // Передайте другие зависимости, если необходимо
            );
        }
    }
}
