using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IProdajaRepository
    {
        IEnumerable<Prodaja> GetProdajas(Guid klientsId, bool trackChanges);
        Prodaja GetProdaja(Guid klientsId, Guid Id, bool trackChanges);
        void CreateProdajaForKlient(Guid KlientsId, Prodaja prodaja);
        void DeleteProdaja(Prodaja prodaja);
    }
}
