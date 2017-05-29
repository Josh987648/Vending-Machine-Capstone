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
                    Console.WriteLine("Slot     Name    Cost    Quantity");
                    foreach (KeyValuePair<string, List<VendingMachineItem>> kvp in inventory)
                    {
                        Console.WriteLine(kvp.Key + " " + kvp.Value[0].Name + " " + kvp.Value[0].Price + " " + kvp.Value.Count);
                    }
                }

                else if (mainMenuResponse == "2")
                {
                    while (true)
                    {
                        Console.WriteLine($"-----------------\nPurchase Menu\n-----------------\n\n[1] Select an item\n[2] Add to balance (Your current balance is ${vm.Balance})\n[3] Return to Main Menu\n");
                        string purchaseMenuResponse = Console.ReadLine();

                        if (purchaseMenuResponse == "1")
                        {
                            Console.WriteLine("Slot     Name    Cost    Quantity");
                            foreach (KeyValuePair<string, List<VendingMachineItem>> kvp in inventory)
                            {
                                Console.WriteLine(kvp.Key + " " + kvp.Value[0].Name + " " + kvp.Value[0].Price + " " + kvp.Value.Count);
                            }
                            Console.WriteLine("Please enter the slot ID of the item you'd like to purchase\n");
                            string responseSlotID = Console.ReadLine();
                            VendingMachineItem purchasedItem = vm.Purchase(responseSlotID);

                            if (vm.Balance >= purchasedItem.Price && vm.IsSoldOut(responseSlotID) == false)
                            {
                                Change change = new Change(vm.Balance, purchasedItem.Price);
                                change.MakeChange(vm.Balance, purchasedItem.Price);
                                string coinsToReturn = change.ReturnChange();
                                Console.WriteLine($"{purchasedItem.Name} purchased! {purchasedItem.Consume()}\n\n{coinsToReturn}\n");
                                vm.Purchase(responseSlotID);
                            }
                            else
                            {
                                Console.WriteLine("Insufficient Funds or sold out\n");
                            }
                        }

                        else if (purchaseMenuResponse == "2")
                        {

                            Console.WriteLine("How much would you like to add? (Accepts 1, 2, 5, and 10 dollar bills) \n");
                            decimal[] bills = { 1, 2, 5, 10 };
                            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                            vm.FeedMoney(depositAmount);
                            Console.WriteLine($"The current balance is now {vm.Balance}\n");
                        }

                        else if (purchaseMenuResponse == "3")
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

