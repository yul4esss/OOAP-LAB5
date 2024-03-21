using System;

namespace Lab5_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WeaponFacade weapon = new WeaponFacade();

            // Using Facade to display program interface
            weapon.AddWeapons();

            weapon.ChooseAccessories();

            weapon.ShowReceipt();
        }
    }
}
