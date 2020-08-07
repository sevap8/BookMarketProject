using BookMarket.Core.Models;
using BookMarket.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMarket.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookMarketDbContext dbContext;
        public BookRepository(BookMarketDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(BookEntity bookEntity)
        {
            this.dbContext.Books.Add(bookEntity);
        }

        public BookEntity GetById(int id)
        {
            return dbContext.Books.Where(a => a.Id == id).FirstOrDefault();
        }

        public IEnumerable<BookEntity> GetAll()
        {
            return dbContext.Books.Select(a => a);
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }

        public bool ContainsId(int entityId)
        {
            return this.dbContext.Books.Any(a =>
        a.Id == entityId);
        }

        public bool Contains(BookEntity bookEntity)
        {
             return this.dbContext.Books.Any(a =>
            a.Name == bookEntity.Name
            && a.Year == bookEntity.Year
            && a.Cost == bookEntity.Cost);
        }

        public void Remove(BookEntity bookEntity)
        {
            this.dbContext.Books.Remove(bookEntity);
        }
    }
}
