using DRPDH3_HFT_2023241.Logic;
using DRPDH3_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DRPDH3_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PetNonCrudController : ControllerBase
    {
        IPetLogic logic;

        public PetNonCrudController(IPetLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet("{n}")]
        public IEnumerable<Pet> GetNLeastAdopted(int n)
        {
            return this.logic.GetNLeastAdopted(n);
        }

        [HttpGet("{n}")]
        public IEnumerable<Pet> GetNMostAdopted(int n)
        {
            return this.logic.GetNMostAdopted(n);
        }

        [HttpGet("{species}")]
        public IEnumerable<Pet> GetPetsBySpecies(string species)
        {
            return this.logic.GetPetsBySpecies(species);
        }

        [HttpGet("{name}")]
        public IEnumerable<Pet> GetPetsAdoptedBy(string name)
        {
            return this.logic.GetPetsAdoptedBy(name);
        }

        [HttpGet("{date}")]
        public IEnumerable<Pet> GetPetsByAdoptonDate(string date)
        {
            return this.logic.GetPetsByAdoptonDate(DateTime.Parse(date));
        }
    }
}
