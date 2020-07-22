using BookMarket.Core.Models;
using BookMarket.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMarket.Data.Repositories
{
    public class СustomerRepository : IСustomerRepository
    {
        private readonly BookMarketDbContext dbContext;
        public СustomerRepository(BookMarketDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(СustomerEntity сustomerEntity)
        {
            this.dbContext.Сustomers.Add(сustomerEntity);
        }

        public СustomerEntity GetById(int id)
        {
            return dbContext.Сustomers.Where(a => a.Id == id).FirstOrDefault();
        }

        public IEnumerable<СustomerEntity> GetAll()
        {
            return dbContext.Сustomers.Select(a => a);
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }

        public bool ContainsId(int entityId)
        {
            return this.dbContext.Сustomers.Any(a =>
        a.Id == entityId);
        }

        public bool Contains(СustomerEntity сustomerEntity)
        {
            // return this.dbContext.Meetings.Any(a =>
            //a.Name == meetingEntity.Name
            //&& a.Place == meetingEntity.Place
            //&& a.DateTimeMeeting == meetingEntity.DateTimeMeeting
            //&& a.Id == meetingEntity.Id);
            return true;
        }

        public void Remove(СustomerEntity сustomerEntity)
        {
            this.dbContext.Сustomers.Remove(сustomerEntity);
        }
    }
}
