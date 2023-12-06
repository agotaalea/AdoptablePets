using DRPDH3_HFT_2023241.Logic;
using DRPDH3_HFT_2023241.Models;
using DRPDH3_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DRPDH3_HFT_2023241.Test
{
    [TestFixture]
    public class PetLogicTester
    {
        PetLogic logic;
        Mock<IRepository<Pet>> mockPetRepo;
        Mock<IRepository<Adoption>> mockAdoptRepo;
        Mock<IRepository<Species>> mockSpecRepo;

        [SetUp]
        public void Init()
        {
            mockPetRepo = new Mock<IRepository<Pet>>();
            mockAdoptRepo = new Mock<IRepository<Adoption>>();
            mockSpecRepo = new Mock<IRepository<Species>>();

            mockPetRepo.Setup(p => p.ReadAll()).Returns(new List<Pet>()
            {
                new Pet("1;1;Shiba;4;Rossz"),
                new Pet("2;2;Bella;5;Jo kutya"),
                new Pet("3;3;Bendzsi;2;Okos"),
                new Pet("4;4;Kakukk;3;Hangos madarka"),
                new Pet("5;5;Eszter;2;Sokat maszik"),
                new Pet("6;4;Kiscsibe;1;Mindig ehes"),
                new Pet("7;2;Vuk;7;Ravasz"),
                new Pet("8;3;Sanyi;1;Fekete szoru"),
            }.AsQueryable());

            mockAdoptRepo.Setup(p => p.ReadAll()).Returns(new List<Adoption>()
            {
                new Adoption("1;1;Lea;2023.01.01;+36301234567"),
                new Adoption("2;2;Lea;2023.01.01;+36301234567"),
                new Adoption("3;3;Lea;2023.01.03;+36301234567"),
                new Adoption("4;8;Sanyi;2023.05.25;sanyika.sanyi@gmail.com"),
                new Adoption("5;3;Sanyi;2023.06.03;sanyika.sanyi@gmail.com"),
                new Adoption("6;8;Lea;2023.06.04;+36301234567"),
            }.AsQueryable());

            mockSpecRepo.Setup(p => p.ReadAll()).Returns(new List<Species>()
            {
                new Species("1;Vadaszgoreny;Budosek es sokat rosszalkodnak"),
                new Species("2;Kutya;Okos"),
                new Species("3;Macska;Szep"),
                new Species("4;Madar;Hangos"),
                new Species("5;Prerikutya;Aranyos"),
            }.AsQueryable());

            logic = new PetLogic(mockPetRepo.Object, mockAdoptRepo.Object, mockSpecRepo.Object);
        }

        [Test]
        public void GetPetsBySpeciesTest()
        {
            List<int> actual = logic.GetPetsBySpecies("kutya").Select(p => p.Id).ToList();
            List<int> expected = new List<int>()
            {
                2, 7
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPetsByAdoptonDateTest()
        {
            DateTime dt = new DateTime(2023, 01, 01);
            List<int> actual = logic.GetPetsByAdoptonDate(dt).Select(p => p.Id).ToList();
            List<int> expected = new List<int>()
            {
                1, 2
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetNLeastAdoptedTest()
        {
            List<int> actual = logic.GetNLeastAdopted(2).Select(p => p.Id).ToList();
            List<int> expected = new List<int>()
            {
                1, 2
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPetsAdoptedByTest()
        {
            List<int> actual = logic.GetPetsAdoptedBy("Lea").Select(p => p.Id).ToList();
            List<int> expected = new List<int>()
            {
                1, 2, 3, 8
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetNMostAdopted()
        {
            List<int> actual = logic.GetNMostAdopted(2).Select(p => p.Id).ToList();
            List<int> expected = new List<int>()
            {
                3, 8
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreatePetTest()
        {
            var pet = new Pet() { Id = 9 };
            logic.Create(pet);
            mockPetRepo.Verify(r => r.Create(pet), Times.Once);
        }

        [Test]
        public void CreatePetTestAlreadyExists()
        {
            var pet = new Pet() { Id = 1 };
            try
            {
                logic.Create(pet);
            }
            catch { }
            mockPetRepo.Verify(r => r.Create(pet), Times.Never);
        }
    }
}
