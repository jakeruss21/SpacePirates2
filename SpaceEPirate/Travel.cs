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

        internal static PlanetFactory GoSomewhere(UserProfile player, SpaceShip currentShip, PlanetFactory currentPlanet, PlanetFactory[] smallGalaxy)
        {
            double[] distance = new double[smallGalaxy.Length];
            int i = 0;
            int option = 0;

            UserProfile.PrintUserInfo(player, currentShip);

            for (i = 0; i < smallGalaxy.Length; i++)
            {
                distance[i] = DistanceToPlanet(currentPlanet, smallGalaxy[i]);
            }

            Console.WriteLine("Please choose a destination");
            do
            {
                for (i = 0; i < smallGalaxy.Length; i++)
                {
                    if (distance[i] > 0 && distance[i] <= currentShip.fuelCapacity)
                    {
                        Console.WriteLine($"{i + 1}. Planet {smallGalaxy[i].planetName} is {distance[i].ToString("#.000")} light years away");
                    }
                }
                Console.WriteLine("\n");
                option = (Utility.ErrorHandler(i) - 1);

                if (currentShip.fuelCapacity < distance[option])
                {
                    Console.WriteLine("You do not have enough fuel to reach that planet, please try again.\n");
                }
            }while (currentShip.fuelCapacity < distance[option]);

            double warpSpeed = GetWarpSpeed(currentShip);

            int timePassed = TravelTime(warpSpeed, distance[option]);

            currentShip.fuelCapacity = currentShip.fuelCapacity - distance[option];
            player.daysPlayed += timePassed;

            currentPlanet = smallGalaxy[option];
            return currentPlanet;
        }

        private static double GetWarpSpeed(SpaceShip currentShip)
        {

            int warpSpeed;
            do
            {
                Console.WriteLine($"Please enter your warp speed (Your ship has a max warp speed of {currentShip.topSpeed}):");
                warpSpeed = Utility.ErrorHandler(currentShip.topSpeed);
            } while (warpSpeed > currentShip.topSpeed);
            return warpSpeed;
        }

        private static int TravelTime(double warpSpeed, double distance)
        {
            int timeTraveled = 0;
            double speed = 0;

            speed = Math.Pow(warpSpeed, (10 / 3)) + Math.Pow((10 - warpSpeed), (-11 / 3));
            timeTraveled = (int)((365 / speed) * distance);
            Console.WriteLine($"You traveled {distance.ToString("#.00")} lightyears in {timeTraveled} days");
            Console.Read();

            return timeTraveled;
        }
    }
}
