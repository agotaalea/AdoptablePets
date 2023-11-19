using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRPDH3_HFT_2023241.Models
{
    public class AdoptablePet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }
        //[ForeignKey("AdoptablePet")]
        public int TypeId { get; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }

        public AdoptablePet(string line)
        {
            string[] data = line.Split(';');
            Id = int.Parse(data[0]);
            TypeId = int.Parse(data[1]);
            Name = data[2];
            Age = int.Parse(data[3]);
            Description = data[4];
        }
    }
}
