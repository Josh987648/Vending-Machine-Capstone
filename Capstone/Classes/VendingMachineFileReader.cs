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
            const int SlotIndex = 0;
            const int ProductIndex = 1;
            const int PriceIndex = 2;
            const int InitialStockAmount = 5;

            Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split('|');
                    List<VendingMachineItem> items = new List<VendingMachineItem>();
                    string itemName = values[ProductIndex];
                    decimal itemCost = decimal.Parse(values[PriceIndex]);

                    if (values[SlotIndex].StartsWith("A"))
                    {
                        for (int i = 0; i < InitialStockAmount; i++)
                        {
                            items.Add(new Chips(itemName, itemCost));
                        }
                    }
                    else if (values[SlotIndex].StartsWith("B"))
                    {
                        for (int i = 0; i < InitialStockAmount; i++)
                        {
                            items.Add(new Candy(itemName, itemCost));
                        }
                    }
                    else if (values[SlotIndex].StartsWith("C"))
                    {
                        for (int i = 0; i < InitialStockAmount; i++)
                        {
                            items.Add(new Beverages(itemName, itemCost));
                        }
                    }
                    else if (values[SlotIndex].StartsWith("D"))
                    {
                        for (int i = 0; i < InitialStockAmount; i++)
                        {
                            items.Add(new Gum(itemName, itemCost));
                        }
                    }

                    inventory.Add(values[SlotIndex], items);
                }
                return inventory;
            }
        }
    }
}
