using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
namespace Capstone.Classes
{
    public class Candy : VendingMachineItem
    {
        public override string Consume()
        {
            return "Munch Munch, Yum!";
        }
    }
}
