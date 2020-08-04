using BookMarket.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarket.Core.Services.Interfaces
{
    public interface IBookService
    {
        void AddBook(BookRegistrationInfo bookRegistrationInfo);
    }
}
