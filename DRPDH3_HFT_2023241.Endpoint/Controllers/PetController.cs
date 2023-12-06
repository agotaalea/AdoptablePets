using DRPDH3_HFT_2023241.Logic;
using DRPDH3_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DRPDH3_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        IPetLogic logic;

        public PetController(IPetLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<PetController>
        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            return this.logic.ReadAll();
        }

        // GET api/<PetController>/5
        [HttpGet("{id}")]
        public Pet Get(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<PetController>
        [HttpPost]
        public void Post([FromBody] Pet value)
        {
            this.logic.Create(value);
        }

        // PUT api/<PetController>/5
        [HttpPut]
        public void Put([FromBody] Pet value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<PetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
