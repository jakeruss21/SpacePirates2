using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceEPirate
{
    class SpaceShip
    {
        public string shipName = "";
        public int shipCost = 0;
        public int cargoCapacity = 0;
        public double fuelCapacity = 0;
        public int topSpeed = 0;
        


        public SpaceShip(string ishipName, int ishipCost, int icargoCapacity, double ifuelCapacity, int iTopSpeed)
        {
            shipName = ishipName;
            shipCost = ishipCost;
            cargoCapacity = icargoCapacity;
            fuelCapacity = ifuelCapacity;
            topSpeed = iTopSpeed;
        }


        internal static SpaceShip ShipGarage(SpaceShip[] shipShop, SpaceShip currentShip, UserProfile player, TradeGood[] cargoHold)
       {
            int numOptions = shipShop.Length;            
            int shipChoice = 0;

            UserProfile.PrintUserInfo(player, currentShip);

            Console.WriteLine("Welcome to the ship garage. You may select or buy a ship you would like to fly." +
                              $"You currently have {player.cosmicCredits}cc.");
            Console.ReadLine();

            Console.WriteLine($"Please enter the number for the spaceship you want to buy or fly");
            Console.WriteLine($"=========================================================================");
            Console.WriteLine($"Item                 || Cost of Ship  || Amount of Cargo space avalible ");
            Console.WriteLine($"=========================================================================");
            Console.WriteLine($"1. {shipShop[0].shipName}     || {shipShop[0].shipCost}CC           ||  {shipShop[0].cargoCapacity}      ");
            Console.WriteLine($"2. {shipShop[1].shipName}      || {shipShop[1].shipCost}CC        ||  {shipShop[1].cargoCapacity}       ");
            Console.WriteLine($"3. {shipShop[2].shipName}       || {shipShop[2].shipCost}CC        ||  {shipShop[2].cargoCapacity}       ");
    
            shipChoice = Utility.ErrorHandler(numOptions) - 1;
            if (shipChoice < 0)
            {
                Console.WriteLine("Invalid Option.  \"Good bye\"");
                System.Threading.Thread.Sleep(1000);
                return currentShip;
            }
            else if (shipShop[shipChoice].shipCost > player.cosmicCredits)
            {
                Console.WriteLine("Sorry bud, you dont have enough cosmic credits to upgrade your ride. ");
                Console.WriteLine("Please try again");
                return currentShip;
            }
            else
            {
                // subtract the current cargo space from the new ship
                shipShop[shipChoice].cargoCapacity -= TradeGood.TotalCargoSize(cargoHold);
                player.cosmicCredits -= shipShop[shipChoice].shipCost;
                shipShop[shipChoice].shipCost = 0;
                return shipShop[shipChoice];
            }
       }
        
       
    }
}
