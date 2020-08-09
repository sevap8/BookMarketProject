using BookMarket.Core.Models;
using System.Collections.Generic;

namespace BookMarket.Data.Repositories
{
    public interface ITransactionRepository
    {
        void Add(TransactionEntity transactionEntity);
        bool Contains(TransactionEntity transactionEntity);
        bool ContainsId(int entityId);
        IEnumerable<TransactionEntity> GetAll();
        TransactionEntity GetById(int id);
        void Remove(TransactionEntity transactionEntity);
        void Save();
    }
}