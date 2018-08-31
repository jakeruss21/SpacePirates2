﻿using System;
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
            int j = 1;
            int option = 0;

            UserProfile.PrintUserInfo(player, currentShip);

            for(int i = 0; i < smallGalaxy.Length; i++)
            {
                distance[i] = DistanceToPlanet(currentPlanet, smallGalaxy[i]);
            }

            do
            {
                Console.WriteLine("Please choose a destination");

                for (int i = 0; i < smallGalaxy.Length; i++)
                {
                    if (distance[i] > 0 && distance[i] <= currentShip.fuelCapacity)
                    {
                        Console.WriteLine($"{j}. Planet {smallGalaxy[i].planetName} is {distance[i].ToString("#.000")} light years away");
                        j++;
                    }
                }

                Console.WriteLine("\n");

                option = Utility.ErrorHandler(j);

            } while (j < 4);

        }
    }
}
