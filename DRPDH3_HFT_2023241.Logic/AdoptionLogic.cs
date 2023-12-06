using DRPDH3_HFT_2023241.Models;
using DRPDH3_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRPDH3_HFT_2023241.Logic
{
    public class AdoptionLogic
    {
        IRepository<Adoption> repo;

        public AdoptionLogic(IRepository<Adoption> repo)
        {
            this.repo = repo;
        }

        public void Create(Adoption item)
        {
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

        public IEnumerable<Adoption> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Adoption item)
        {
            this.repo.Update(item);
        }
    }
}
