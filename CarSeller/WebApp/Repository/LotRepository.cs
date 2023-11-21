using Contracts;
using Entities.Models;
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

        public IEnumerable<Lot> GetAllLots(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(x => x.PostDate)
            .ToList();

        public Lot GetLot(Guid lotId, bool trackChanges) =>
            FindByCondition(x => x.Id.Equals(lotId), trackChanges)
            .SingleOrDefault();

    }
}
