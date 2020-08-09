using BookMarket.Core.Models;
using System.Collections.Generic;

namespace BookMarket.Core.Services
{
    public interface ITransactionService
    {
        void AddTransaction(TransactionEntity transactionEntity);
        IEnumerable<TransactionEntity> GetAllTransaction();
        TransactionEntity GetTransactionById(int id);
        void RemoveTransaction(int id);
    }
}