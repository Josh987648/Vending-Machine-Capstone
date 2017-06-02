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
        VendingMachineFileReader vmfr = new VendingMachineFileReader();
        VendingMachineFileWriter vmfw = new VendingMachineFileWriter();
        Dictionary<string, List<VendingMachineItem>> inventory;

        public void Display()
        {
            string targetPath = Directory.GetCurrentDirectory();
            string fileName = "vendingmachine.csv";
            string fullPath = Path.Combine(targetPath, fileName);
            inventory = vmfr.ReadInventory(fullPath);
            VendingMachine vm = new VendingMachine(inventory);

            Console.WriteLine("*****************\nVendo-Matic 500\n*****************");

            while (true)
            {

                bool firstResponse = false;
                while (firstResponse == false)
                {
                    Console.WriteLine("-----------------\nMain Menu\n-----------------\n[1] Display Vending Machine Inventory\n[2] Purchase an Item\n[3] Quit\n");
                    string mainMenuResponse = Console.ReadLine();
                    if (mainMenuResponse != "1" && mainMenuResponse != "2" && mainMenuResponse != "3")
                    {
                        Console.WriteLine("Error: Invalid Response.  Please enter either 1 or 2");

                    }
                    else if (mainMenuResponse == "1")
                    {
                        firstResponse = true;
                        DisplayInventory();
                    }
                    else if (mainMenuResponse == "2")
                    {
                        firstResponse = true;
                        DisplayPurchaseMenu(vm);

                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }

        private void DisplayInventory()
        {
            Console.WriteLine("Slot".PadRight(21) + "Name".PadRight(21) + "Cost".PadRight(20) + "Quantity".PadRight(20) + "\n");
            foreach (KeyValuePair<string, List<VendingMachineItem>> kvp in inventory)
            {
                Console.WriteLine($"{kvp.Key.PadRight(20)} {kvp.Value[0].Name.PadRight(20)} {kvp.Value[0].Price.ToString().PadRight(20)} {kvp.Value.Count.ToString().PadRight(20)}");
            }
        }

        private void DisplayPurchaseMenu(VendingMachine vm)
        {
            while (true)
            {
                Console.WriteLine("-----------------\nPurchase Menu\n-----------------"); ;
                Console.WriteLine();
                Console.WriteLine("[1] Add to Balance");
                Console.WriteLine($"[2] Make Purchase (Your current balance is {vm.Balance.ToString("C")})");
                Console.WriteLine("[3] End Transaction");
                Console.WriteLine("[4] Return to Main Menu");

                string purchaseMenuResponse = Console.ReadLine();

                if (purchaseMenuResponse == "2")
                {
                    DisplayInventory();
                    DisplayPurchasePrompt(vm);
                }
                else if (purchaseMenuResponse == "1")
                {
                    DisplayDepositPrompt(vm);
                }
                else if (purchaseMenuResponse == "3")
                {
                    Change change = vm.EndTransaction();
                    Console.WriteLine($"{change.NumQuarters} quarters");
                    Console.WriteLine($"{change.NumDimes} dimes");
                    Console.WriteLine($"{change.NumNickels} nickels");
                  
                }
                else if (purchaseMenuResponse == "4")
                {                    
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Invalid Response.  Please enter either 1, 2, 3, or 4.");
                }                
            }
        }

        private void DisplayDepositPrompt(VendingMachine vm)
        {
            while (true)
            {
                Console.WriteLine("How much would you like to add? (Accepts 1, 2, 5, and 10 dollar bills) \n");
                string userDeposit = Console.ReadLine();
                string[] bills = { "1", "2", "5", "10" };
                if (!bills.Contains(userDeposit))
                {
                    Console.WriteLine("Error: Unknown Amount.  Please add either a 1, 2, 5, or 10 dollar bill.");
                }
                else
                {
                    decimal depositAmount = Convert.ToDecimal(userDeposit);
                    vm.FeedMoney(depositAmount);

                    Console.WriteLine($"The current balance is now {vm.Balance.ToString("C")}\n");                    
                    vmfw.LogMessage(($"{DateTime.Now}Money Fed {depositAmount.ToString("C")}, BALANCE: {vm.Balance.ToString("C")}"));

                    break;
                }
            }
        }

        private void DisplayPurchasePrompt(VendingMachine vm)
        {
            while (true)
            {
                Console.WriteLine("Please enter the slot ID of the item you'd like to purchase\n");
                string responseSlotID = Console.ReadLine().ToUpper();

                if (!vm.IsValidSlot(responseSlotID))
                {
                    Console.WriteLine("Error: Invalid Response.  Please enter a valid Slot ID.");
                }
                else
                {
                    if (vm.IsSoldOut(responseSlotID) == false)
                    {
                        if (vm.DoesHaveEnoughMoney(responseSlotID))
                        {
                            VendingMachineItem purchasedItem = vm.Purchase(responseSlotID);
                            Console.WriteLine($"{purchasedItem.Name} purchased! {purchasedItem.Consume()}\n");
                            // stuff log
                            vmfw.LogMessage(($"{DateTime.Now}Purchase Cost {purchasedItem.Price.ToString("C")}, BALANCE: {vm.Balance}"));
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

    }
}


