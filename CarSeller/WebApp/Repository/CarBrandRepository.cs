using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CarBrandRepository : RepositoryBase<CarBrand>, ICarBrandRepository
    {
        public CarBrandRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }

        public async Task<PagedList<CarBrand>> GetAllCarBrandsAsync(CarBrandParameters carBrandParameters ,bool trackChanges)
        {
            var carBradns = await
            FindAll(trackChanges)
            .Search(carBrandParameters.SearchTerm)
            .Sort(carBrandParameters.OrderBy)
            .ToListAsync();

            return PagedList<CarBrand>.ToPagedList(carBradns,
                carBrandParameters.PageNumber, carBrandParameters.PageSize);
        }

        public async Task<CarBrand> GetCarBrandAsync(Guid carBrandId, bool trackChanges) => await
            FindByCondition(x => x.Id.Equals(carBrandId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateCarBrand(CarBrand carBrand) => Create(carBrand);

        public void DeleteCarBrand(CarBrand carBrand) => Delete(carBrand);

    }
}
