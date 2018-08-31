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
            SpaceShip[] shipShop = new SpaceShip[3]
            {
                new SpaceShip("Simple Simon", 000, 3000, 10, 4),
                new SpaceShip("Space Knight", 5000, 3500, 40, 7),
                new SpaceShip("Avenger jet", 10000, 2000, 100, 9)
            };

            StartPage();

            UserProfile player = new UserProfile();

            int currentPlanet = 0;
            currentPlanet = PlanetFactory.StartPlanet(smallGalaxy);
            StartPoint(player);
            BeginAdventure(player, smallGalaxy, shipShop, cargoInventory, currentPlanet);
        }


        static void StartPoint(UserProfile player)
        {
            Console.WriteLine($"The year was 3058, the year of the dog. You, {player.userName}, have been working with your grandfather for some time learning the family business, wtih the hope of " +
               $"one day taking over. Little did he know that his time was coming. Your grandfather was mysteriously killed while on a solo mission by " +
               $"the suspected jealous Space Bandit, Derricque! It is now up to you, {player.userName}, to continue your grandfather's life passion all while avenging his death! \n Good Luck!");
            Console.WriteLine("Press <Enter> to continue...");
            Console.ReadLine();
            Console.WriteLine("\n\n");
            Console.WriteLine("Instructions: You have been tasked to travel throughout the known territories to trade goods.  You can trade goods at the Market on each planet. " +
                    $"You can also purchase and repair your ship at Shipshape's Ship Shop.  Travel to each different planet to trade the goods and make a profit, or lose credits. " +
                    $"Make as much profit as you can, as that will be the only way to find out what happened to your grandfather! But beware, you have a limited time before you're caught by Derricque!  Good luck {player.userName}.");
            Console.WriteLine("Press <Enter> to continue...");
            Console.ReadLine();
            Console.Clear();
        }


        static void BeginAdventure(UserProfile player, PlanetFactory[] smallGalaxy, SpaceShip[] spaceShip, TradeGood[] cargoInventory, int setPlanet)
        {
            int option = 0;
            int menuOptions = 3;

            PlanetFactory currentPlanet = smallGalaxy[setPlanet];

            int[] setGoodPrice = new int[cargoInventory.Length]; //Set prices of goods at new Planet

            // Need a loop here so that the player can continue to play for '40' years

            setGoodPrice = PlanetFactory.MarketValue(setGoodPrice.Length);
            for (int i = 0; i < setGoodPrice.Length; i++)
            {
                cargoInventory[i].cost = setGoodPrice[i];
            }

            SpaceShip currentShip = spaceShip[0];

            UserProfile.PrintUserInfo(player, currentShip);
            Console.WriteLine($"Welcome to {currentPlanet.planetName}!  What would you like to do? \n1.The Trader's Market \n2.Shipshape Ship Shop\n3.Travel to next planet");

            option = Utility.ErrorHandler(menuOptions);

            Console.Clear();

            switch (option)
            {
                case 1:
                    Economy.MarketPlace(cargoInventory, player, currentShip);  //Pass current ShipObject, GoodObjects, and UserProfile object
                    Console.Read();
                    break;
                case 2:
                    SpaceShip.ShipGarage(spaceShip, player);
                    currentShip = SpaceShip.ShipGarage(spaceShip, player);
                    Console.WriteLine($"You have purchased the {currentShip.shipName}");
                    Console.ReadLine();
                    break;
                case 3:
                    Travel();
                    break;
                default:
                    break;
            }

        }

               
        internal static void Travel()
        {
            //Put code here
            Console.WriteLine("Nothing here yet");
        }

    }

}
