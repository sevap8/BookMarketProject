using BookMarket.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarket.Data.Context
{
    public class BookMarketDbContext : DbContext
    {
        public DbSet<WriterEntity> Writers { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<СustomerEntity> Сustomers { get; set; }

        public BookMarketDbContext(DbContextOptions<BookMarketDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

                protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionEntity>()
                .HasKey(t => new { t.BookId, t.СustomerId });

            modelBuilder.Entity<TransactionEntity>()
                .HasOne(sc => sc.Сustomer)
                .WithMany(s => s.Transactions)
                .HasForeignKey(sc => sc.СustomerId);

            modelBuilder.Entity<TransactionEntity>()
                .HasOne(sc => sc.Book)
                .WithMany(c => c.Transactions)
                .HasForeignKey(sc => sc.BookId);

            modelBuilder.Entity<СustomerEntity>().HasData(
            new СustomerEntity[]
            {
            //new СustomerEntity {Id = 1, Surname = "Менделеев", Name = "Дмитрий", Mail = "Mendeleev@mail.ru" },
            //new СustomerEntity {Id = 2, Surname = "Циолковский", Name = "Константин", Mail = "Tsiolkovsky@yandex.ru" },
            //new СustomerEntity {Id = 3, Surname = "Пирогов", Name = "Николай", Mail = "Pirogov@gmail.com" },
            new СustomerEntity { Id = 1, Login = "Korolev@rambler.ru", Password = "qwerty" },
            new СustomerEntity { Id = 2, Login = "Slaa1984@rambler.ru", Password = "123" },
            });

            modelBuilder.Entity<BookEntity>().HasData(
            new BookEntity[]
            {
             new BookEntity { Id = 1, Name ="some", Year = 1990, Cost = 200, Amount = 10 },
             new BookEntity { Id = 2, Name ="GGG", Year = 1947, Cost = 300, Amount = 5 }
            });

            modelBuilder.Entity<TransactionEntity>().HasData(
            new TransactionEntity[]
            {
                new TransactionEntity { 

                    Id = 1, 
                    Data = new DateTime(), 
                    СustomerId = 1,  
                    BookId = 1,  
                    Cost = 150, 
                    Quantity = 2,
                },
                                new TransactionEntity { 
                    Id = 2, 
                    Data = new DateTime(),
                    СustomerId = 2,
                    BookId = 1,
                    Cost = 150,
                    Quantity = 2,
                },
                                                new TransactionEntity { 
                    Id = 3, 
                    Data = new DateTime(),
                    СustomerId = 1,
                    BookId = 2,
                    Cost = 150,
                    Quantity = 2,
                }
            });

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=1234");
        //}
    }
}
