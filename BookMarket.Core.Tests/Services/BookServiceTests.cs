using AutoFixture;
using BookMarket.Core.Dto;
using BookMarket.Core.Models;
using BookMarket.Core.Services;
using BookMarket.Data.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BookMarket.Core.Tests.Services
{
    [TestFixture]
    public class BookServiceTests
    {
        [Test]
        public void ShouldAddNewBook()
        {
            // Arrange
            var mock = new Mock<IBookRepository>();
            mock.Setup(a => a.Contains(It.IsAny<BookEntity>())).Returns(true);
            var bookService = new BookService(mock.Object);
            var bookRegistrationInfo = new Fixture().Create<BookRegistrationInfo>();

            // Act
            bookService.AddBook(bookRegistrationInfo);

            // Assert
            mock.Verify(a => a.Add(It.Is<BookEntity>(a => 
            a.Cost == bookRegistrationInfo.Cost 
            && a.Name == bookRegistrationInfo.Name 
            && a.Amount == bookRegistrationInfo.Amount 
            && a.Year == bookRegistrationInfo.Year)));
            mock.Verify(a => a.Save());
        }

        [Test]
        public void ShouldRemoveBook()
        {
            // Arrange
            var mock = new Mock<IBookRepository>();
            mock.Setup(a => a.ContainsId(It.IsAny<int>())).Returns(true);
            var bookService = new BookService(mock.Object);
            var bookId = 12; 

            // Act
            bookService.RemoveBook(bookId);

            // Assert
            mock.Verify(a => a.Remove(It.IsAny<BookEntity>()));
            mock.Verify(a => a.Save());
            mock.Verify(a => a.GetById(bookId));
        }

        [Test]
        public void ShouldGetBookById()
        {
            // Arrange
            var bookId = 12;
            var mock = new Mock<IBookRepository>();
            var bookEntity = new BookEntity { Id = bookId };
            mock.Setup(a => a.GetById(It.IsAny<int>())).Returns(bookEntity);
            mock.Setup(a => a.ContainsId(It.IsAny<int>())).Returns(true);
            var bookService = new BookService(mock.Object);

            // Act
            var resylt = bookService.GetBookById(bookId);

            // Assert
            mock.Verify(a => a.GetById(bookId));
            Assert.AreEqual(resylt, bookEntity);
        }

        [Test]
        public void ShouldGetAllBook()
        {
            // Arrange
            var mock = new Mock<IBookRepository>();
            // var listEntity = new Fixture().Create<IEnumerable<BookEntity>>();
            var listEntity = new List<BookEntity>();
            mock.Setup(a => a.ContainsId(It.IsAny<int>())).Returns(true);
            mock.Setup(a => a.GetAll()).Returns(listEntity);
            var bookService = new BookService(mock.Object);
            var bookId = 12;

            // Act
            var resylt = bookService.GetAllBook();

            // Assert
            mock.Verify(a => a.GetAll());
            Assert.AreEqual(resylt, listEntity);
        }
    }
}
