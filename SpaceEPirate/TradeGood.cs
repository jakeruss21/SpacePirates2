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

        public TradeGood()
        {

        }

        public TradeGood(string iName, int iSize, int iQuantity = 0, int iCost = 0)
        {
            goodName = iName;
            size = iSize;
            quantity = iQuantity;
            cost = iCost;
        }

        internal static void AddGoods(TradeGood add, int addGoods)
        {
            add.quantity += addGoods;
        }

        internal static void SellGoods(TradeGood sell, int sellGoods)
        {
            sell.quantity -= sellGoods;
        }

    }
}
