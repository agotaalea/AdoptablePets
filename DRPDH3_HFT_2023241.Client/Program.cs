using DRPDH3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DRPDH3_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:47912/", "pet");
        }
    }
}
