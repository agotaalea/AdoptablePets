using DRPDH3_HFT_2023241.Models;
using DRPDH3_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRPDH3_HFT_2023241.Logic
{
    public class PetLogic
    {
        IRepository<Pet> petRepo;
        IRepository<Adoption> adoptRepo;
        IRepository<Species> specRepo;

        public PetLogic(IRepository<Pet> petRepo, IRepository<Adoption> adoptRepo, IRepository<Species> specRepo)
        {
            this.petRepo = petRepo;
            this.adoptRepo = adoptRepo;
            this.specRepo = specRepo;
        }

        public void Create(Pet item)
        {
            this.petRepo.Create(item);
        }

        public void Delete(int id)
        {
            this.petRepo.Delete(id);
        }

        public Pet Read(int id)
        {
            return this.petRepo.Read(id);
        }

        public IEnumerable<Pet> ReadAll()
        {
            return this.petRepo.ReadAll();
        }

        public void Update(Pet item)
        {
            this.petRepo.Update(item);
        }

        public IEnumerable<Pet> GetNMostAdopted(int n)
        {
            IEnumerable<Adoption> adoptions = this.adoptRepo.ReadAll();
            IEnumerable<Pet> pets = this.petRepo.ReadAll();
            IEnumerable<int> mostAdoptedIds = adoptions.GroupBy(a => a.PetId).OrderByDescending(g => g.Count()).Take(n).Select(g => g.Key);
            IEnumerable<Pet> mostAdopted = pets.Where(p => mostAdoptedIds.Contains(p.Id));
            return mostAdopted;
        }

        public IEnumerable<Pet> GetPetsAdoptedBy(int id)
        {
            IEnumerable<int> petsId = this.adoptRepo.ReadAll().Where(a => a.Id == id).Select(a => a.PetId);
            IEnumerable<Pet> pets = this.petRepo.ReadAll().Where(p => petsId.Contains(p.Id));
            return pets;
        }

        public IEnumerable<Pet> GetNLeastAdopted(int n)
        {
            IEnumerable<Adoption> adoptions = this.adoptRepo.ReadAll();
            IEnumerable<Pet> pets = this.petRepo.ReadAll();
            IEnumerable<int> leastAdoptedIds = adoptions.GroupBy(a => a.PetId).OrderBy(g => g.Count()).Take(n).Select(g => g.Key);
            IEnumerable<Pet> leastAdopted = pets.Where(p => leastAdoptedIds.Contains(p.Id));
            return leastAdopted;
        }

        public IEnumerable<Pet> GetPetsByAdoptonDate(DateTime dt)
        {
            IEnumerable<int> petsId = this.adoptRepo.ReadAll().Where(a => a.AdoptionDate == dt).Select(a => a.PetId);
            IEnumerable<Pet> pets = this.petRepo.ReadAll().Where(p => petsId.Contains(p.Id));
            return pets;
        }

        public IEnumerable<Pet> GetPetsBySpecies(string species)
        {
            int speciesId = this.specRepo.ReadAll().Where(s => s.Name == species).FirstOrDefault().Id;
            IEnumerable<Pet> pets = this.petRepo.ReadAll().Where(p => p.SpeciesId == speciesId);
            return pets;
        }
    }
}
