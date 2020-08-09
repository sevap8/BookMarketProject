using BookMarket.Core.Dto;
using BookMarket.Core.Models;
using System.Collections.Generic;

namespace BookMarket.Core.Services
{
    public interface IWriterService
    {
        void AddWriter(WriterRegistrationInfo writerRegistrationInfo);
        IEnumerable<WriterEntity> GetAllWriter();
        WriterEntity GetWriterById(int id);
        void RemoveWriter(int id);
    }
}