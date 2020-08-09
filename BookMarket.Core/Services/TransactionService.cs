using BookMarket.Core.Models;
using BookMarket.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarket.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public void AddTransaction(TransactionEntity transactionEntity)
        {
            if (!transactionRepository.Contains(transactionEntity))
            {
                throw new ArgumentException("This transaction has been registered. Can't continue");
            }

            this.transactionRepository.Add(transactionEntity);
            this.transactionRepository.Save();
        }

        public void RemoveTransaction(int id)
        {
            if (!transactionRepository.ContainsId(id))
            {
                throw new ArgumentException($"This transaction is missing {id}! ");
            }

            this.transactionRepository.Remove(transactionRepository.GetById(id));
            this.transactionRepository.Save();
        }

        public TransactionEntity GetTransactionById(int id)
        {
            if (!transactionRepository.ContainsId(id))
            {
                throw new ArgumentException($"This transaction is missing {id}! ");
            }

            return transactionRepository.GetById(id);
        }

        public IEnumerable<TransactionEntity> GetAllTransaction()
        {
            var allTransaction = transactionRepository.GetAll();
            if (allTransaction == null)
            {
                throw new ArgumentException($"The list is empty! ");
            }

            return allTransaction;
        }
    }
}
