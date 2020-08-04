using BookMarket.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarket.Core.Dto
{
    public class BookRegistrationInfo
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public WriterEntity Author { get; set; }
        public int Cost { get; set; }
        public int Amount { get; set; }
    }
}
