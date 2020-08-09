using BookMarket.Core.Models;
using System.Collections.Generic;

namespace BookMarket.Data.Repositories
{
    public interface IСustomerRepository
    {
        void Add(СustomerEntity сustomerEntity);
        bool Contains(СustomerEntity сustomerEntity);
        bool ContainsId(int entityId);
        IEnumerable<СustomerEntity> GetAll();
        СustomerEntity GetById(int id);
        void Remove(СustomerEntity сustomerEntity);
        void Save();
    }
}