using AutoFixture;
using BookMarket.Core.Models;
using BookMarket.Core.Services;
using BookMarket.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BookMarket.Core.Tests.Services
{
    [TestFixture]
    public class TransactionServiceTests
    {
        [Test]
        public void AddTransaction_ShouldAddNewTransaction()
        {
            // Arrange
            var mock = new Mock<ITransactionRepository>();
            mock.Setup(a => a.Contains(It.IsAny<TransactionEntity>())).Returns(true);
            var transactionService = new TransactionService(mock.Object);
            var transactionEntity = new Fixture().Create<TransactionEntity>();

            // Act
            transactionService.AddTransaction(transactionEntity);

            // Assert
            mock.Verify(a => a.Add(It.Is<TransactionEntity>(a =>
            a.Cost == transactionEntity.Cost
            && a.Quantity == transactionEntity.Quantity
            && a.Ñustomer == transactionEntity.Ñustomer
            && a.Book == transactionEntity.Book)));
            mock.Verify(a => a.Save());
        }

        [Test]
        public void RemoveTransaction_ShouldRemoveTransaction()
        {
            // Arrange
            var mock = new Mock<ITransactionRepository>();
            mock.Setup(a => a.ContainsId(It.IsAny<int>())).Returns(true);
            var transactionService = new TransactionService(mock.Object);
            var Id = 12;

            // Act
            transactionService.RemoveTransaction(Id);

            // Assert
            mock.Verify(a => a.Remove(It.IsAny<TransactionEntity>()));
            mock.Verify(a => a.Save());
            mock.Verify(a => a.GetById(Id));
        }

        [Test]
        public void GetTransactionById_ShouldGetTransactionById()
        {
            // Arrange
            var Id = 12;
            var mock = new Mock<ITransactionRepository>();
            var transactionEntity = new TransactionEntity { Id = Id };
            mock.Setup(a => a.GetById(It.IsAny<int>())).Returns(transactionEntity);
            mock.Setup(a => a.ContainsId(It.IsAny<int>())).Returns(true);
            var transactionService = new TransactionService(mock.Object);

            // Act
            var resylt = transactionService.GetTransactionById(Id);

            // Assert
            mock.Verify(a => a.GetById(Id));
            Assert.AreEqual(resylt, transactionEntity);
        }

        [Test]
        public void GetAllTransaction_ShouldGetAllTransaction()
        {
            // Arrange
            var mock = new Mock<ITransactionRepository>();
            // var listEntity = new Fixture().Create<IEnumerable<BookEntity>>();
            var listEntity = new List<TransactionEntity>();
            mock.Setup(a => a.ContainsId(It.IsAny<int>())).Returns(true);
            mock.Setup(a => a.GetAll()).Returns(listEntity);
            var transactionService = new TransactionService(mock.Object);
            var bookId = 12;

            // Act
            var resylt = transactionService.GetAllTransaction();

            // Assert
            mock.Verify(a => a.GetAll());
            Assert.AreEqual(resylt, listEntity);
        }
    }
}
