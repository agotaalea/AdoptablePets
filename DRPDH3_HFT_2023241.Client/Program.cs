using ConsoleTools;
using DRPDH3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

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
                .Add("GetNMostAdopted", () => GetNMostAdopted())
                .Add("GetNLeastAdopted", () => GetNLeastAdopted())
                .Add("GetPetsBySpecies", () => GetPetsBySpecies())
                .Add("GetPetsAdoptedBy", () => GetPetsAdoptedBy())
                .Add("GetPetsByAdoptonDate", () => GetPetsByAdoptonDate())
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

        private static void GetNMostAdopted()
        {
            Console.WriteLine("Number of pets:");
            int n = int.Parse(Console.ReadLine());
            List<Pet> pets = rest.Get<Pet>($"petnoncrud/GetNMostAdopted/{n}");
            foreach (var item in pets)
            {
                if (item.Species != null)
                {
                    Console.WriteLine($"ID:{item.Id}-Name:{item.Name}-Age:{item.Age}-Description:{item.Description}-Species:{item.Species.Name}");
                }
                else
                {
                    Console.WriteLine($"ID:{item.Id}-Name:{item.Name}-Age:{item.Age}-Description:{item.Description}-Species:missing data");
                }
            }

            Console.ReadLine();
        }

        private static void GetNLeastAdopted()
        {
            Console.WriteLine("Number of pets:");
            int n = int.Parse(Console.ReadLine());
            List<Pet> pets = rest.Get<Pet>($"petnoncrud/GetNLeastAdopted/{n}");
            foreach (var item in pets)
            {
                if (item.Species != null)
                {
                    Console.WriteLine($"ID:{item.Id}-Name:{item.Name}-Age:{item.Age}-Description:{item.Description}-Species:{item.Species.Name}");
                }
                else
                {
                    Console.WriteLine($"ID:{item.Id}-Name:{item.Name}-Age:{item.Age}-Description:{item.Description}-Species:missing data");
                }
            }

            Console.ReadLine();
        }

        private static void GetPetsBySpecies()
        {
            Console.WriteLine("Get pets from this species:");
            string species = Console.ReadLine();
            List<Pet> pets = rest.Get<Pet>($"petnoncrud/GetPetsBySpecies/{species}");
            foreach (var item in pets)
            {
                if (item.Species != null)
                {
                    Console.WriteLine($"ID:{item.Id}-Name:{item.Name}-Age:{item.Age}-Description:{item.Description}-Species:{item.Species.Name}");
                }
                else
                {
                    Console.WriteLine($"ID:{item.Id}-Name:{item.Name}-Age:{item.Age}-Description:{item.Description}-Species:missing data");
                }
            }

            Console.ReadLine();
        }

        private static void GetPetsAdoptedBy()
        {
            Console.WriteLine("Pets adopted by:");
            string name = Console.ReadLine();
            List<Pet> pets = rest.Get<Pet>($"petnoncrud/GetPetsAdoptedBy/{name}");
            foreach (var item in pets)
            {
                if (item.Species != null)
                {
                    Console.WriteLine($"ID:{item.Id}-Name:{item.Name}-Age:{item.Age}-Description:{item.Description}-Species:{item.Species.Name}");
                }
                else
                {
                    Console.WriteLine($"ID:{item.Id}-Name:{item.Name}-Age:{item.Age}-Description:{item.Description}-Species:missing data");
                }
            }

            Console.ReadLine();
        }

        private static void GetPetsByAdoptonDate()
        {
            Console.WriteLine("Adoption date (yyyy.MM.dd):");
            string dt = Console.ReadLine();
            List<Pet> pets = rest.Get<Pet>($"petnoncrud/GetPetsByAdoptonDate/{dt}");
            foreach (var item in pets)
            {
                if (item.Species != null)
                {
                    Console.WriteLine($"ID:{item.Id}-Name:{item.Name}-Age:{item.Age}-Description:{item.Description}-Species:{item.Species.Name}");
                }
                else
                {
                    Console.WriteLine($"ID:{item.Id}-Name:{item.Name}-Age:{item.Age}-Description:{item.Description}-Species:missing data");
                }
            }

            Console.ReadLine();
        }

        static void List(string entity)
        {
            if (entity.ToUpper() == "PET")
            {
                List<Pet> pets = rest.Get<Pet>("pet");
                foreach (var item in pets)
                {
                    if (item.Species != null)
                    {
                        Console.WriteLine($"ID:{item.Id}-Name:{item.Name}-Age:{item.Age}-Description:{item.Description}-Species:{item.Species.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"ID:{item.Id}-Name:{item.Name}-Age:{item.Age}-Description:{item.Description}-Species:missing data");
                    }
                }
            }
            else if (entity.ToUpper() == "SPECIES")
            {
                List<Species> species = rest.Get<Species>("species");
                foreach (var item in species)
                {
                    Console.WriteLine($"ID:{item.Id}-Name:{item.Name}-Description:{item.Description}");
                }
            }
            else if (entity.ToUpper() == "ADOPTION")
            {
                List<Adoption> adoptions = rest.Get<Adoption>("adoption");
                foreach (var item in adoptions)
                {
                    if (item.Pet != null)
                    {
                        Console.WriteLine($"ID:{item.Id}-Pet name:{item.Pet.Name}-Date:{item.AdoptionDate.ToString("yyyy.MM.dd")}-Adopter name:{item.AdopterName}-Contact:{item.Contact}");
                    }
                    else
                    {
                        Console.WriteLine($"ID:{item.Id}-Pet name:missing data-Date:{item.AdoptionDate.ToString("yyyy.MM.dd")}-Adopter name:{item.AdopterName}-Contact:{item.Contact}");
                    }                    
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

                rest.Post(new Pet() { Id = id, Name = name, Age = age, Description = desc, SpeciesId = spec}, "pet");
            }
            else if (entity.ToUpper() == "SPECIES")
            {
                Console.WriteLine("NEW SPECIES");
                Console.Write("Enter Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Description: ");
                string desc = Console.ReadLine();

                rest.Post(new Species() { Id = id, Name = name, Description = desc }, "species");
            }
            else if (entity.ToUpper() == "ADOPTION")
            {
                Console.WriteLine("NEW ADOPTION");
                Console.Write("Enter Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Pet Id: ");
                int petId = int.Parse(Console.ReadLine());
                Console.Write("Enter date (yyyy.MM.dd): ");
                DateTime dt = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter adopter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter contact: ");
                string contact = Console.ReadLine();

                rest.Post(new Adoption() { Id = id, PetId = petId, AdoptionDate = dt, AdopterName = name, Contact = contact}, "adoption");
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
                Console.Write($"New age [old: {one.Age}]: ");
                int age = int.Parse(Console.ReadLine());
                one.Name = name;
                one.Age = age;
                rest.Put(one, "pet");
            }
            else if(entity.ToUpper() == "SPECIES")
            {
                Console.WriteLine("UPDATE SPECIES");
                Console.Write("Enter Species's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Species one = rest.Get<Species>(id, "species");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                Console.Write($"New description [old: {one.Description}]: ");
                string desc = Console.ReadLine();
                one.Name = name;
                one.Description = desc;
                rest.Put(one, "species");
            }
            else if(entity.ToUpper() == "ADOPTION")
            {
                Console.WriteLine("UPDATE ADOPTION");
                Console.Write("Enter Adoption's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Adoption one = rest.Get<Adoption>(id, "adoption");
                Console.Write($"New adopter name [old: {one.AdopterName}]: ");
                string name = Console.ReadLine();
                Console.Write($"New contact (i.e. e-mail or phone) [old: {one.Contact}]: ");
                string contact = Console.ReadLine();
                one.AdopterName = name;
                one.Contact = contact;
                rest.Put(one, "adoption");
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
            else if (entity.ToUpper() == "SPECIES")
            {
                Console.Write("Enter Species's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "species");
            }
            else if (entity.ToUpper() == "ADOPTION")
            {
                Console.Write("Enter Adoption's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "adoption");
            }
        }
    }
}
