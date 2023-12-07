using AutoMapper.Configuration.Annotations;
using Contracts;
using Moq;
using Entities.Models;
using Shared.RequestFeatures;
using Service.Contracts;
using System.Dynamic;
using Service;
using Service.DataShaping;
using WebApp.Presentation.Controllers;
using Shared.DataTransferObjects;
using AutoMapper;
using WebApp;
using LoggerService;
using Entities.Exceptions;

namespace Tests
{
    public class LotTests  //: IClassFixture<TestFixture>
    {
        private ILotService lotService;
        private IMapper mapper;
        private Mock<ILotRepository> mockLotRepository = new Mock<ILotRepository>();
        public LotTests()
        {
            
            var mockRepositoryManager = new Mock<IRepositoryManager>();
            mockRepositoryManager.Setup(repo => repo.Lot).Returns(mockLotRepository.Object);
            

            var configurationMap = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>(); 
                                                  
            });

            //var assembly = typeof(LotService).GetTypeInfo().Assembly;
            

            //var internalClassType = assembly.GetType("Namespace.Of.Your.InternalClass.LotService");

            //var constructorParameters = new object[]
            //{
            //    new Mock<IRepositoryManager>().Object,
            //    new LoggerManager(),
            //    new Mapper(new MapperConfiguration(cfg => {})),
            //    new DataShaper<LotDTO>()
            //};


            //var internalClassInstance = Activator.CreateInstance(internalClassType, constructorParameters);

            mapper = new Mapper(configurationMap);

            lotService = new LotService(mockRepositoryManager.Object,
                                        new LoggerManager(),
                                        mapper,
                                        new DataShaper<LotDTO>());

        }

        [Fact]
        public void TestGetAllLotsReturnsThreeItems()
        {
            mockLotRepository.Setup(repo => repo.GetAllLotsAsync(It.IsAny<LotParameters>(), false).Result)
                .Returns(GetTestLots());
            // Act
            var result = lotService.GetAllLotsAsync(new LotParameters(), trackChanges: false).Result;

            // Assert
            var viewResult = Assert.IsType<(IEnumerable<ExpandoObject> lots, MetaData metaData)>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ExpandoObject>>(viewResult.lots);
            Assert.Equal(GetTestLots().Count, model.Count());

        }

        [Fact]
        public void TestGetLotById()
        {
            mockLotRepository.Setup(repo => repo.GetLotAsync(new Guid("7fb8e9db-6ab3-4e0f-8f02-699253c1c8c1"), false).Result)
             .Returns(GetTestLots().First());

            var result = lotService.GetLotAsync(new Guid("7fb8e9db-6ab3-4e0f-8f02-699253c1c8c1"), trackChanges: false).Result;

            var viewResult = Assert.IsType<LotDTO>(result);
            var testDTO = mapper.Map<LotDTO>(GetTestLots().First());
            var properties = typeof(LotDTO).GetProperties();
            foreach (var property in properties)
            {
                var expectedValue = property.GetValue(testDTO);
                var actualValue = property.GetValue(viewResult);

                Assert.Equal(expectedValue, actualValue);
            }

        }

        [Fact]
        public void TestCreateLot()
        {
            mockLotRepository.Setup(repo => repo.GetLotAsync(new Guid("7fb8e9db-6ab3-4e0f-8f02-699253c1c8c1"), false).Result)
             .Returns(GetTestLots().First());

            var result = lotService.GetLotAsync(new Guid("7fb8e9db-6ab3-4e0f-8f02-699253c1c8c1"), trackChanges: false).Result;

            var viewResult = Assert.IsType<LotDTO>(result);
            var testDTO = mapper.Map<LotDTO>(GetTestLots().First());
            var properties = typeof(LotDTO).GetProperties();
            foreach (var property in properties)
            {
                var expectedValue = property.GetValue(testDTO);
                var actualValue = property.GetValue(viewResult);

                Assert.Equal(expectedValue, actualValue);
            }

        }


        private PagedList<Lot> GetTestLots()
        {
            return new PagedList<Lot>(
                    new List<Lot>()
                    {
                        new Lot()
                        {
                            Id = new Guid("7fb8e9db-6ab3-4e0f-8f02-699253c1c8c1"),
                            CarBrandId= new Guid(),
                            CarModelId= new Guid(),
                            Description = "asd",
                            Millage = 123,
                            PostDate = DateTime.Parse("06.12.2023 0:02:00"),
                            Price = 0,
                            ReleaseYear = 2022
                        },
                        new Lot()
                        {
                            Id = new Guid("7fb8e9db-6ab3-4e0f-8f02-699253c1c8c2"),
                            CarBrandId= new Guid(),
                            CarModelId= new Guid(),
                            Description = "aewrsd",
                            Millage = 1231,
                            PostDate = DateTime.Parse("26.12.2023 0:02:00"),
                            Price = 10,
                            ReleaseYear = 2000
                        },
                        new Lot()
                        {
                            Id = new Guid("7fb8e9db-6ab3-4e0f-8f02-699253c1c8c3"),
                            CarBrandId= new Guid(),
                            CarModelId= new Guid(),
                            Description = "olf",
                            Millage = 12300,
                            PostDate = DateTime.Parse("16.12.2023 0:02:00"),
                            Price = 1230,
                            ReleaseYear = 2001
                        },
                    },
                    count: 10,
                    pageNumber: 1,
                    pageSize: 10
                    );
        }
    }
}