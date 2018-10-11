using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceEPirate
{
    class UserProfile
    {
        public string userName = "";
        public int cosmicCredits;
        public int earnedCredits;
        public double daysPlayed;

        public UserProfile()
        {
            userName = UserName();
            cosmicCredits = 1000;
            earnedCredits = 0;
            daysPlayed = 0;
        }
        
        internal static string UserName(string name = "")
        {
            Console.WriteLine(":::Character Creation:::");
            Console.WriteLine("==================================");
            Console.Write("Please enter the character's name:  ");
            name = Console.ReadLine();

            Console.WriteLine($"Your character name is {name}.");
            Console.WriteLine($"You begin with 1000 cosmic credits");
            Console.WriteLine($"Your inherited ship is the Simple Simon");
            return name;
        }

        internal static void PrintUserInfo(UserProfile player, SpaceShip currentShip)
        {
            Console.WriteLine($"Name: {player.userName}   Credits: {player.cosmicCredits}      Ship: {currentShip.shipName}      " +
                              $"Fuel: {currentShip.fuelCapacity.ToString("#.000")}   Cargo Space: {currentShip.cargoCapacity}   " +
                              $"Days Elapsed: {player.daysPlayed} \n");
        }
    }
}
