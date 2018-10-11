using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceEPirate
{
    class TradeGood
    {
        public string goodName = "";
        public int size = 0;
        public int quantity = 0;
        public int cost = 0;
        public int prevBuy = 0;

        public TradeGood()
        {

        }

        public TradeGood(string iName, int iSize, int iQuantity = 0, int iCost = 0, int iPrevBuy = 0)
        {
            goodName = iName;
            size = iSize;
            quantity = iQuantity;
            cost = iCost;
            prevBuy = iPrevBuy;
        }

        internal static void AddGoods(TradeGood add, int addGoods)
        {
            add.quantity += addGoods;
        }

        internal static void PreviousPurchase(TradeGood add, int purchase)
        {
            add.prevBuy = purchase;
        }

        internal static void SellGoods(TradeGood sell, int sellGoods)
        {
            sell.quantity -= sellGoods;
        }

        internal static int TotalCargoSize(TradeGood[] tradeGoods)
        {
            int cargoHold = 0;

            for (int i = 0; i < tradeGoods.Length; i++)
            {
                cargoHold += (tradeGoods[i].size * tradeGoods[i].quantity);
            }
            return cargoHold;
        }


        internal static int MarketValue(string goodName)
        {
            int planetPrices;
            Random rand = new Random();

            switch (goodName)
            {
                case "Oil":
                    planetPrices = rand.Next(50) + 5;
                    break;
                case "Silver":
                    planetPrices = rand.Next(100) + 20;
                    break;
                case "Gold":
                    planetPrices = rand.Next(150) + 25;
                    break;
                case "Titanium":
                    planetPrices = rand.Next(500) + 50;
                    break;
                default:
                    planetPrices = 0;
                    break;
            }
            return planetPrices;
        }
    }
}
