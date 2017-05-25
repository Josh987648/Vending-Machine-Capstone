using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public abstract class VendingMachineItem
    {
        //Properties
        private string name;
        public string Name
        {
            get { return this.name; }
        }

        private decimal price;
        public decimal Price
        {
            get { return this.price; }
        }

        private int quantity;
        public int Quantity
        {
            get { return this.quantity; }
        }

        private string slotID;
        public string SlotId
        {
            get { return this.slotID; }
        }

        public abstract string Consume();

    }
}
