using DRPDH3_HFT_2023241.Logic;
using DRPDH3_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DRPDH3_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        ISpeciesLogic logic;

        public SpeciesController(ISpeciesLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<SpeciesController>
        [HttpGet]
        public IEnumerable<Species> Get()
        {
            return this.logic.ReadAll();
        }

        // GET api/<SpeciesController>/5
        [HttpGet("{id}")]
        public Species Get(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<SpeciesController>
        [HttpPost]
        public void Post([FromBody] Species value)
        {
            this.logic.Create(value);
        }

        // PUT api/<SpeciesController>/5
        [HttpPut]
        public void Put([FromBody] Species value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<SpeciesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
