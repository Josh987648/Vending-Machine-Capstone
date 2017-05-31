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

            Console.WriteLine("*****************\nVendo-Matic 500\n*****************");

            while (true)
            {
                Console.WriteLine("-----------------\nMain Menu\n-----------------\n[1] Display Vending Machine Inventory\n[2] Purchase an Item\n[3] Quit\n");
                string mainMenuResponse = Console.ReadLine();

                if (mainMenuResponse == "1")
                {
                    Console.WriteLine("Slot".PadRight(21) + "Name".PadRight(21) + "Cost".PadRight(20) + "Quantity".PadRight(20) + "\n");
                    foreach (KeyValuePair<string, List<VendingMachineItem>> kvp in inventory)
                    {
                        Console.WriteLine($"{kvp.Key.PadRight(20)} {kvp.Value[0].Name.PadRight(20)} {kvp.Value[0].Price.ToString().PadRight(20)} {kvp.Value.Count.ToString().PadRight(20)}");
                    }
                }

                else if (mainMenuResponse == "2")
                {
                    while (true)
                    {
                        Console.WriteLine($"-----------------\nPurchase Menu\n-----------------\n\n[1] Add to Balance\n[2] Make Purchase (Your current balance is ${vm.Balance})\n[3] End Transaction \n[4] Return to Main Menu\n");
                        string purchaseMenuResponse = Console.ReadLine();

                        if (purchaseMenuResponse == "2")
                        {
                            Console.WriteLine("Slot".PadRight(21) + "Name".PadRight(21) + "Cost".PadRight(20) + "Quantity".PadRight(20) + "\n");
                            foreach (KeyValuePair<string, List<VendingMachineItem>> kvp in inventory)
                            {
                                Console.WriteLine($"{kvp.Key.PadRight(20)} {kvp.Value[0].Name.PadRight(20)} {kvp.Value[0].Price.ToString().PadRight(20)} {kvp.Value.Count.ToString().PadRight(20)}");
                            }
                            Console.WriteLine("Please enter the slot ID of the item you'd like to purchase\n");
                            string responseSlotID = Console.ReadLine();         
                            if (responseSlotID ) // validate it exists (actual slot value) beins with a-d
                            {
                                if (vm.IsSoldOut(responseSlotID))
                                {
                                    if (vm.Balance >= inventory[responseSlotID][0].Price) // check to make sure balance is there
                                    {
                                        VendingMachineItem purchasedItem = vm.Purchase(responseSlotID);
                                        Console.WriteLine($"{purchasedItem.Name} purchased! {purchasedItem.Consume()}\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Insufficient Funds or sold out\n");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Sorry Sold Out");
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("Invalid slot ID");
                            } 
                        }
                        else if (purchaseMenuResponse == "1")
                        {

                            Console.WriteLine("How much would you like to add? (Accepts 1, 2, 5, and 10 dollar bills) \n");
                            decimal[] bills = { 1, 2, 5, 10 };
                            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                            vm.FeedMoney(depositAmount);
                            Console.WriteLine($"The current balance is now {vm.Balance}\n");
                        }
                        else if (purchaseMenuResponse == "3")
                        {
                            Change change = new Change();
                            Dictionary<string, int> returnedChange = change.MakeChange(vm.Balance);
                            Console.WriteLine($"Quarters: {returnedChange["Quarters"]} Dime: {returnedChange["Dimes"]} Nickels: {returnedChange["Nickels"]}");
                        }
                        else if (purchaseMenuResponse == "4")
                        {
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Uknown response");
                        }
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}

