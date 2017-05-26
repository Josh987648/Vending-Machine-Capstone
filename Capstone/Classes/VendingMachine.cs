using System;
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

        public void stockFromFile(string fullPath)
        {

        }


        public void FeedMoney(decimal dollars)
        {
            dollars = 0;
        }

        public void Purchase(string slot)
        {
            slot = null; // responseChooseItem
        }

        public void CompleteTransaction()
        {
            // if ( % 25,
        }

        public bool IsSoldOut(string slot)
        {
            return inventory[slot].Count == 0;
        }


        // Constructor?

        public VendingMachine()
        {

        }
    }
}
