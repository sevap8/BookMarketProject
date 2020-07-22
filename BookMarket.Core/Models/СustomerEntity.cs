using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMarket.Core.Models
{
    public class СustomerEntity
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<TransactionEntity> Transactions { get; set; }
        public СustomerEntity()
        {
            Transactions = new List<TransactionEntity>();
        }
    }
}
