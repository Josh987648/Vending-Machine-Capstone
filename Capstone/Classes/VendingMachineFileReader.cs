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
        public Dictionary<string, List<VendingMachineItem>> ReadInventory(string filePath)
        {
           // string targetPath = @"C:\Users\Sterling Hanak\Pair Projects\team7-c-module1-capstone\etc";
            //string fileName = @"vendingmachine.csv";
            //string fullPath = Path.Combine(targetPath, fileName);

            Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split('|');
                    List<VendingMachineItem> items = new List<VendingMachineItem>();
                    string itemName = values[1];
                    decimal itemCost = decimal.Parse(values[2]);
                    
                        if (values[0].StartsWith("A"))
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                items.Add(new Chips(itemName, itemCost));
                            }
                        }
                        else if (values[0].StartsWith("B"))
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                items.Add(new Candy(itemName, itemCost));
                            }
                        }
                        else if (values[0].StartsWith("C"))
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                items.Add(new Beverages(itemName, itemCost));
                            }
                        }
                        else if (values[0].StartsWith("D"))
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                items.Add(new Gum(itemName, itemCost));
                            }
                        }
                    inventory.Add(values[0], items);
                }
                return inventory;
            }
        }
    }
}
