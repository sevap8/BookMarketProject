using BookMarket.Core.Dto;
using BookMarket.Core.Models;
using BookMarket.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarket.Core.Services
{
    public class СustomerService : IСustomerService
    {
        private readonly IСustomerRepository сustomerRepository;
        public СustomerService(IСustomerRepository сustomerRepository)
        {
            this.сustomerRepository = сustomerRepository;
        }

        public void AddСustomer(CustomerRegistrationInfo customerRegistrationInfo)
        {
            var сustomerEntity = new СustomerEntity
            {
                Login = customerRegistrationInfo.Login,
                Password = customerRegistrationInfo.Password
            };

            if (сustomerRepository.Contains(сustomerEntity))
            {
                throw new ArgumentException("This customer has been registered. Can't continue");
            }

            this.сustomerRepository.Add(сustomerEntity);
            this.сustomerRepository.Save();
        }

        public void RemoveСustomer(int id)
        {
            if (!сustomerRepository.ContainsId(id))
            {
                throw new ArgumentException($"This customer is missing {id}! ");
            }

            this.сustomerRepository.Remove(сustomerRepository.GetById(id));
            this.сustomerRepository.Save();
        }

        public СustomerEntity GetСustomerById(int id)
        {
            if (!сustomerRepository.ContainsId(id))
            {
                throw new ArgumentException($"This customer is missing {id}! ");
            }

            return сustomerRepository.GetById(id);
        }

        public IEnumerable<СustomerEntity> GetAllСustomer()
        {
            var allСustomer = сustomerRepository.GetAll();
            if (allСustomer == null)
            {
                throw new ArgumentException($"The list is empty! ");
            }

            return allСustomer;
        }
    }
}
