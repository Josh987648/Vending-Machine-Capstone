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
                bool firstResponse = false;

                while (firstResponse == false)
                {
                    if (mainMenuResponse != "1" || mainMenuResponse != "2")
                    {
                        Console.WriteLine("Error: Invalid Response.  Please enter either 1 or 2");
                    }
                    else if (mainMenuResponse == "1")
                    {
                        firstResponse = true;
                        Console.WriteLine("Slot".PadRight(21) + "Name".PadRight(21) + "Cost".PadRight(20) + "Quantity".PadRight(20) + "\n");
                        foreach (KeyValuePair<string, List<VendingMachineItem>> kvp in inventory)
                        {
                            Console.WriteLine($"{kvp.Key.PadRight(20)} {kvp.Value[0].Name.PadRight(20)} {kvp.Value[0].Price.ToString().PadRight(20)} {kvp.Value.Count.ToString().PadRight(20)}");
                        }
                    }
                    else if (mainMenuResponse == "2")
                    {
                        firstResponse = true;
                        bool secondResponse = false;

                        while (secondResponse == false)
                        {
                            while (true)
                            {
                                Console.WriteLine($"-----------------\nPurchase Menu\n-----------------\n\n[1] Add to Balance\n[2] Make Purchase (Your current balance is ${vm.Balance})\n[3] End Transaction \n[4] Return to Main Menu\n");
                                string purchaseMenuResponse = Console.ReadLine();

                                if (purchaseMenuResponse != "1" || purchaseMenuResponse != "2" || purchaseMenuResponse != "3" || purchaseMenuResponse != "4")
                                {
                                    Console.WriteLine("Error: Invalid Response.  Please enter either 1, 2, 3, or 4.");
                                }
                                else if (purchaseMenuResponse == "2")
                                {
                                    secondResponse = true;
                                    Console.WriteLine("Slot".PadRight(21) + "Name".PadRight(21) + "Cost".PadRight(20) + "Quantity".PadRight(20) + "\n");
                                    foreach (KeyValuePair<string, List<VendingMachineItem>> kvp in inventory)
                                    {
                                        Console.WriteLine($"{kvp.Key.PadRight(20)} {kvp.Value[0].Name.PadRight(20)} {kvp.Value[0].Price.ToString().PadRight(20)} {kvp.Value.Count.ToString().PadRight(20)}");
                                    }
                                    Console.WriteLine("Please enter the slot ID of the item you'd like to purchase\n");
                                    string responseSlotID = Console.ReadLine();
                                    bool correctSlotStart = false;
                                    bool correctSlotEnd = false;
                                    while (correctSlotStart == false && correctSlotEnd == false)
                                    {
                                        if (!responseSlotID.StartsWith("A") || !responseSlotID.StartsWith("B") || !responseSlotID.StartsWith("C") || !responseSlotID.StartsWith("D"))
                                        {
                                            Console.WriteLine("Error: Invalid Response.  Please enter a valid Slot ID.");
                                        }
                                        else if (!responseSlotID.EndsWith("1") || !responseSlotID.EndsWith("2") || !responseSlotID.EndsWith("3") || !responseSlotID.EndsWith("4"))
                                        {
                                            Console.WriteLine("Error: Invalid Response.  Please enter a valid Slot ID.");
                                        }
                                        else
                                        {
                                            correctSlotStart = true;
                                            correctSlotEnd = true;
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
                                    }
                                }
                                else if (purchaseMenuResponse == "1")
                                {
                                    secondResponse = true;
                                    Console.WriteLine("How much would you like to add? (Accepts 1, 2, 5, and 10 dollar bills) \n");
                                    string userDeposit = Console.ReadLine();
                                    decimal[] bills = { 1, 2, 5, 10 };
                                    bool validDeposit = false;
                                    while (validDeposit == false)
                                    {
                                        if (userDeposit != "1" || userDeposit != "2" || userDeposit != "5" || userDeposit != "10")
                                        {
                                            Console.WriteLine("Error: Unknown Amount.  Please add either a 1, 2, 5, or 10 dollar bill.");
                                        }
                                        else
                                        {
                                            validDeposit = true;
                                            decimal depositAmount = Convert.ToDecimal(userDeposit);
                                            vm.FeedMoney(depositAmount);
                                            Console.WriteLine($"The current balance is now {vm.Balance}\n");
                                        }
                                    }
                                }
                                else if (purchaseMenuResponse == "3")
                                {
                                    secondResponse = true;
                                    Change change = new Change();
                                    Dictionary<string, int> returnedChange = change.MakeChange(vm.Balance);
                                    Console.WriteLine($"Quarters: {returnedChange["Quarters"]} Dime: {returnedChange["Dimes"]} Nickels: {returnedChange["Nickels"]}");
                                }
                                else if (purchaseMenuResponse == "4")
                                {
                                    secondResponse = true;
                                    break;
                                }
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

