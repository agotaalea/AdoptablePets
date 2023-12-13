using DRPDH3_HFT_2023241.Models;
using System;
using System.Linq;
using System.Reflection;

namespace DRPDH3_HFT_2023241.Repository
{
    public class SpeciesRepository : Repository<Species>
    {
        public SpeciesRepository(AdoptionDbContext ctx) : base(ctx)
        {
        }

        public override Species Read(int id)
        {
            return ctx.Species.FirstOrDefault(s => s.Id == id);
        }

        public override void Update(Species newSpecies)
        {
            Species oldSpecies = Read(newSpecies.Id);
            foreach (PropertyInfo speciesInfo in oldSpecies.GetType().GetProperties())
            {
                if (speciesInfo.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    speciesInfo.SetValue(oldSpecies, speciesInfo.GetValue(newSpecies));
                }
            }

            ctx.SaveChanges();
        }
    }
}
