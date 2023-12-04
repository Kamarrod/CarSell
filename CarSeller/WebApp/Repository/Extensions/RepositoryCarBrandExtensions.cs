using Entities.Models;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using Repository.Extensions.Utility;

namespace Repository.Extensions
{
    public static class RepositoryCarBrandExtensions
    {
        public static IQueryable<CarBrand> Search(this IQueryable<CarBrand> carBrands,
                string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return carBrands;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return carBrands
                .Where(x => x.Name
                .ToLower()
                .Contains(lowerCaseTerm));
        }

        public static IQueryable<CarBrand> Sort(this IQueryable<CarBrand> carBrands, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return carBrands.OrderBy(x => x.Name);

            var orderQuery = OrderQueryBuilder<CarBrand>.CreateOrderQuery<CarBrand>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return carBrands.OrderBy(e => e.Name);

            return carBrands.OrderBy(orderQuery);
        }
    }
}
