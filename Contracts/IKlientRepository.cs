using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IKlientRepository
    {
        Task<IEnumerable<Klient>> GetAllKlientsAsync(bool trackChanges);
        Task<Klient> GetKlientAsync(Guid KlientsId, bool trackChanges);
        void CreateKlient(Klient klient);
        Task<IEnumerable<Klient>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteKlient(Klient klient);
    }
}
