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

        public Change(decimal startingBalance)
        {
            currentChange = ((Convert.ToInt32(startingBalance * 100)));
            if (currentChange >= 25)
            {
                numQuarters = currentChange / 25;                
                currentChange = currentChange - (numQuarters * 25);
            }
            if (currentChange >= 10)
            {
                numDimes = currentChange / 10;                
                currentChange = currentChange - (numDimes * 10);
            }
            if (currentChange >= 5)
            {
                numNickels = currentChange / 5;                
                currentChange = currentChange - (numNickels * 5);
            }
        }


     
        
    }
}


