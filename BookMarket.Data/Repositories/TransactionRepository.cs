using BookMarket.Core.Models;
using BookMarket.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMarket.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BookMarketDbContext dbContext;
        public TransactionRepository(BookMarketDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(TransactionEntity transactionEntity)
        {
            this.dbContext.Transactions.Add(transactionEntity);
        }

        public TransactionEntity GetById(int id)
        {
            return dbContext.Transactions.Where(a => a.Id == id).FirstOrDefault();
        }

        public IEnumerable<TransactionEntity> GetAll()
        {
            return dbContext.Transactions.Select(a => a);
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

        public bool Contains(TransactionEntity transactionEntity)
        {
             return this.dbContext.Transactions.Any(a =>
            a.СustomerId == transactionEntity.СustomerId
            && a.Сustomer == transactionEntity.Сustomer
            && a.BookId == transactionEntity.BookId
            && a.Book == transactionEntity.Book
            && a.Cost == transactionEntity.Cost
            && a.Quantity == transactionEntity.Quantity
            && a.Data == transactionEntity.Data);
        }

        public void Remove(TransactionEntity transactionEntity)
        {
            this.dbContext.Transactions.Remove(transactionEntity);
        }
    }
}
