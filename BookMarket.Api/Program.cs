using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Api.�onnection;
using BookMarket.Core.Models;
using BookMarket.Data.Context;
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
            
            var options = �reatingConnSt.GetReceiveSt();

            using (BookMarketDbContext db = new BookMarketDbContext(options))
            {
                // ������� ��� ������� User
                WriterEntity user1 = new WriterEntity { Id = 2, Name = "����", Surname = "�������" };

                // ��������� �� � ��
                db.Writers.Add(user1);
                db.SaveChanges();
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
