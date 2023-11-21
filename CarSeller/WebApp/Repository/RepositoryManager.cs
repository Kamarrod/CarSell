using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ILotRepository> _lotRepository;
        private readonly Lazy<ICarBrandRepository> _carBrandRepository;
        private readonly Lazy<ICarModelRepository> _carModelRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _lotRepository = new Lazy<ILotRepository>(() => new LotRepository(repositoryContext));
            _carBrandRepository = new Lazy<ICarBrandRepository>(() => new CarBrandRepository(repositoryContext));
            _carModelRepository = new Lazy<ICarModelRepository>(() => new CarModelRepository(repositoryContext));
        }

        public ILotRepository Lot => _lotRepository.Value;

        public ICarModelRepository CarModel => _carModelRepository.Value;
        public ICarBrandRepository CarBrand => _carBrandRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
