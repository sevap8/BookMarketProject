using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMarket.Core.Models
{
    public class TransactionEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int СustomerId { get; set; }
        public СustomerEntity Сustomer { get; set; }
        public int BookId { get; set; }
        public BookEntity Book { get; set; }
        public int Cost { get; set; }
        public int Quantity { get; set; }
    }
}
