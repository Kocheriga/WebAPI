using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Extensions
{
    public static class RepositoryProdajaExtensions
    {
        public static IQueryable<Prodaja> FilterEmployees(this IQueryable<Prodaja>
        prodajas, uint minCost, uint maxCost) =>
            prodajas.Where(e => (e.Money >= minCost && e.Money <= maxCost));
        public static IQueryable<Prodaja> Search(this IQueryable<Prodaja> prodajas,
        string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return prodajas;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return prodajas.Where(e => e.Tovar.ToLower().Contains(lowerCaseTerm));
        }
    }
}
