using System;
using System.Collections.Generic;
using System.Net;

namespace Lab5_1
{
    internal class WeaponFacade
    {
        private List<Weapon> arsenal = new List<Weapon>();

        public void AddWeapons()
        {
            bool flag = true;
            while (flag)
            {
                ChooseWeapon();
                Console.WriteLine("Do you want to add more weapons? (Yes/No)");
                string response = Console.ReadLine();
                if (response.ToLower() != "yes")
                {
                    flag = false;
                }
            }
        }

        public void ChooseWeapon()
        {
            Console.Clear();
            Console.WriteLine("Choose weapon that you want to add");
            Console.WriteLine("1 - Rifle \n2 - Pistol \n3 - Rifle AWP");

            int userChoice = Convert.ToInt32(Console.ReadLine());

            switch (userChoice)
            {
                case 1: { arsenal.Add(new Rifle()); break; }
                case 2: { arsenal.Add(new Pistol()); break; }
                case 3: { arsenal.Add(new RifleAWP()); break; }
                default: break;
            }
        }

        public void ChooseAccessories()
        {
            if (arsenal.Count > 0)
            {
                foreach (var weapon in arsenal)
                {
                    bool flag = true;
                    while (flag)
                    {
                        Console.Clear();
                        Console.WriteLine($"Choose accessory for {weapon.GetWeaponDescription()}: ");
                        Console.WriteLine("1 - Scope \n2 - Night Vision \n3 - Silencer \nElse - No accessory");

                        int userChoice = Convert.ToInt32(Console.ReadLine());

                        switch (userChoice)
                        {
                            case 1: { weapon.AddAccessory("Scope", 100); break; }
                            case 2: { weapon.AddAccessory("Night Vision", 300); break; }
                            case 3: { weapon.AddAccessory("Silencer", 150); break; }
                            default: { flag = false; break; }
                        }
                    }
                }
            }
        }

        public void ShowReceipt()
        {
            if (arsenal.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("Your arsenal: ");
                foreach (var weapon in arsenal)
                {
                    Console.WriteLine($"{weapon.GetWeaponDescription()} {weapon.GetTotalCostWithModifications()}$ with modifications:");
                    foreach (var accessory in weapon.accessories)
                    {
                        Console.WriteLine($"- {accessory.Key}: {accessory.Value}$");
                    }
                    Console.WriteLine($"Total cost: {weapon.TotalCost()}$");
                    if (weapon.GetWeaponWeight() > weapon.AllowedWeaponWeight)
                    {
                        Console.WriteLine("Maximum weight exceeded for " + weapon.GetWeaponDescription());
                    }
                }
                Console.WriteLine("Most expensive weapon in the arsenal:");
                Weapon mostExpensive = Weapon.MostExpensive(arsenal);
                if (mostExpensive != null)
                {
                    Console.WriteLine(mostExpensive.GetWeaponDescriptionWithModifications() + " " + mostExpensive.TotalCost() + "$");
                    Console.WriteLine("Depreciated cost: " + mostExpensive.DepreciatedCost(DateTime.Now.Year));
                }
                else
                {
                    Console.WriteLine("No weapons in the arsenal.");
                }
                Console.WriteLine("Thanks for the purchase");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Next time! Bye!");
            }
        }
    }
}
