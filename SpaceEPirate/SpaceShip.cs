using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceEPirate
{
    class SpaceShip
    {
        public string shipName;
        public int shipCost;
        public int cargoCapacity;
        public double totalFuelCapacity;
        public double currentFuelCapacity;
        public int topSpeed;
        
        
        public SpaceShip(string ishipName, int ishipCost, int icargoCapacity, double ifuelCapacity, int iTopSpeed)
        {
            shipName = ishipName;
            shipCost = ishipCost;
            cargoCapacity = icargoCapacity;
            totalFuelCapacity = ifuelCapacity;
            currentFuelCapacity = ifuelCapacity;
            topSpeed = iTopSpeed;
        }
            

        internal static SpaceShip ShipGarage(SpaceShip[] shipShop, SpaceShip currentShip, UserProfile player, TradeGood[] cargoHold)
        {
            int option = 0;
            int numOptions = 3;

            do
            {
                UserProfile.PrintUserInfo(player, currentShip);
                Console.WriteLine($"Welcome to Ship Shape's Ship Shop!\n" +
                                  $"What would you like to do? \n1. Buy a ship\n2. Refuel your ship \n3. Return to Planet Menu");

                option = Utility.ErrorHandler(numOptions);

                switch (option)
                {
                    case 1:
                        currentShip = BuyShip(shipShop, currentShip, player, cargoHold);
                        break;
                    case 2:
                        RefuelShip(currentShip, player);
                        break;
                    default:
                        break;
                }
                Console.Clear();
            } while (option != 3);

            return currentShip;
        }


        internal static SpaceShip BuyShip(SpaceShip[] shipShop, SpaceShip currentShip, UserProfile player, TradeGood[] cargoHold)
        { 
            int numOptions = shipShop.Length;            
            int shipChoice = 0;

            UserProfile.PrintUserInfo(player, currentShip);

            Console.WriteLine($"Please enter the number for the spaceship you want to buy or fly");
            Console.WriteLine($"===============================================================================================================");
            Console.WriteLine($"     Ship            || Cost of Ship  || Amount of Cargo space avalible   ||  Fuel Capacity     ||   Top Speed");
            Console.WriteLine($"===============================================================================================================");
            Console.WriteLine($"1. {shipShop[0].shipName}     || {shipShop[0].shipCost}CC           ||  {shipShop[0].cargoCapacity}     ||    {shipShop[0].totalFuelCapacity}    " +
                              $"  ||     {shipShop[0].topSpeed} ");
            Console.WriteLine($"1. {shipShop[1].shipName}     || {shipShop[1].shipCost}CC           ||  {shipShop[1].cargoCapacity}     ||    {shipShop[1].totalFuelCapacity}    " +
                              $"  ||     {shipShop[1].topSpeed} ");
            Console.WriteLine($"1. {shipShop[2].shipName}     || {shipShop[2].shipCost}CC           ||  {shipShop[2].cargoCapacity}     ||    {shipShop[2].totalFuelCapacity}    " +
                              $"  ||     {shipShop[0].topSpeed} ");

            shipChoice = Utility.ErrorHandler(numOptions) - 1;
            if (shipChoice < 0)
            {
                Console.WriteLine("Invalid Option.  \"Good bye\"");
                System.Threading.Thread.Sleep(1000);
                return currentShip;
            }
            else if (shipShop[shipChoice].shipCost > player.cosmicCredits)
            {
                Console.WriteLine("Sorry bud, you dont have enough cosmic credits to buy a new ride. ");
                Console.WriteLine("Please try again");
                Console.Read();
                return currentShip;
            }
            else
            {
                // subtract the current cargo space from the new ship
                shipShop[shipChoice].cargoCapacity -= TradeGood.TotalCargoSize(cargoHold);
                player.cosmicCredits -= shipShop[shipChoice].shipCost;
                shipShop[shipChoice].shipCost = 0;
                currentShip.cargoCapacity += TradeGood.TotalCargoSize(cargoHold);

                Console.WriteLine($"You have purchased the {shipShop[shipChoice].shipName}!");
                Console.Read();
                return shipShop[shipChoice];
            }
        }
        

        internal static void RefuelShip (SpaceShip currentShip, UserProfile player)
        {
            int fuelCost;
            int totFuelCost;
            double option;
            double costToFill;
            double neededFuel;
            bool enoughMoney = false;

            Random rand = new Random();

            fuelCost = rand.Next(20);
            neededFuel = currentShip.totalFuelCapacity - currentShip.currentFuelCapacity;
            costToFill = fuelCost * neededFuel;

            Console.WriteLine($"Fuel Cost: {fuelCost}");
            Console.WriteLine($"Current Fuel Level: {currentShip.currentFuelCapacity}");
            Console.WriteLine($"Fuel Capacity: {currentShip.totalFuelCapacity}");
            Console.WriteLine($"Cost to fill: {costToFill}/n");

            Console.WriteLine($"How many units of fuel would you like to put into the {currentShip.shipName}?/n" +
                              $"You can fill up to {neededFuel}");

            do
            {
                int canPay = player.cosmicCredits / fuelCost;

                option = Utility.DoubleErrorHandler(neededFuel);
                costToFill = option * fuelCost;
                if(costToFill > player.cosmicCredits)
                {
                    Console.WriteLine("You don't have enough CC to purchase that much fuel");
                    Console.WriteLine($"You only have enough CC to buy {canPay} units of fuel.");
                    enoughMoney = false;
                }
                else
                {
                    enoughMoney = true;
                }
            } while (!enoughMoney);

            totFuelCost = Convert.ToInt32(costToFill);

            player.cosmicCredits -= totFuelCost;
            currentShip.currentFuelCapacity += option;            
        }
       
    }
}
