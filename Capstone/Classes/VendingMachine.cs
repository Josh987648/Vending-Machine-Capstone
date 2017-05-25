﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    class VendingMachine
    {
        private Dictionary<string, List<VendingMachineItem>> inventory;
        public VendingMachine(Dictionary<string, List<VendingMachineItem>> inventory)
        {
            this.inventory = inventory;
        }

        public void FeedMoney(decimal dollars)
        {

        }

        public VendingMachineItem Purchase(string slot)
        {

        }

        public Change CompleteTransaction()
        {

        }

        public bool IsSoldOut(string slot)
        {
            return inventory[slot].Count == 0;
        }
    }
}
