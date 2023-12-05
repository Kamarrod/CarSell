using AutoMapper.Configuration.Annotations;
using Contracts;
using Moq;
using Entities.Models;
using Shared.RequestFeatures;
using Service.Contracts;
using System.Dynamic;
using Service;
using WebApp.Presentation.Controllers;
using Shared.DataTransferObjects;

namespace Tests
{
    public class LotTests  : IClassFixture<TestFixture>
    {
        private readonly IServiceManager _service;

        public LotTests(TestFixture fixture)
        {
            _service = fixture.ServiceManager;
        }

        [Fact]
        public void TestGetAllLotsReturnsThreeItems()
        {
            var mock = new Mock<IRepositoryManager>();
            mock.Setup(repo => repo.Lot.GetAllLotsAsync(new LotParameters(), false).Result)
                .Returns(GetTestLots());

            var result = _service.LotService.GetAllLotsAsync(new LotParameters(), trackChanges:false).Result;

            var viewResult = Assert.IsType<(IEnumerable<ExpandoObject> lots, MetaData metaData)> (result);
            var model = Assert.IsAssignableFrom<IEnumerable<Lot>>(viewResult.lots);
            Assert.Equal(GetTestLots().Count, model.Count());

        }

        [Fact]
        //public void TestGetLotById()
        //{
        //    var mock = new Mock<IRepositoryManager>();
        //    mock.Setup(repo => repo.Lot.GetLotAsync(new Guid("7fb8e9db-6ab3-4e0f-8f02-699253c1c8c1"), false).Result)
        //        .Returns(GetTestLots().First());

        //    var result = _service.LotService.GetLotAsync(new Guid("7fb8e9db-6ab3-4e0f-8f02-699253c1c8c1"), trackChanges: false).Result;

        //    //var viewResult = Assert.IsType<LotDTO>(result);
        //    //var model = Assert.IsAssignableFrom<IEnumerable<Lot>>(viewResult.lots);
        //    //Assert.Equal(GetTestLots(), model.Count());

        //}

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
                            PostDate = DateTime.Now,
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
                            PostDate = DateTime.Now,
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
                            PostDate = DateTime.Now,
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