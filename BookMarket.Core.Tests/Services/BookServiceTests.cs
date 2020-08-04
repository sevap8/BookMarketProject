using BookMarket.Core.Dto;
using BookMarket.Core.Models;
using BookMarket.Core.Services;
using BookMarket.Data.Repositories;
using Moq;
using NUnit.Framework;

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
            var bookService = new BookService(mock.Object);
            var bookRegistrationInfo = new BookRegistrationInfo
            {
                Name = "SomeName",
                Cost = 100,
                Amount = 2,
                Year = 1988
            };

            // Act
            bookService.AddBook(bookRegistrationInfo);

            // Assert
            mock.Verify(a => a.Add(It.Is<BookEntity>(a => a.Cost == 100 && a.Name == "SomeName" && a.Amount == 2 && a.Year == 1988)));
        }
    }
}
