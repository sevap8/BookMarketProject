using BookMarket.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookMarket.Data1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (BookMarketDbContext db = new BookMarketDbContext())
            {
                // создаем два объекта User
                WriterEntity user1 = new WriterEntity { Id = Guid.NewGuid(), Name = "Sam", Surname = "Green" };

                // добавляем их в бд
                db.Writers.Add(user1);
                db.SaveChanges();
            }
        }
        public class BookMarketDbContext : DbContext
        {
            public DbSet<WriterEntity> Writers { get; set; }

            public BookMarketDbContext()
            {
                Database.EnsureCreated();
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=1234");
            }
        }
    }
}
