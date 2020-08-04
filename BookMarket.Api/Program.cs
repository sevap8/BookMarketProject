using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Api.Сonnection;
using BookMarket.Core.Models;
using BookMarket.Core.Services;
using BookMarket.Data.Context;
using BookMarket.Data.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BookMarket.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            
            var options = СreatingConnSt.GetReceiveSt();

            using (BookMarketDbContext db = new BookMarketDbContext(options))
            {
                BookRepository bookRepository = new BookRepository(db);
                BookService bookService = new BookService(bookRepository);
                bookService.AddBook(new Core.Dto.BookRegistrationInfo { Amount = 6, Year = 6, Cost = 6, Name = "Buy" });

                ////// создаем два объекта User
                //////WriterEntity user1 = new WriterEntity { Id = 2, Name = "Маша", Surname = "Трушина" };
                ////BookEntity bookEntity = new BookEntity { Id = 12, Name = "Some1" };
                ////BookEntity bookEntity1 = new BookEntity {Id = 3, Name = "Some2" };
                ////BookEntity bookEntity2 = new BookEntity { Id = 4, Name = "Some3" };

                ////bookRepository.Add(bookEntity);
                ////bookRepository.Add(bookEntity1);
                ////bookRepository.Add(bookEntity2);
                ////bookRepository.Remove(bookEntity1);
                ////BookEntity book = bookRepository.GetById(12);
                ////IEnumerable<BookEntity> book2 = bookRepository.GetAll();
                ////bool a = bookRepository.Contains(bookEntity);
                ////// добавляем их в бд
                ////bookRepository.Save();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
