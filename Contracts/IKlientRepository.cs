using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IKlientRepository
    {
        IEnumerable<Klient> GetAllKlients(bool trackChanges);
        Klient GetKlient(Guid KlientsId, bool trackChanges);
        void CreateKlient(Klient klient);
        IEnumerable<Klient> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    }
}
