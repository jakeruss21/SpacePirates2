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


        public static int StartPlanet(PlanetFactory[] smallGalaxy)
        {
            int choice = 0;

            Console.WriteLine("Please enter the number for your starting planet:");

            for (int i = 0; i < smallGalaxy.Length; i++)
            {
                Console.WriteLine($"{ i + 1}. { smallGalaxy[i].planetName }");
            }

            choice = Utility.ErrorHandler(smallGalaxy.Length) - 1;

            Console.WriteLine($"You have chosen to begin on Planet {smallGalaxy[choice].planetName}.");
            Console.ReadLine();
            Console.Clear();
            return choice;
        }


        internal static double DistanceToPlanet(PlanetFactory startPlanet, PlanetFactory endPlanet)
        {
            double distance = 0;
            distance = Math.Pow((startPlanet.xCoord - endPlanet.xCoord), 2) + Math.Pow((startPlanet.yCoord - endPlanet.yCoord), 2);
            distance = Math.Sqrt(distance);
            return distance;
        }


        internal static int[] MarketValue(int numberOfGoods)
        {
            int[] planetPrices = new int[numberOfGoods];
            Random rand = new Random();

            for (int i = 0; i < numberOfGoods; i++)
            {
                planetPrices[i] = rand.Next(100);
            }

            return planetPrices;
        }
    }
}