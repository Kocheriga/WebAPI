using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IProdajaRepository
    {
        IEnumerable<Prodaja> GetProdajas(int KlientsId, bool trackChanges);
        Prodaja GetProdaja(int KlientsId, int Id, bool trackChanges);
        void CreateProdajaForKlient(int KlientId, Prodaja prodaja);
    }
}
