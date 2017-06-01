﻿using System;
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
            List<VendingMachineItem> itemsInSlot = this.inventory[slot];
            VendingMachineItem purchasedItem = itemsInSlot[0];
            itemsInSlot.RemoveAt(0);
            this.balance = balance - (purchasedItem.Price);
            return purchasedItem;
        }

<<<<<<< HEAD
        public Change CompleteTrans
        {
            // if ( % 25,
        }

=======
>>>>>>> e1d76fa00528dfe6d8686dc0f9d68a8c4ea24902
        public bool IsSoldOut(string slot)
        {
            return inventory[slot].Count == 0;
        }

        public Dictionary<string, int> EndTransaction() // total change
        {
            Change change = new Change();
            return change.MakeChange(this.balance);    
        }

        // Constructor

        public VendingMachine()
        {

        }
    }
}
