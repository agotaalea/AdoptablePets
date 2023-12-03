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
        IRepository<Pet> repo;

        public PetLogic(IRepository<Pet> repo)
        {
            this.repo = repo;
        }

        public void Create(Pet item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Pet Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Pet> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Pet item)
        {
            this.repo.Update(item);
        }
    }
}
