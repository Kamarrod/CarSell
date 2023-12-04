using Entities.Models;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using Repository.Extensions.Utility;

namespace Repository.Extensions
{
    public static class RepositoryLotExtensions
    {
        public static IQueryable<Lot> Search(this IQueryable<Lot> lots,
                string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return lots;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return lots
                .Where(x => x.Description
                .ToLower()
                .Contains(lowerCaseTerm));
        }

        public static IQueryable<Lot> Sort(this IQueryable<Lot> lots, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return lots.OrderBy(x => x.PostDate);

            var orderQuery = OrderQueryBuilder<Lot>.CreateOrderQuery<Lot>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return lots.OrderBy(e => e.PostDate);

            return lots.OrderBy(orderQuery);
        }
    }
}
