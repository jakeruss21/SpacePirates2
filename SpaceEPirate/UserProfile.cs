using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceEPirate
{
    class UserProfile
    {
        public string userName = "";
        public int cosmicCredits = 1000;
        public int yearsPlayed;

        public UserProfile()
        {
            userName = UserName();
            cosmicCredits = 1000;
            yearsPlayed = 0;
        }


        internal static string UserName(string name = "")
        {
            Console.WriteLine(":::Character Creation:::");
            Console.WriteLine("==================================");
            Console.Write("Please enter the character's name:  ");
            name = Console.ReadLine();

            Console.WriteLine($"Your character name is {name}.");
            Console.WriteLine($"You have 1000 cosmic credits");
            Console.WriteLine($"Your spaceship is the Simple Simon");
            return name;
        }

        internal static void PrintUserInfo(UserProfile player, SpaceShip currentShip)
        {
            Console.WriteLine($"Name: {player.userName}   Credits: {player.cosmicCredits}      Ship: {currentShip.shipName}      Fuel: {currentShip.fuelCapacity} \n");
        }







    }
}
