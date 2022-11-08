using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProdajaRepository
    {
        Task<IEnumerable<Prodaja>> GetProdajasAsync(Guid klientsId, bool trackChanges);
        Task<Prodaja> GetProdajaAsync(Guid klientsId, Guid Id, bool trackChanges);
        void CreateProdajaForKlient(Guid KlientsId, Prodaja prodaja);
        void DeleteProdaja(Prodaja prodaja);
    }
}
