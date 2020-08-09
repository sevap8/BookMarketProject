using BookMarket.Core.Dto;
using BookMarket.Core.Models;
using BookMarket.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarket.Core.Services
{
    public class WriterService : IWriterService
    {
        private readonly IWriterRepository writerRepository;
        public WriterService(IWriterRepository writerRepository)
        {
            this.writerRepository = writerRepository;
        }

        public void AddWriter(WriterRegistrationInfo writerRegistrationInfo)
        {
            var writerEntity = new WriterEntity
            {
                Name = writerRegistrationInfo.Name,
                Surname = writerRegistrationInfo.Surname
            };

            if (!writerRepository.Contains(writerEntity))
            {
                throw new ArgumentException("This writer has been registered. Can't continue");
            }

            this.writerRepository.Add(writerEntity);
            this.writerRepository.Save();
        }

        public void RemoveWriter(int id)
        {
            if (!writerRepository.ContainsId(id))
            {
                throw new ArgumentException($"This writer is missing {id}! ");
            }

            this.writerRepository.Remove(writerRepository.GetById(id));
            this.writerRepository.Save();
        }

        public WriterEntity GetWriterById(int id)
        {
            if (!writerRepository.ContainsId(id))
            {
                throw new ArgumentException($"This writer is missing {id}! ");
            }

            return writerRepository.GetById(id);
        }

        public IEnumerable<WriterEntity> GetAllWriter()
        {
            var allWriter = writerRepository.GetAll();
            if (allWriter == null)
            {
                throw new ArgumentException($"The list is empty! ");
            }

            return allWriter;
        }
    }
}
