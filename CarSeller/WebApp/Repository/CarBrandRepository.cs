using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<CarBrand>> GetAllCarBrandsAsync(bool trackChanges) => await
            FindAll(trackChanges)
            .OrderBy(x => x.Name)
            .ToListAsync();

        public async Task<CarBrand> GetCarBrandAsync(Guid carBrandId, bool trackChanges) => await
            FindByCondition(x => x.Id.Equals(carBrandId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateCarBrand(CarBrand carBrand) => Create(carBrand);

        public void DeleteCarBrand(CarBrand carBrand) => Delete(carBrand);

    }
}
