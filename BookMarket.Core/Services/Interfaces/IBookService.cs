using BookMarket.Core.Dto;
using BookMarket.Core.Models;
using System.Collections.Generic;

namespace BookMarket.Core.Services
{
    public interface IBookService
    {
        void AddBook(BookRegistrationInfo bookRegistrationInfo);
        IEnumerable<BookEntity> GetAllBook();
        BookEntity GetBookById(int id);
        void RemoveBook(int id);
    }
}