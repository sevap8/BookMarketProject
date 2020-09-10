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
    [Route("api/сustomer")]
    [ApiController]
    public class СustomerController : ControllerBase
    {
        private readonly IСustomerService сustomerService;
        public СustomerController(IСustomerService сustomerService)
        {
            this.сustomerService = сustomerService;
        }

        //GET api/сustomer
        [HttpGet]
        public ActionResult<IEnumerable<СustomerEntity>> GetAllСustomer()
        {
            var сustomers = сustomerService.GetAllСustomer();
            return Ok(сustomers);
        }

        //GET api/сustomer/3
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<СustomerEntity>> GetСustomerById(int id)
        {
            var сustomers = сustomerService.GetСustomerById(id);
            return Ok(сustomers);
        }

        //POST  api/сustomer
        [HttpPost]
        public ActionResult CreateСustomer(CustomerRegistrationInfo customerRegistrationInfo)
        {
            сustomerService.AddСustomer(customerRegistrationInfo);
            return Ok();
        }

        //DELETE  api/сustomer/3
        [HttpDelete("{id}")]
        public ActionResult DeleteСustomer(int id)
        {
            сustomerService.RemoveСustomer(id);
            return Ok();
        }
    }
}