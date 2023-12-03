using DRPDH3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DRPDH3_HFT_2023241.Repository
{
    public class PetRepository : Repository<Pet>
    {
        public PetRepository(AdoptionDbContext ctx) : base(ctx)
        {
        }

        public override Pet Read(int id)
        {
            return ctx.Pets.FirstOrDefault(p => p.Id == id);
        }

        public override void Update(Pet newPet)
        {
            Pet oldPet = Read(newPet.Id);
            foreach (PropertyInfo petInfo in oldPet.GetType().GetProperties())
            {
                petInfo.SetValue(oldPet, petInfo.GetValue(newPet));
            }

            ctx.SaveChanges();
        }
    }
}
