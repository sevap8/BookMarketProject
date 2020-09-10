using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using BookMarket.Core.Services;
using BookMarket.Data.Repositories;

namespace BookMarket.Core.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection GetDependency(this IServiceCollection services)
        {
            return services.AddTransient<IBookService, BookService>()
                .AddTransient<ITransactionService, TransactionService>()
                .AddTransient<IWriterService, WriterService>()
                .AddTransient<IСustomerService, СustomerService>()
                .AddTransient<IBookRepository, BookRepository>()
                .AddTransient<ITransactionRepository, TransactionRepository>()
                .AddTransient<IWriterRepository, WriterRepository>()
                .AddTransient<IСustomerRepository, СustomerRepository>();
        }
    }
}
