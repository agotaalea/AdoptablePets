﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DRPDH3_HFT_2023241.Models
{
    public class Adoption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PetId { get; set; }
        public string AdopterName { get; set; }
        public DateTime AdoptionDate { get; set; }
        public string Contact { get; set; }
        public virtual Pet Pet { get; set; }

        public Adoption()
        {
        }

        public Adoption(string line)
        {
            string[] data = line.Split(';');
            Id = int.Parse(data[0]);
            PetId = int.Parse(data[1]);
            AdopterName = data[2];
            AdoptionDate = DateTime.Parse(data[3]);
            Contact = data[4];
        }
    }
}
