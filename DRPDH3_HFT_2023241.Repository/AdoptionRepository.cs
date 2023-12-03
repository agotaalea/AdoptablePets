using DRPDH3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DRPDH3_HFT_2023241.Repository
{
    public class AdoptionRepository : Repository<Adoption>
    {
        public AdoptionRepository(AdoptionDbContext ctx) : base(ctx)
        {
        }

        public override Adoption Read(int id)
        {
            return ctx.Adoptions.FirstOrDefault(a => a.Id == id);
        }

        public override void Update(Adoption newAdoption)
        {
            Adoption oldAdoption = Read(newAdoption.Id);
            foreach (PropertyInfo adoptionInfo in oldAdoption.GetType().GetProperties())
            {
                adoptionInfo.SetValue(oldAdoption, adoptionInfo.GetValue(newAdoption));
            }

            ctx.SaveChanges();
        }
    }
}
