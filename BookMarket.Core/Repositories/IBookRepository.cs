using BookMarket.Core.Models;
using System.Collections.Generic;

namespace BookMarket.Data.Repositories
{
    public interface IBookRepository
    {
        void Add(BookEntity bookEntity);
        bool Contains(BookEntity bookEntity);
        bool ContainsId(int entityId);
        IEnumerable<BookEntity> GetAll();
        BookEntity GetById(int id);
        void Remove(BookEntity bookEntity);
        void Save();
    }
}