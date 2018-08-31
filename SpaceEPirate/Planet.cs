using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceEPirate
{
    class Planet
    {
        internal static string StartPlanet (int planetType = 0)
        {
            string planetName = "";
            int numOptions = 8;

            Console.WriteLine("Please enter the number for your starting planet:");
            Console.WriteLine("1. Earth");
            Console.WriteLine("2. Alpha Centari");
            Console.WriteLine("3. M63");

            planetType = Utility.ErrorHandler(numOptions);
            

            switch (planetType)
            {
                case 1:
                    planetName = "Earth";
                    break;
                case 2:
                    planetName = "Alpha Centari";
                    break;
                case 3:
                    planetName = "M63";
                    break;
                default:
                    planetName = "Prison Planet Gargantuon";
                    break;
            }

            Console.WriteLine($"You have chosen to begin on Planet {planetName}.");
            Console.ReadLine();
            Console.Clear();
            return planetName;
        }
    }
}
