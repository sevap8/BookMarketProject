using BookMarket.Core.Models;
using System.Collections.Generic;

namespace BookMarket.Data.Repositories
{
    public interface IWriterRepository
    {
        void Add(WriterEntity writerEntity);
        bool Contains(WriterEntity writerEntity);
        bool ContainsId(int entityId);
        IEnumerable<WriterEntity> GetAll();
        WriterEntity GetById(int id);
        void Remove(WriterEntity writerEntity);
        void Save();
    }
}