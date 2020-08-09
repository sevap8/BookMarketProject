using BookMarket.Core.Models;
using BookMarket.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMarket.Data.Repositories
{
    public class WriterRepository : IWriterRepository
    {
        private readonly BookMarketDbContext dbContext;
        public WriterRepository(BookMarketDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(WriterEntity writerEntity)
        {
            this.dbContext.Writers.Add(writerEntity);
        }

        public WriterEntity GetById(int id)
        {
            return dbContext.Writers.Where(a => a.Id == id).FirstOrDefault();
        }

        public IEnumerable<WriterEntity> GetAll()
        {
            return dbContext.Writers.Select(a => a);
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }

        public bool ContainsId(int entityId)
        {
            return this.dbContext.Writers.Any(a =>
        a.Id == entityId);
        }

        public bool Contains(WriterEntity writerEntity)
        {
             return this.dbContext.Writers.Any(a =>
            a.Name == writerEntity.Name
            && a.Surname == writerEntity.Surname);
        }

        public void Remove(WriterEntity writerEntity)
        {
            this.dbContext.Writers.Remove(writerEntity);
        }
    }
}
