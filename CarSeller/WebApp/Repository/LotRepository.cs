using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LotRepository : RepositoryBase<Lot>, ILotRepository
    {
        public LotRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<PagedList<Lot>> GetAllLotsAsync(LotParameters lotParameters, bool trackChanges)
        {
            var lots = await
            FindAll(trackChanges)
            .Search(lotParameters.SearchTerm)
            .Sort(lotParameters.OrderBy)
            .ToListAsync();

            return PagedList<Lot>.ToPagedList(lots,
                lotParameters.PageNumber, lotParameters.PageSize);
        }

        public async Task<Lot> GetLotAsync(Guid lotId, bool trackChanges) => await
            FindByCondition(x => x.Id.Equals(lotId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateLot(Guid carBrandId, Guid carModelId, Lot lot)
        {
            lot.CarBrandId = carBrandId;
            lot.CarModelId = carModelId;
            Create(lot);
        }
        public void DeleteLot(Lot lot) => Delete(lot);

    }
}
