using System;
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
            TradeGood[] cargoInventory = 
                    {
                        new TradeGood ("Oil", 5),
                        new TradeGood ("Silver", 10),
                        new TradeGood ("Gold", 25),
                        new TradeGood ("Titanium", 10)
                    };

            //Create the planets as objects
            PlanetFactory[] smallGalaxy = 
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
            SpaceShip[] shipShop = 
                    {
                        new SpaceShip("Simple Simon", 000, 3000, 10, 4),
                        new SpaceShip("Space Knight", 5000, 3500, 40, 7),
                        new SpaceShip("Avenger Jet", 10000, 2000, 100, 9)
                    };

            StartPage();

            UserProfile player = new UserProfile();
            StartPoint(player);
            BeginAdventure(player, smallGalaxy, shipShop, cargoInventory);
            EndGameMessage(player);
        }


        static void StartPoint(UserProfile player)
        {
            Console.Clear();
            Console.WriteLine($"The year was 3058, the year of the dog. You, {player.userName}, have been working with your " +
                $"grandfather for some time learning the family business, with the hope of one day taking over. " +
                $"Little did he know that his time was coming to an end. Your grandfather was mysteriously killed while on a " +
                $"solo mission commissioned by the notorious Space Bandit, Derrilique! It is now up to you, {player.userName}, "+
                $"to continue yourgrandfather's life passion, and possibly even avenge his death...\n");
            
            Console.WriteLine("Press <Enter> to continue...");
            Console.ReadLine();
            Console.WriteLine("\n Instructions: You have been tasked to travel throughout the known territories to trade goods and make money. " +
                    $"You can trade goods at the Market on each planet. You can also purchase and repair your ship at Shipshape's " +
                    $"Ship Shop. Travel to each different planet to trade the goods and make a profit, hopefully. Make as much " +
                    $"profit as you can, as that will be the only way to find out what happened to your grandfather! But beware, you " +
                    $"have a limited time before you're caught by Derrilique! \nGood luck {player.userName}.\n");
            Console.WriteLine("Press <Enter> to continue...");
            Console.ReadLine();
            Console.Clear();
        }


        public static void EndGameMessage(UserProfile player)
        {
            Console.Clear();
            Console.WriteLine($"Your time has come to an end {player.userName}. Dont feel down young " +
                $"Padawan your efforts were not useless, during your your adventures you have made {player.earnedCredits} credits " +
                $"and have played for {player.daysPlayed} days.\n");
            Console.WriteLine("Press <ENTER> to close the game.");
            Console.ReadLine();
        }

        static void BeginAdventure(UserProfile player, PlanetFactory[] smallGalaxy, SpaceShip[] spaceShip, TradeGood[] cargoTypes)
        {
            bool quit = false;
            string option;

            PlanetFactory currentPlanet = smallGalaxy[0];  //The user starts at Plant '0' which is Earth

            SpaceShip currentShip = spaceShip[0];  //This is the beginning ship

            do  //The program will loop through this until they decide to quit or 14600 days (40 years) have passed
            {
                
                for (int i = 0; i < cargoTypes.Length; i++)
                {
                    cargoTypes[i].cost = TradeGood.MarketValue(cargoTypes[i].goodName);
                }

                do  //The user will stay at this planet until they decide to travel to another planet
                {
                    UserProfile.PrintUserInfo(player, currentShip);  //Keeps a header at the top of the game that displays the player's information as well as some information about the ship
                    Console.WriteLine($"Welcome to {currentPlanet.planetName}!  What would you like to do? \nVisit the Trader's Market    <Market>\nGo to Shipshape's Ship Shop  <Ship>\n" +
                                      $"Travel to the next planet    <Travel>\nQuit the Game <Quit>");

                    option = Console.ReadLine();  //String input for the option chosen by the player    //Error checked by the switch statement

                    switch (option)
                    {
                        case "Market":
                            Economy.MarketPlace(cargoTypes, player, currentShip);  //Goes to the Marketplace to buy and sell goods, as well as view their inventory
                            break;
                        case "Ship":
                            currentShip = SpaceShip.ShipGarage(spaceShip, currentShip, player, cargoTypes);  //Goes to the shipyard to buy a new ship
                            break;
                        case "Travel":
                            currentPlanet = Travel.GoSomewhere(player, currentShip, currentPlanet, smallGalaxy);  //Go somewhere else in this small part of the galaxy
                            break;
                        case "Quit":
                            quit = true;
                            break;
                        default:                                                                                //Error handles any incorrect input
                            Console.WriteLine("Please enter a valid option.  The input is Case-sensative");
                            Console.WriteLine("Press <Enter> to try again.");
                            Console.ReadLine();
                            break;
                    }
                    Console.Clear();

                } while (option != "Travel" && !quit);

            } while(!quit && player.daysPlayed <= 14600);

        }

    }
}
