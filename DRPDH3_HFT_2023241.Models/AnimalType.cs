using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DRPDH3_HFT_2023241.Models
{
    public class AnimalType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        //public IEnumerable<AdoptablePet> Pets { get; set; }


        public AnimalType(string line)
        {
            string[] data = line.Split(';');
            Id = int.Parse(data[0]);
            Name = data[1];
            Description = data[2];
        }
    }
}
