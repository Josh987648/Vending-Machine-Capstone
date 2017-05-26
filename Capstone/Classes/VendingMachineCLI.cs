using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;

namespace Capstone.Classes
{
    class VendingMachineCLI
    {
        public void Display()
        {
            string targetPath = Directory.GetCurrentDirectory();
            string fileName = "vendingmachine.csv";
            string fullPath = Path.Combine(targetPath, fileName);
            VendingMachineFileReader vmfr = new VendingMachineFileReader();
            Dictionary<string, List<VendingMachineItem>> inventory = vmfr.ReadInventory(fullPath);
            VendingMachine vm = new VendingMachine(inventory);

            while (true)
            {
                Console.WriteLine("Main Menu");
                Console.Write("[1] Display Vending Machine Items \n[2] Purchase");
                string mainMenuResponse = Console.ReadLine();

                if (mainMenuResponse == "1")
                {
                    // display the dictionary value (vending machine items) from the list of vending machine items from user entered key
                    foreach (KeyValuePair<string, List<VendingMachineItem>> kvp in inventory)
                    {
                        Console.WriteLine(kvp.Value);
                    }
                }

                else if (mainMenuResponse == "2")
                {
                    Console.WriteLine("Purchase Menu",
                    "\n [1] Feed Money",
                    "\n [2] Select Slot ID",
                    "\n [3] Finish Transaction");
                    string purchaseMenuResponse = Console.ReadLine();

                    // 1
                    if (purchaseMenuResponse == "1")
                    {
                        // add the feed money method
                        // accept 1, 2, 5, 10's
                        decimal[] bills = { 1, 2, 5, 10 };
                        Console.WriteLine("Please feed money one bill at a time (Enter bills as integer values)" + // remove 'integer requirement' - replace with error handler that prevets input
                            $"\n Your current Balance is: {null}");
                        Console.ReadLine();
                    }

                    // 2
                    else if (purchaseMenuResponse == "2")
                    {
                        Console.WriteLine("Please enter the slot ID of the item you'd like to purchase");
                        string responseSlotID = Console.ReadLine();
                        bool itemPresence = inventory.TryGetValue(responseSlotID, out List<VendingMachineItem> value);
                        if (itemPresence == true)
                        {
                            //put in the actual add method
                            Console.WriteLine(value + "added to cart");
                        }
                    }

                    // 3
                    else if (purchaseMenuResponse == "3")
                    {
                        // change method
                        // 
                        Console.WriteLine("Complete Transaction");
                    }

                    else
                    {
                        // break from while an return to main
                        Console.WriteLine("Specified Slot ID not found");
                    }
                }
            }
        }       
    }
}
