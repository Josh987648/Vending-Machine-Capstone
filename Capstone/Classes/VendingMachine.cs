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


        public decimal FeedMoney(decimal dollars)
        {
            balance += dollars;
            return balance;
        }

        public VendingMachineItem Purchase(string slot)
        {
            if(!IsValidSlot(slot) || IsSoldOut(slot) || !DoesHaveEnoughMoney(slot))
            {
                return null;
            }

            List<VendingMachineItem> itemsInSlot = this.inventory[slot];
            VendingMachineItem purchasedItem = itemsInSlot[0];
            itemsInSlot.RemoveAt(0);
            this.balance = balance - (purchasedItem.Price);

            return purchasedItem;
        }

        public bool DoesHaveEnoughMoney(string slot)
        {
            if(IsValidSlot(slot) && !IsSoldOut(slot))
            {
                return balance >= inventory[slot][0].Price;
            }
            else
            {
                return false;
            }
        }

        public bool IsSoldOut(string slot)
        {
            return inventory[slot].Count == 0;
        }

        public bool IsValidSlot(string slot)
        {
            return inventory.ContainsKey(slot.ToUpper());
        }

        public Change EndTransaction() // total change
        {
            Change change = new Change(this.balance);
            this.balance = 0;

            return change;
        }


        // Constructor

        public VendingMachine()
        {

        }
    }
}