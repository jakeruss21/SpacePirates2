﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceEPirate
{
    class StoryLine
    {
        static void StartPage(string title = "")
        {
            Console.Title = "ASCII Art";
            title = @"
  ██████  ██▓███   ▄▄▄       ▄████▄  ▓█████     ██▓███   ██▓ ██▀███   ▄▄▄     ▄▄▄█████▓▓█████   ██████ 
▒██    ▒ ▓██░  ██▒▒████▄    ▒██▀ ▀█  ▓█   ▀    ▓██░  ██▒▓██▒▓██ ▒ ██▒▒████▄   ▓  ██▒ ▓▒▓█   ▀ ▒██    ▒ 
░ ▓██▄   ▓██░ ██▓▒▒██  ▀█▄  ▒▓█    ▄ ▒███      ▓██░ ██▓▒▒██▒▓██ ░▄█ ▒▒██  ▀█▄ ▒ ▓██░ ▒░▒███   ░ ▓██▄   
  ▒   ██▒▒██▄█▓▒ ▒░██▄▄▄▄██ ▒▓▓▄ ▄██▒▒▓█  ▄    ▒██▄█▓▒ ▒░██░▒██▀▀█▄  ░██▄▄▄▄██░ ▓██▓ ░ ▒▓█  ▄   ▒   ██▒
▒██████▒▒▒██▒ ░  ░ ▓█   ▓██▒▒ ▓███▀ ░░▒████▒   ▒██▒ ░  ░░██░░██▓ ▒██▒ ▓█   ▓██▒ ▒██▒ ░ ░▒████▒▒██████▒▒
▒ ▒▓▒ ▒ ░▒▓▒░ ░  ░ ▒▒   ▓▒█░░ ░▒ ▒  ░░░ ▒░ ░   ▒▓▒░ ░  ░░▓  ░ ▒▓ ░▒▓░ ▒▒   ▓▒█░ ▒ ░░   ░░ ▒░ ░▒ ▒▓▒ ▒ ░
░ ░▒  ░ ░░▒ ░       ▒   ▒▒ ░  ░  ▒    ░ ░  ░   ░▒ ░      ▒ ░  ░▒ ░ ▒░  ▒   ▒▒ ░   ░     ░ ░  ░░ ░▒  ░ ░
░  ░  ░  ░░         ░   ▒   ░           ░      ░░        ▒ ░  ░░   ░   ░   ▒    ░         ░   ░  ░  ░  
      ░                 ░  ░░ ░         ░  ░             ░     ░           ░  ░           ░  ░      ░ ";
            Console.WriteLine(title);
            Console.WriteLine("Press <Enter> to continue...");
            Console.ReadLine();
            Console.Clear();

        }


        internal static void Run()
        {
            //Create the types of Tradable Goods as objects
            TradeGood[] cargoInventory = new TradeGood[4]
            {
                new TradeGood ("Oil", 5),
                new TradeGood ("Silver", 10),
                new TradeGood ("Gold", 25),
                new TradeGood ("Titanium", 10)
            };

            //Create the planets as objects
            PlanetFactory[] smallGalaxy = new PlanetFactory[8]
                {
                    new PlanetFactory("Earth", 0, 0),
                    new PlanetFactory("Alpha Centari", 0, -4.367),
                    new PlanetFactory("M63", -5, 4),
                    new PlanetFactory("Magrathea", 50, 50),
                    new PlanetFactory("Vogosphere", -15, 10),
                    new PlanetFactory("Arrakis", 7, 3),
                    new PlanetFactory("Corrin", -3, -9),
                    new PlanetFactory("Helion Prime", -35, -35)
                };

            // Create space ships as objects
            SpaceShip[] shipShop = new SpaceShip[]
            {
                new SpaceShip("Simple Simon", 000, 3000, 10, 4),
                new SpaceShip("Space Knight", 5000, 3500, 40, 7),
                new SpaceShip("Avenger Jet", 10000, 2000, 100, 9)
                
            };

            StartPage();

            UserProfile player = new UserProfile();
            Console.Clear();
            StartPoint(player);
            BeginAdventure(player, smallGalaxy, shipShop, cargoInventory);
            EndGameMessage(player, "");
        }


        static void StartPoint(UserProfile player)
        {
            Console.WriteLine($"The year was 3058, the year of the dog. You, {player.userName}, have been working with your " +
                $"\n grandfather for some time learning the family business, with the hope of one day taking over. " +
                $"\n Little did he know that his time was coming. Your grandfather was mysteriously killed while on a " +
                $" \nsolo mission by the suspected jealous Space Bandit, Derricque! It is now up to you, {player.userName}, "+
                $" \n to continue yourgrandfather's life passion, all while avenging his death! \nGood Luck!");


            Console.WriteLine("Press <Enter> to continue...");
            Console.ReadLine();
            Console.WriteLine("\n");
            Console.WriteLine("\n Instructions: You have been tasked to travel throughout the known territories to trade goods and make money." +
                    $"\nYou can trade goods at the Market on each planet. You can also purchase and repair your ship at Shipshape's " +
                    $"\nShip Shop. Travel to each different planet to trade the goods and make or lose credits. Make as much  " +
                    $" \nprofit as you can, as that will be the only way to find out what happened to your grandfather! But beware, you " +
                     $"\n have a limited time before you're caught by Derricque! \n Good luck { player.userName}.");
            Console.WriteLine("Press <Enter> to continue...");
            Console.ReadLine();
            Console.Clear();
        }
        public static void EndGameMessage(UserProfile player, string exitMessage)
        {
            var totalIncome = player.cosmicCredits - 1000;
            Console.WriteLine(exitMessage);
            Console.WriteLine($"Your time has come to an end {player.userName}. Dont feel down young " +
                $"Padawan your efforts were not useless, during your your adventures you have made {totalIncome} credits " +
                $"and have played for {player.daysPlayed} days.\n");
            Console.WriteLine("Press <ENTER> to close game");
            Console.ReadLine();
        }

        static void BeginAdventure(UserProfile player, PlanetFactory[] smallGalaxy, SpaceShip[] spaceShip, TradeGood[] cargoInventory)
        {
            int option = 0;
            int menuOptions = 4;

            PlanetFactory currentPlanet = smallGalaxy[0];

            int[] setGoodPrice = new int[cargoInventory.Length]; //Set prices of goods at new Planet

            SpaceShip currentShip = spaceShip[0];

            do
            {
                setGoodPrice = PlanetFactory.MarketValue(setGoodPrice.Length);

                for (int i = 0; i < setGoodPrice.Length; i++)
                {
                    cargoInventory[i].cost = setGoodPrice[i];
                }

                do
                {
                    UserProfile.PrintUserInfo(player, currentShip);
                    Console.WriteLine($"Welcome to {currentPlanet.planetName}!  What would you like to do? \n1.The Trader's Market \n2.Shipshape Ship Shop\n" +
                                      $"3.Travel to next planet \n4. Quit the Game");

                    option = Utility.ErrorHandler(menuOptions);

                    Console.Clear();

                    switch (option)
                    {
                        case 1:
                            Economy.MarketPlace(cargoInventory, player, currentShip);  //Pass current ShipObject, GoodObjects, and UserProfile object
                            break;
                        case 2:
                            currentShip = SpaceShip.ShipGarage(spaceShip, currentShip, player, cargoInventory);
                            Console.WriteLine($"You are currently flying the {currentShip.shipName}");
                            currentShip.shipCost = 0;
                            Console.ReadLine();
                            break;
                        case 3:
                            currentPlanet = Travel.GoSomewhere(player, currentShip, currentPlanet, smallGalaxy);
                            break;
                        default:
                            break;
                    }
                    Console.Clear();

                } while (option < 3);

            } while(option != menuOptions || player.daysPlayed >= 14600);

        }

    }
}
