using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    class VendingMachine
    {
        private decimal balance;
        public decimal Balance
        {
            get { return this.balance; }
        }

        private Dictionary<string, List<VendingMachineItem>> inventory;
        public VendingMachine(Dictionary<string, List<VendingMachineItem>> inventory)
        {
            this.inventory = inventory;
        }

        public void StockFromFile(string fullPath)
        {

        }


        public decimal FeedMoney(decimal dollars)
        {
            balance += dollars;
            return balance;
        }

        public VendingMachineItem Purchase(string slot)
        {
            List<VendingMachineItem> itemsInSlot = this.inventory[slot];
            VendingMachineItem purchasedItem = itemsInSlot[0];
            itemsInSlot.RemoveAt(0);
            this.balance = balance - (purchasedItem.Price / 2);
            return purchasedItem;
        }

        public bool IsSoldOut(string slot)
        {
            return inventory[slot].Count == 0;
        }

        // Constructor

        public VendingMachine()
        {

        }
    }
}
