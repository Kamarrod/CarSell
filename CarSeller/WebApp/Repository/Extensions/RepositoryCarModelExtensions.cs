using Entities.Models;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using Repository.Extensions.Utility;

namespace Repository.Extensions
{
    public static class RepositoryCarModelExtensions
    {
        public static IQueryable<CarModel> Search(this IQueryable<CarModel> carModels,
                string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return carModels;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return carModels
                .Where(x => x.Name
                .ToLower()
                .Contains(lowerCaseTerm));
        }

        public static IQueryable<CarModel> Sort(this IQueryable<CarModel> carModels, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return carModels.OrderBy(x => x.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<CarModel>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return carModels.OrderBy(e => e.Name);

            return carModels.OrderBy(orderQuery);
        }

    }
}
