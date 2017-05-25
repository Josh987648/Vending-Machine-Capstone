using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Gum : VendingMachineItem
    {
        public override string Consume()
        {
            return "Chew Chew, Yum!";
        }

        public Gum(string name, decimal price):
            base(name, price)
        {

        }
    }
}
