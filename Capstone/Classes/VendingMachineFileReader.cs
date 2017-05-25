using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class VendingMachineFileReader
    {
        public void ReadInventory(string filePath)
        {
            string targetPath = @"C:\Users\Sterling Hanak\Pair Projects\team7-c-module1-capstone\etc";
            string fileName = @"vendingmachine.csv";
            string fullPath = Path.Combine(targetPath, fileName);
            
            using (StreamReader sr = new StreamReader(fullPath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split('|');
                }
            }
        }
    }
}
