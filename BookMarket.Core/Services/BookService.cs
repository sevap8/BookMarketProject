using BookMarket.Core.Dto;
using BookMarket.Core.Models;
using BookMarket.Core.Services.Interfaces;
using BookMarket.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarket.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void AddBook(BookRegistrationInfo bookRegistrationInfo)
        {
            var bookEntity = new BookEntity
            {
                Amount = bookRegistrationInfo.Amount,
                Author = bookRegistrationInfo.Author,
                Cost = bookRegistrationInfo.Cost,
                Name = bookRegistrationInfo.Name,
                Year = bookRegistrationInfo.Year
            };

            if (bookRepository.Contains(bookEntity))
            {
                throw new ArgumentException("This meeting has been registered. Can't continue");
            }

            this.bookRepository.Add(bookEntity);
            this.bookRepository.Save();
        }
    }
}
