using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMarket.Core.Models
{
    public class BookEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public WriterEntity Author { get; set; }
        public int Cost { get; set; }
        public int Amount { get; set; }
        public List<TransactionEntity> Transactions { get; set; }
        public BookEntity
            ()
        {
            Transactions = new List<TransactionEntity>();
        }
    }
}
