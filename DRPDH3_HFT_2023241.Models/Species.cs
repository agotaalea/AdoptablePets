using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DRPDH3_HFT_2023241.Models
{
    public class Species
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Pet> Pets { get; set; }

        public Species()
        {
            Pets = new HashSet<Pet>();
        }

        public Species(string line)
        {
            string[] data = line.Split(';');
            Id = int.Parse(data[0]);
            Name = data[1];
            Description = data[2];
            Pets = new HashSet<Pet>();
        }
    }
}
