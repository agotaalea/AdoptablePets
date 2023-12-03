using DRPDH3_HFT_2023241.Models;
using DRPDH3_HFT_2023241.Repository;
using System;
using System.Linq;

namespace DRPDH3_HFT_2023241.Logic
{
    public class SpeciesLogic
    {
        IRepository<Species> repo;

        public SpeciesLogic(IRepository<Species> repo)
        {
            this.repo = repo;
        }

        public void Create(Species item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Species Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Species> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Species item)
        {
            this.repo.Update(item);
        }
    }
}
