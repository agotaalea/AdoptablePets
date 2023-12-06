using DRPDH3_HFT_2023241.Models;
using DRPDH3_HFT_2023241.Repository;
using System;
using System.Linq;

namespace DRPDH3_HFT_2023241.Logic
{
    public class AdoptionLogic : IAdoptionLogic
    {
        IRepository<Adoption> repo;

        public AdoptionLogic(IRepository<Adoption> repo)
        {
            this.repo = repo;
        }

        public void Create(Adoption item)
        {
            if (this.repo.ReadAll().Where(a => a.Id == item.Id).FirstOrDefault() != null)
            {
                throw new ArgumentException("Ilyen ID-val mar letezik rekord.");
            }

            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Adoption Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Adoption> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Adoption item)
        {
            this.repo.Update(item);
        }
    }
}
