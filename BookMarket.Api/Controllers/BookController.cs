using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Core.Dto;
using BookMarket.Core.Models;
using BookMarket.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.Api.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        //GET api/book
        [HttpGet]
        public ActionResult<IEnumerable<BookEntity>> GetAllBook()
        {
            var book = bookService.GetAllBook();
            return Ok(book);
        }

        //GET api/book/3
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<BookEntity>> GetBookById(int id)
        {
            var books = bookService.GetBookById(id);
            return Ok(books);
        }

        //POST  api/book
        [HttpPost]
        public ActionResult CreateBook(BookRegistrationInfo bookRegistrationInfo)
        {
            bookService.AddBook(bookRegistrationInfo);
            return Ok();
        }

        //DELETE  api/book/3
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            bookService.RemoveBook(id);
            return Ok();
        }
    }
}