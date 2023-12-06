using DRPDH3_HFT_2023241.Logic;
using DRPDH3_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DRPDH3_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdoptionController : ControllerBase
    {
        IAdoptionLogic logic;

        public AdoptionController(IAdoptionLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<AdoptionController>
        [HttpGet]
        public IEnumerable<Adoption> Get()
        {
            return this.logic.ReadAll();
        }

        // GET api/<AdoptionController>/5
        [HttpGet("{id}")]
        public Adoption Get(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<AdoptionController>
        [HttpPost]
        public void Post([FromBody] Adoption value)
        {
            this.logic.Create(value);
        }

        // PUT api/<AdoptionController>/5
        [HttpPut]
        public void Put([FromBody] Adoption value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<AdoptionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
