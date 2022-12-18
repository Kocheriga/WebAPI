using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using Repository.Extensions.Utility;

namespace Repository.Extensions
{
    public static class RepositoryEmployeeExtensions
    {
        public static IQueryable<Prodaja> FilterProdajas(this IQueryable<Prodaja>
        prodajas, uint minCost, uint maxCost) =>
            prodajas.Where(e => (e.Money >= minCost && e.Money <= maxCost));
        public static IQueryable<Prodaja> Search(this IQueryable<Prodaja>
       prodajas,
        string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return prodajas;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return prodajas.Where(e => e.Tovar.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Prodaja> Sort(this IQueryable<Prodaja> prodajas,
string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return prodajas.OrderBy(e => e.Tovar);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Prodaja>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                    return prodajas.OrderBy(e => e.Tovar);
            return prodajas.OrderBy(orderQuery);
        }
    }
}
