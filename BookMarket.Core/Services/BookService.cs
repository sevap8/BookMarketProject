using BookMarket.Core.Dto;
using BookMarket.Core.Models;
using BookMarket.Data.Repositories;
using System;
using System.Collections.Generic;

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
                throw new ArgumentException("This book has been registered. Can't continue");
            }

            this.bookRepository.Add(bookEntity);
            this.bookRepository.Save();
        }

        public void RemoveBook(int id)
        {
            if (!bookRepository.ContainsId(id))
            {
                throw new ArgumentException($"This book is missing {id}! ");
            }

            this.bookRepository.Remove(bookRepository.GetById(id));
            this.bookRepository.Save();
        }

        public BookEntity GetBookById(int id)
        {
            if (!bookRepository.ContainsId(id))
            {
                throw new ArgumentException($"This book is missing {id}! ");
            }

            return bookRepository.GetById(id);
        }

        public IEnumerable<BookEntity> GetAllBook()
        {
            var allBook = bookRepository.GetAll();
            if (allBook == null)
            {
                throw new ArgumentException($"The list is empty! ");
            }

            return allBook;
        }
    }
}
