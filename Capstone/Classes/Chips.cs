using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Chips : VendingMachineItem
    {
        public override string Consume()
        {
            return "Crunch Cruch, Yum!";
        }
    }
}
