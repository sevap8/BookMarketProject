using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Core.Models;
using BookMarket.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.Api.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        // TODO: Fix Transaction connect whith DB
        private readonly ITransactionService transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        //GET api/transaction
        [HttpGet]
        public ActionResult<IEnumerable<TransactionEntity>> GetAllTransaction()
        {
            var transactions = transactionService.GetAllTransaction();
            return Ok(transactions);
        }

        //GET api/transaction/3
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<TransactionEntity>> GetTransactionById(int id)
        {
            var transactions = transactionService.GetTransactionById(id);
            return Ok(transactions);
        }


        //POST  api/transaction
        [HttpPost]
        public ActionResult CreateTransaction(TransactionEntity transactionEntity)
        {
            transactionService.AddTransaction(transactionEntity);
            return Ok();
        }

        //DELETE  api/transaction/3
        [HttpDelete("{id}")]
        public ActionResult DeleteTransaction(int id)
        {
            transactionService.RemoveTransaction(id);
            return Ok();
        }
    }
}