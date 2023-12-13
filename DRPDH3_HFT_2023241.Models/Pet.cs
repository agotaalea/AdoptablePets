using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DRPDH3_HFT_2023241.Models
{
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }

        public virtual Species Species { get; set; }

        [JsonIgnore]
        public virtual ICollection<Adoption> Adoptions { get; set; }

        public Pet()
        {
            Adoptions = new HashSet<Adoption>();
        }

        public Pet(string line)
        {
            string[] data = line.Split(';');
            Id = int.Parse(data[0]);
            SpeciesId = int.Parse(data[1]);
            Name = data[2];
            Age = int.Parse(data[3]);
            Description = data[4];
            Adoptions = new HashSet<Adoption>();
        }
    }
}
