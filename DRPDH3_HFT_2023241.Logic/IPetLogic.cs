using DRPDH3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRPDH3_HFT_2023241.Logic
{
    public interface IPetLogic
    {
        public void Create(Pet item);
        public void Delete(int id);
        public Pet Read(int id);
        public IQueryable<Pet> ReadAll();
        public void Update(Pet item);
        public IEnumerable<Pet> GetNMostAdopted(int n);
        public IEnumerable<Pet> GetPetsAdoptedBy(string name);
        public IEnumerable<Pet> GetNLeastAdopted(int n);
        public IEnumerable<Pet> GetPetsByAdoptonDate(DateTime dt);
        public IEnumerable<Pet> GetPetsBySpecies(string species);
    }
}
