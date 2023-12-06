using DRPDH3_HFT_2023241.Models;
using System.Linq;

namespace DRPDH3_HFT_2023241.Logic
{
    public interface IAdoptionLogic
    {
        public void Create(Adoption item);
        public void Delete(int id);
        public Adoption Read(int id);
        public IQueryable<Adoption> ReadAll();
        public void Update(Adoption item);
    }
}
