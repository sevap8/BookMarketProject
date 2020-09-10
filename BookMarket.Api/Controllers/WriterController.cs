using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Core.Dto;
using BookMarket.Core.Models;
using BookMarket.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.Api.Controllers
{
    [Route("api/writer")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private readonly IWriterService writerService;
        public WriterController(IWriterService writerService)
        {
            this.writerService = writerService;
        }

        //GET api/writer
        [HttpGet]
        public ActionResult<IEnumerable<WriterEntity>> GetAllWriter()
        {
            var writers = writerService.GetAllWriter();
            return Ok(writers);
        }

        //GET api/writer/3
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<WriterEntity>> GetWriterById(int id)
        {
            var writers = writerService.GetWriterById(id);
            return Ok(writers);
        }

        //POST  api/writer
        [HttpPost]
        public ActionResult CreateWriter(WriterRegistrationInfo writerRegistrationInfo)
        {
            writerService.AddWriter(writerRegistrationInfo);
            return Ok();
        }

        //DELETE  api/writer/3
        [HttpDelete("{id}")]
        public ActionResult DeleteWriter(int id)
        {
            writerService.RemoveWriter(id);
            return Ok();
        }
    }
}