using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_1
{
    abstract class WeaponDecorator : Weapon
    {
        public Weapon weapon;

        public abstract override string GetWeaponDescription();
        public abstract override double CountWeaponCost();


        public override string GetWeaponDescriptionWithModifications()
        {
            return weapon.GetWeaponDescriptionWithModifications() + " + " + GetWeaponDescription() + " Total price: " + CountWeaponCost();
        }

        public override double GetTotalCostWithModifications()
        {
            return weapon.GetTotalCostWithModifications() + CountWeaponCost();
        }
    }

    class Scope : WeaponDecorator
    {
        public Scope(Weapon weapon)
        {
            this.weapon = weapon;
        }

        public override string GetWeaponDescription()
        {
            return weapon.GetWeaponDescription() + " + Scope";
        }

        public override double CountWeaponCost()
        {
            return (weapon.CountWeaponCost() + 100);
        }

        public override double GetWeaponWeight()
        {
            return (weapon.GetWeaponWeight() + 0.2);
        }
    }

    class NightVision : WeaponDecorator
    {
        public NightVision(Weapon weapon)
        {
            this.weapon = weapon;
        }

        public override string GetWeaponDescription()
        {
            return weapon.GetWeaponDescription() + " + Night Vision";
        }

        public override double CountWeaponCost()
        {
            return (weapon.CountWeaponCost() + 300);
        }

        public override double GetWeaponWeight()
        {
            return (weapon.GetWeaponWeight() + 0.15);
        }
    }

    class Silenter : WeaponDecorator
    {
        public Silenter(Weapon weapon)
        {
            this.weapon = weapon;
        }

        public override string GetWeaponDescription()
        {
            return weapon.GetWeaponDescription() + " + Silenter";
        }

        public override double CountWeaponCost()
        {
            return (weapon.CountWeaponCost() + 150);
        }

        public override double GetWeaponWeight()
        {
            return (weapon.GetWeaponWeight() + 0.1);
        }
    }
}

