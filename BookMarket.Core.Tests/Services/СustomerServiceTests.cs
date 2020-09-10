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
    public class СustomerServiceTests
    {
        [Test]
        //public void AddСustomer_StateUnderTest_ExpectedBehavior()
        public void AddСustomer_ShouldAddNewСustomer()
        {
            // Arrange
            var mock = new Mock<IСustomerRepository>();
            mock.Setup(a => a.Contains(It.IsAny<СustomerEntity>())).Returns(true);
            var сustomerService = new СustomerService(mock.Object);
            var customerRegistrationInfo = new Fixture().Create<CustomerRegistrationInfo>();

            // Act
            сustomerService.AddСustomer(customerRegistrationInfo);

            // Assert
            mock.Verify(a => a.Add(It.Is<СustomerEntity>(a =>
            a.Login == customerRegistrationInfo.Login
            && a.Password == customerRegistrationInfo.Password)));
            mock.Verify(a => a.Save());
        }

        [Test]
        public void RemoveСustomer_ShouldRemoveСustomer()
        {
            // Arrange
            var mock = new Mock<IСustomerRepository>();
            mock.Setup(a => a.ContainsId(It.IsAny<int>())).Returns(true);
            var сustomerService = new СustomerService(mock.Object);
            var Id = 12;

            // Act
            сustomerService.RemoveСustomer(Id);

            // Assert
            mock.Verify(a => a.Remove(It.IsAny<СustomerEntity>()));
            mock.Verify(a => a.Save());
            mock.Verify(a => a.GetById(Id));
        }

        [Test]
        public void GetСustomerById_ShouldGetСustomerById()
        {
            // Arrange
            var Id = 12;
            var mock = new Mock<IСustomerRepository>();
            var сustomerEntity = new СustomerEntity { Id = Id };
            mock.Setup(a => a.GetById(It.IsAny<int>())).Returns(сustomerEntity);
            mock.Setup(a => a.ContainsId(It.IsAny<int>())).Returns(true);
            var сustomerService = new СustomerService(mock.Object);

            // Act
            var resylt = сustomerService.GetСustomerById(Id);

            // Assert
            mock.Verify(a => a.GetById(Id));
            Assert.AreEqual(resylt, сustomerEntity);
        }

        [Test]
        public void GetAllСustomer_ShouldGetAllСustomer()
        {
            // Arrange
            var mock = new Mock<IСustomerRepository>();
            // var listEntity = new Fixture().Create<IEnumerable<BookEntity>>();
            var listEntity = new List<СustomerEntity>();
            mock.Setup(a => a.ContainsId(It.IsAny<int>())).Returns(true);
            mock.Setup(a => a.GetAll()).Returns(listEntity);
            var сustomerService = new СustomerService(mock.Object);
            var Id = 12;

            // Act
            var resylt = сustomerService.GetAllСustomer();

            // Assert
            mock.Verify(a => a.GetAll());
            Assert.AreEqual(resylt, listEntity);
        }
    }
}
