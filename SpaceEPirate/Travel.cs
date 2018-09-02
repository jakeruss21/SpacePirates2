using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceEPirate
{
    class Travel
    {
        internal static double DistanceToPlanet(PlanetFactory startPlanet, PlanetFactory endPlanet)
        {
            double distance = 0;
            distance = Math.Pow((startPlanet.xCoord - endPlanet.xCoord), 2) + Math.Pow((startPlanet.yCoord - endPlanet.yCoord), 2);
            distance = Math.Sqrt(distance);
            return distance;
        }

        internal static void GoSomewhere(UserProfile player, SpaceShip currentShip, PlanetFactory currentPlanet, PlanetFactory[] smallGalaxy)
        {
            double[] distance = new double[smallGalaxy.Length];
            int i = 0;
            int option = 0;

            UserProfile.PrintUserInfo(player, currentShip);

            for (i = 0; i < smallGalaxy.Length; i++)
            {
                distance[i] = DistanceToPlanet(currentPlanet, smallGalaxy[i]);
            }

            do
            {
                Console.WriteLine("Please choose a destination");

                for (i = 0; i < smallGalaxy.Length; i++)
                {
                    if (distance[i] > 0 && distance[i] <= currentShip.fuelCapacity)
                    {
                        Console.WriteLine($"{i + 1}. Planet {smallGalaxy[i].planetName} is {distance[i].ToString("#.000")} light years away");
                    }
                }

                Console.WriteLine("\n");

                option = (Utility.ErrorHandler(i) - 1);

            } while (i < 4);
        }

        private static int GetWarpSpeed(SpaceShip currentShip)
        {

            int warpSpeed;
            do
            {
                Console.WriteLine($"Please enter your warp speed (Your ship has a max warp speed of {currentShip.topSpeed}");
                warpSpeed = Utility.ErrorHandler(currentShip.topSpeed);
            } while (warpSpeed > currentShip.topSpeed);
            return warpSpeed;
        }
    }
}
