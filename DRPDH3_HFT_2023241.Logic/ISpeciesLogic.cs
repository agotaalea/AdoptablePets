using DRPDH3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRPDH3_HFT_2023241.Logic
{
    public interface ISpeciesLogic
    {
        public void Create(Species item);
        public void Delete(int id);
        public Species Read(int id);
        public IQueryable<Species> ReadAll();
        public void Update(Species item);
    }
}
