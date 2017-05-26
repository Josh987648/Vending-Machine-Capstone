using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class Change
    {
        //Properties
        private int numQuarters;
        public int NumQuarters
        {
            get { return this.numQuarters; }
        }

        private int numDimes;
        public int NumDimes
        {
            get { return this.numDimes; }
        }

        private int numNickels;
        public int NumNickels
        {
            get { return this.numNickels; }
        }

        private int currentChange;
        public int CurrentChange
        {
            get { return this.currentChange; }
        }

        
        //Method
        public Dictionary<string, int> MakeChange(decimal startingMoney, decimal purchasePrice)
        {
            Dictionary<string, int> totalChange = new Dictionary<string, int>();
            currentChange = ((Convert.ToInt32(startingMoney * 100)) - (Convert.ToInt32(purchasePrice * 100)));
            if (currentChange >= 25)
            {
                numQuarters = currentChange / 25;
                totalChange.Add("Number of Quarters", numQuarters);
                currentChange = currentChange - (numQuarters * 25);
            }
            if (currentChange >= 10) 
            {
                numDimes = currentChange / 10;
                totalChange.Add("Number of Dimes", numDimes);
                currentChange = currentChange - (numDimes * 10);
            }
            if (currentChange >= 5)
            {
                numNickels = currentChange / 5;
                totalChange.Add("Number of Nickels", numNickels);
                currentChange = currentChange - (numNickels * 5);
            }
            return totalChange;
        }
    }
}
