using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using LoggerService;
using Moq;
using Service;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApp;

namespace Tests
{
    public class CarBrandTests
    {
        private ICarBrandService carBrandService;
        private IMapper mapper;
        private Mock<ICarBrandRepository> mockBrandRepository = new Mock<ICarBrandRepository>();


        public CarBrandTests()
        {

            var mockRepositoryManager = new Mock<IRepositoryManager>();
            mockRepositoryManager.Setup(repo => repo.CarBrand).Returns(mockBrandRepository.Object);



            var configurationMap = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();

            });
            mapper = new Mapper(configurationMap);

            carBrandService = new CarBrandService(mockRepositoryManager.Object,
                                            new LoggerManager(),
                                            mapper);
        }


        [Fact]
        public void GetAllCarBrandsRetrunsThreeItems()
        {
            mockBrandRepository.Setup(repo => repo.GetAllCarBrandsAsync(It.IsAny<CarBrandParameters>(), false).Result)
                    .Returns(GetTestCarBrads());
            // Act
            var result = carBrandService.GetAllCarBrandsAsync(new CarBrandParameters(), trackChanges: false).Result;

            // Assert
            var viewResult = Assert.IsType<(IEnumerable<CarBrandDTO> carBrands, MetaData metaData)>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CarBrandDTO>>(viewResult.carBrands);
            Assert.Equal(GetTestCarBrads().Count, model.Count());
        }

        [Fact]
        public void GetCarBrandById()
        {
            var id = new Guid("7fb8e9db-6ab3-4e0f-8f02-699253c1c8c1");
            mockBrandRepository.Setup(repo => repo.GetCarBrandAsync(id, false).Result)
                    .Returns(new CarBrand() { Id = new Guid("7fb8e9db-6ab3-4e0f-8f02-699253c1c8c1"), Name = "A", });
            // Act
            var result = carBrandService.GetCarBrandAsync(id, trackChanges: false).Result;

            // Assert
            var viewResult = Assert.IsType<CarBrandDTO>(result);
            var testDTO = mapper.Map<CarBrandDTO>(GetTestCarBrads().First());
            var properties = typeof(CarBrandDTO).GetProperties();
            foreach (var property in properties)
            {
                var expectedValue = property.GetValue(testDTO);
                var actualValue = property.GetValue(viewResult);

                Assert.Equal(expectedValue, actualValue);
            }
        }


        [Fact]
        public async Task CreateCarBrand()
        {
            var carBrandDTO = new CarBrandForCreationDTO("D", null);
            var carBrandEntity = mapper.Map<CarBrand>(carBrandDTO);

            var result = await carBrandService.CreateCarBrandAsync(carBrandDTO);
            Assert.NotNull(result);
            Assert.IsType<CarBrandDTO>(result);
        }

        [Fact]
        public void GetCarBrandIncorrectId()
        {
            var id = new Guid("7fb8e9db-6ab3-4e0f-8f02-699253c1c8c9");
            mockBrandRepository.Setup(repo => repo.GetCarBrandAsync(id, false).Result)
                    .Throws(new CarBrandNotFoundException(id));
            // Act

            //Assert
            var exception = Assert.Throws<AggregateException>(() => carBrandService.GetCarBrandAsync(id, trackChanges: false).Result);
            Assert.NotNull(exception);
            Assert.Equal($"The car brand with id: {id} doesn't exist in the database.", exception.InnerException.Message);
        }

        [Fact]
        public async Task UpdateCarBrandCorrectDTO()
        {
            var id = new Guid("7fb8e9db-6ab3-4e0f-8f02-699253c1c8c1");
            var carBrandDto = new CarBrandForUpdateDTO() { Name = "New Name" };

            mockBrandRepository.Setup(repo => repo.GetCarBrandAsync(id, false).Result)
                   .Returns(new CarBrand() { Id = id, Name = "A", });
            await carBrandService.UpdateCarBrandAsync(id, carBrandDto, false);
        }

        //[Fact]
        //public async Task UpdateCarBrandIncorrecttDTONameLength61()
        //{
        //    var id = new Guid("7fb8e9db-6ab3-4e0f-8f02-699253c1c8c1");
        //    var carBrandDto = new CarBrandForUpdateDTO() { Name = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" };

        //    mockBrandRepository.Setup(repo => repo.GetCarBrandAsync(id, false).Result)
        //           .Returns(new CarBrand() { Id = id, Name = "A", });
        //    await carBrandService.UpdateCarBrandAsync(id, carBrandDto, false);
        //}

        private PagedList<CarBrand> GetTestCarBrads()
        {
            return new PagedList<CarBrand>(
                    new List<CarBrand>()
                    {
                        new CarBrand() { Id = new Guid("7fb8e9db-6ab3-4e0f-8f02-699253c1c8c1"), Name= "A", },
                        new CarBrand() { Id = new Guid("7fb8e9db-6ab3-4e0f-8f02-699253c1c8c2"), Name = "B",},
                        new CarBrand() { Id = new Guid("7fb8e9db-6ab3-4e0f-8f02-699253c1c8c3"), Name = "C" },
                    },
                    count: 10,
                    pageNumber: 1,
                    pageSize: 10
                    );
        }

    }

    
}

    
