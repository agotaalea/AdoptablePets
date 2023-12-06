using ConsoleTools;
using DRPDH3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DRPDH3_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:47912/", "pet");

            var petSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Pet"))
                .Add("Create", () => Create("Pet"))
                .Add("Delete", () => Delete("Pet"))
                .Add("Update", () => Update("Pet"))
                .Add("Exit", ConsoleMenu.Close);

            var speciesSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Species"))
                .Add("Create", () => Create("Species"))
                .Add("Delete", () => Delete("Species"))
                .Add("Update", () => Update("Species"))
                .Add("Exit", ConsoleMenu.Close);

            var adoptionSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Adoption"))
                .Add("Create", () => Create("Adoption"))
                .Add("Delete", () => Delete("Adoption"))
                .Add("Update", () => Update("Adoption"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Pets", () => petSubMenu.Show())
                .Add("Species", () => speciesSubMenu.Show())
                .Add("Adoptions", () => adoptionSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }

        static void List(string entity)
        {
            if (entity.ToUpper() == "PET")
            {
                List<Pet> pets = rest.Get<Pet>("pet");
                foreach (var item in pets)
                {
                    Console.WriteLine(item.Name);
                }
            }

            Console.ReadLine();
        }

        static void Create(string entity)
        {
            if (entity.ToUpper() == "PET")
            {
                Console.WriteLine("NEW PET");
                Console.Write("Enter Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Age: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Enter Description: ");
                string desc = Console.ReadLine();
                Console.Write("Enter Species Id: ");
                int spec = int.Parse(Console.ReadLine());

                rest.Post(new Pet() { Id = 10, Name = name, Age = age, Description = desc, SpeciesId = spec}, "pet");
            }
        }

        static void Update(string entity)
        {
            if (entity.ToUpper() == "PET")
            {
                Console.WriteLine("UPDATE PET");
                Console.Write("Enter Pet's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Pet one = rest.Get<Pet>(id, "pet");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "pet");
            }
        }
        static void Delete(string entity)
        {
            if (entity.ToUpper() == "PET")
            {
                Console.Write("Enter Pet's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "pet");
            }
        }
    }
}
