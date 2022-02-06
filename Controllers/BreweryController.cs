using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenBreweryAPI.APIHelper;
using OpenBreweryAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenBreweryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweryController : ControllerBase
    {
        // GET: api/<Brewery>
        [HttpGet]
        public IEnumerable<OpenBreweryModel> Get()
        {
            var breweryList = OpenBreweryAPIHelper.GetAllBreweries();
            return breweryList;
        }

        // GET api/<Brewery>/xx/yy
        [HttpGet("{breweryName}/{breweryId}")]
        public OpenBreweryModel Get(string breweryName, string breweryId)
        {
            var brewery = OpenBreweryAPIHelper.GetBrewery(breweryName, breweryId);
            return brewery;
        }

        // POST api/<Brewery>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Brewery>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Brewery>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
