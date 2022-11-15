using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProdajaRepository
    {
        Task<PagedList<Prodaja>> GetProdajasAsync(Guid klientsId, ProdajaParameters
prodajaParameters, bool trackChanges);
        Task<Prodaja> GetProdajaAsync(Guid klientsId, Guid Id, bool trackChanges);
        void CreateProdajaForKlient(Guid KlientsId, Prodaja prodaja);
        void DeleteProdaja(Prodaja prodaja);
    }
}
