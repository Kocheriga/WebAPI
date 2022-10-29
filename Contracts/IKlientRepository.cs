using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IKlientRepository
    {
        IEnumerable<Klient> GetAllKlients(bool trackChanges);
        Klient GetKlient(int KlientsId, bool trackChanges);
    }
}
