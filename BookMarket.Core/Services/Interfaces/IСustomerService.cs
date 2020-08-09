using BookMarket.Core.Dto;
using BookMarket.Core.Models;
using System.Collections.Generic;

namespace BookMarket.Core.Services
{
    public interface IСustomerService
    {
        void AddСustomer(CustomerRegistrationInfo customerRegistrationInfo);
        IEnumerable<СustomerEntity> GetAllСustomer();
        СustomerEntity GetСustomerById(int id);
        void RemoveСustomer(int id);
    }
}