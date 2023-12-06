using DRPDH3_HFT_2023241.Models;
using DRPDH3_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
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
            if (this.repo.ReadAll().Where(s => s.Id == item.Id).FirstOrDefault() != null)
            {
                throw new ArgumentException("Ilyen ID-val mar letezik rekord.");
            }

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

        public IEnumerable<Species> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Species item)
        {
            this.repo.Update(item);
        }
    }
}
