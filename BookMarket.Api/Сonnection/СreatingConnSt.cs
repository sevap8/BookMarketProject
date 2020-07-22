using BookMarket.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarket.Api.Сonnection
{
    public static class СreatingConnSt
    {
        public static DbContextOptions<BookMarketDbContext> GetReceiveSt()
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<BookMarketDbContext>();
            var options = optionsBuilder
                .UseNpgsql(connectionString)
                .Options;
            return options;
        }
    }
}
