using AutoFixture;
using BookMarket.Core.Dto;
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
    public class WriterServiceTests
    {
        [Test]
        public void AddWriter_ShouldAddNewWriter()
        {
            // Arrange
            var mock = new Mock<IWriterRepository>();
            mock.Setup(a => a.Contains(It.IsAny<WriterEntity>())).Returns(true);
            var writerService = new WriterService(mock.Object);
            var writerRegistrationInfo = new Fixture().Create<WriterRegistrationInfo>();

            // Act
            writerService.AddWriter(writerRegistrationInfo);

            // Assert
            mock.Verify(a => a.Add(It.Is<WriterEntity>(a =>
            a.Name == writerRegistrationInfo.Name
            && a.Surname == writerRegistrationInfo.Surname)));
            mock.Verify(a => a.Save());
        }

        [Test]
        public void RemoveWriter_ShouldRemoveWriter()
        {
            // Arrange
            var mock = new Mock<IWriterRepository>();
            mock.Setup(a => a.ContainsId(It.IsAny<int>())).Returns(true);
            var writerService = new WriterService(mock.Object);
            var Id = 12;

            // Act
            writerService.RemoveWriter(Id);

            // Assert
            mock.Verify(a => a.Remove(It.IsAny<WriterEntity>()));
            mock.Verify(a => a.Save());
            mock.Verify(a => a.GetById(Id));
        }

        [Test]
        public void GetWriterById_ShouldGetWriterById()
        {
            // Arrange
            var Id = 12;
            var mock = new Mock<IWriterRepository>();
            var writerEntity = new WriterEntity { Id = Id };
            mock.Setup(a => a.GetById(It.IsAny<int>())).Returns(writerEntity);
            mock.Setup(a => a.ContainsId(It.IsAny<int>())).Returns(true);
            var writerService = new WriterService(mock.Object);

            // Act
            var resylt = writerService.GetWriterById(Id);

            // Assert
            mock.Verify(a => a.GetById(Id));
            Assert.AreEqual(resylt, writerEntity);
        }

        [Test]
        public void GetAllWriter_ShouldGetAllWriter()
        {
            // Arrange
            var mock = new Mock<IWriterRepository>();
            // var listEntity = new Fixture().Create<IEnumerable<BookEntity>>();
            var listEntity = new List<WriterEntity>();
            mock.Setup(a => a.ContainsId(It.IsAny<int>())).Returns(true);
            mock.Setup(a => a.GetAll()).Returns(listEntity);
            var writerService = new WriterService(mock.Object);
            var Id = 12;

            // Act
            var resylt = writerService.GetAllWriter();

            // Assert
            mock.Verify(a => a.GetAll());
            Assert.AreEqual(resylt, listEntity);
        }
    }
}
