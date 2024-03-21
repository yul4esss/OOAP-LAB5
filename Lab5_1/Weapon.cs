using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_1
{
    // Abstract class of weapons
    abstract class Weapon
    {
        String weapon_description = "Unknown weapon";
        public double WeaponRange {  get; set; }
        public double WeaponDamage { get; set; }
        public double WeaponWeight { get; set; }
        public double AllowedWeaponWeight { get; set; }
        public double YearOfManufacture { get; set; }

        public Dictionary<string, double> accessories = new Dictionary<string, double>();

        public void AddAccessory(string name, double cost)
        {
            accessories[name] = cost;
        }

        public String WeaponDescription { get { return weapon_description; } set { weapon_description = value; } }

        public virtual String GetWeaponDescription() { 
            return weapon_description;
        }

        // Counting weapon's cost
        public double TotalCost()
        {
            double total = CountWeaponCost();
            foreach (var accessory in accessories)
            {
                total += accessory.Value;
            }
            return total;
        }

        // Finding the most expensive weapon from list
        public static Weapon MostExpensive(List<Weapon> weapons)
        {
            Weapon mostExpensive = null;
            double maxCost = double.MinValue;
            foreach (var weapon in weapons)
            {
                double totalCost = weapon.TotalCost();
                if (totalCost > maxCost)
                {
                    mostExpensive = weapon;
                    maxCost = totalCost;
                }
            }
            return mostExpensive;
        }

        // Counting depreciation cost
        public virtual double DepreciatedCost(int currentYear)
        {
            double yearsOld = currentYear - YearOfManufacture;
            double depreciationRate = 0.05;
            double depreciation = yearsOld * depreciationRate * TotalCost();
            return TotalCost() - depreciation;
        }

        public virtual string GetWeaponDescriptionWithModifications()
        {
            return GetWeaponDescription();
        }

        public virtual double GetTotalCostWithModifications()
        {
            return CountWeaponCost();
        }

        public override string ToString()
        {
            return GetWeaponDescriptionWithModifications() + ": " + GetTotalCostWithModifications() + "$";
        }

        public abstract double CountWeaponCost();

        public abstract double GetWeaponWeight();

    }


    // Weapon classes
    class Rifle : Weapon
    {
        public Rifle()
        {
            WeaponDescription = "Type: Rifle";
            WeaponDamage = 100;
            WeaponRange = 3.4;
            AllowedWeaponWeight = 6.0;
            YearOfManufacture = 2015;
        }

        public override double CountWeaponCost()
        {
            return 500;
        }

        public override double GetWeaponWeight()
        {
            return 5.5;
        }
    }

    class Pistol : Weapon
    {
        public Pistol()
        {
            WeaponDescription = "Type: Pistol";
            WeaponDamage = 50;
            WeaponRange = 2.5;
            AllowedWeaponWeight = 3.2;
            YearOfManufacture = 2018;
        }

        public override double CountWeaponCost()
        {
            return 300;
        }

        public override double GetWeaponWeight()
        {
            return 2.8;
        }
    }

    class RifleAWP : Weapon
    {
        public RifleAWP()
        {
            WeaponDescription = "Type: Rifle AWP";
            WeaponDamage = 150;
            WeaponRange = 10;
            AllowedWeaponWeight = 10;
            YearOfManufacture = 2022;
        }

        public override double CountWeaponCost()
        {
            return 900;
        }

        public override double GetWeaponWeight()
        {
            return 8.5;
        }
    }
}
