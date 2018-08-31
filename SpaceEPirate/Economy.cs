using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceEPirate
{
    class Economy
    {
        internal static void MarketPlace(TradeGood[] cargoInventory, UserProfile player, SpaceShip currentShip)
        {
            int option = 0;
            int goodChoice = 0;
            int addQuantity = 0;
            int numOptions = 4;

            do
            {
                UserProfile.PrintUserInfo(player, currentShip);
                Console.WriteLine($"What would you like to do? \n1. Buy \n2. Sell \n3. View Inventory \n 4. Go to Planet Menu");

                option = Utility.ErrorHandler(numOptions);

                switch (option)
                {
                    case 1:
                        goodChoice = BuyGoods(cargoInventory);
                        addQuantity = TotalCost(player, cargoInventory[goodChoice], currentShip);
                        TradeGood.AddGoods(cargoInventory[goodChoice], addQuantity);
                        Console.WriteLine($"There are now {cargoInventory[goodChoice].quantity} pieces of {cargoInventory[goodChoice].goodName} in your inventory.");
                        Console.WriteLine("Press <ENTER> to continue...");
                        Console.ReadLine();
                        break;
                    case 2:
                        SellGoods(cargoInventory, player, currentShip);
                        break;
                    case 3:
                        ViewInventory(cargoInventory);
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
                Console.Clear();
            } while (option != 4);
        }

        internal static int BuyGoods(TradeGood[] tradeGoods)
        {
            int numOptions = 4;
            int goodType = 0;

            Console.WriteLine($"Please enter the number for the good you would like to purchase");
            Console.WriteLine($"=========================================================================");
            Console.WriteLine($"Item                 || Cost per Unit    || Cargo space required per unit");
            Console.WriteLine($"1. {tradeGoods[0].goodName}            || {tradeGoods[0].cost}CC              || {tradeGoods[0].size} ");
            Console.WriteLine($"2. {tradeGoods[1].goodName}               || {tradeGoods[1].cost}CC                 || {tradeGoods[1].size} ");
            Console.WriteLine($"3. {tradeGoods[2].goodName}              || {tradeGoods[2].cost}CC             || {tradeGoods[2].size} ");
            Console.WriteLine($"4. {tradeGoods[3].goodName}            || {tradeGoods[3].cost}CC               || {tradeGoods[3].size} ");

            goodType = Utility.ErrorHandler(numOptions);

            return goodType - 1;
        }

        internal static void SellGoods(TradeGood[] cargoInventory, UserProfile player, SpaceShip currentShip)
        {
            ViewInventory(cargoInventory);
            int numOptions = cargoInventory.Length;
            int goodType = 0;
            int sellQuantity = 0;
            int moneyMade = 0;

            Console.WriteLine("What would you like to sell?");
            goodType = Utility.ErrorHandler(numOptions) - 1;

            if (cargoInventory[goodType].quantity > 0)
            {
                Console.WriteLine($"How much of {cargoInventory[goodType].goodName} would you like to sell?" +
                                  $"  You have currently have {cargoInventory[goodType].quantity} pieces of this product available to sell.");
                sellQuantity = Utility.ErrorHandler(cargoInventory[goodType].quantity);

                moneyMade = cargoInventory[goodType].cost * sellQuantity;
                Console.WriteLine($"Congratulations! You made {moneyMade}cc off this transaction");
                Console.WriteLine("Press <ENTER> to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You don't have any of this product to sell.");
                Console.WriteLine("We are now returning you to the Market Menu");
                Console.WriteLine("3...");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("2...");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("1...");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Goodbye");
                System.Threading.Thread.Sleep(500);
            }

            int cargoSpace = sellQuantity * cargoInventory[goodType].size;

            cargoInventory[goodType].quantity -= sellQuantity;
            currentShip.cargoCapacity += (sellQuantity * cargoInventory[goodType].size);
            player.cosmicCredits += moneyMade;
        }


        internal static int TotalCost(UserProfile player, TradeGood tradeGoods, SpaceShip spaceShips)
        {
            int totalCost = 0;
            int newCargo = 0;
            int quantity = 0;
            Boolean insufficient = true;

            do
            {
                Console.Write($"How much of {tradeGoods.goodName} do you want to purchase?  ");

                quantity = Utility.ErrorHandler(1000000);

                totalCost = tradeGoods.cost * quantity;
                newCargo = tradeGoods.size * quantity;

                if (totalCost > player.cosmicCredits)
                {
                    Console.WriteLine($"Insufficient funds.  You have {player.cosmicCredits}cc and {quantity} of {tradeGoods.goodName} costs {totalCost}");
                    Console.WriteLine("Please try again.");
                    insufficient = true;
                }
                else if (newCargo > spaceShips.cargoCapacity)
                {
                    Console.WriteLine($"Insufficient cargo space.  You need {newCargo} space and you only have {spaceShips.cargoCapacity}.");
                    Console.WriteLine("Please try again.");
                    insufficient = true;
                }
                else
                {
                    insufficient = false;
                }
            } while (insufficient == true);

            player.cosmicCredits -= totalCost;
            spaceShips.cargoCapacity -= (quantity * tradeGoods.size);

            return quantity;
        }

        public static void ViewInventory(TradeGood[] cargoInventory)
        {
            Console.WriteLine("You currently have the following in your inventory:");
            Console.WriteLine("Name of Item     In your Ship to sell        Value");
            Console.WriteLine("========================================================");
            for (int i = 0; i < cargoInventory.Length; i++)
            {
                Console.WriteLine($"{i+1}. {cargoInventory[i].goodName}                {cargoInventory[i].quantity}                {cargoInventory[i].cost}");
            }
        }


    }
}