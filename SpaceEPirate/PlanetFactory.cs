using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceEPirate
{
    class PlanetFactory
    {
        public string planetName = "Prison Planet Gargantuon";
        public double xCoord = 75;
        public double yCoord = -75;

        public PlanetFactory(string iName, double iXCoord, double iYCoord)
        {
            planetName = iName;
            xCoord = iXCoord;
            yCoord = iYCoord;
        }

        //public static int StartPlanet(PlanetFactory[] smallGalaxy)
        //{
        //    int choice = 0;

        //    Console.WriteLine("Please enter the number for your starting planet:");

        //    for (int i = 0; i < smallGalaxy.Length; i++)
        //    {
        //        Console.WriteLine($"{ i + 1}. { smallGalaxy[i].planetName }");
        //    }

        //    choice = Utility.ErrorHandler(smallGalaxy.Length) - 1;

        //    Console.WriteLine($"You have chosen to begin on Planet {smallGalaxy[choice].planetName}.");
        //    Console.ReadLine();
        //    Console.Clear();
        //    return choice;
        //}

    }
}