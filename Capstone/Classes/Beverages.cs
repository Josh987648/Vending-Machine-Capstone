using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Beverages : VendingMachineItem
    {
        public override string Consume()
        {
            return "Glug Glug, Yum!";
        }
    }
}
