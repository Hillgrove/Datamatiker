﻿
public class WeaponTester
{
    public void Run()
    {
        Console.WriteLine("Running Axe Test...");
        TestAxe();

        Console.WriteLine();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine();

        Console.WriteLine("Running Wand Test...");
        TestWand();
    }

    private void TestWand()
    {
        Wand myWand = new Wand("Dragonhair");
        UseWeapon(myWand, 5);

        myWand.IsEnchanted = true;
        Console.WriteLine("Enchanted Wand...");
        UseWeapon(myWand, 5);

        myWand.IsEnchanted = false;
        Console.WriteLine("Disenchanted Wand...");
        UseWeapon(myWand, 5);
    }

    private void TestAxe()
    {
        Axe myAxe = new Axe("Redeemer");
        UseWeapon(myAxe, 10);

        myAxe.Sharpen();
        Console.WriteLine("Sharpened Axe...");
        UseWeapon(myAxe, 10);
    }

    private void UseWeapon(Weapon weapon, int noOfUses)
    {
        Console.WriteLine($"Testing {weapon.Description}");
        for (int i = 0; i < noOfUses; i++)
        {
            Console.WriteLine($"Damage dealt by {weapon.Description}: {weapon.DealDamage()}");
        }
        Console.WriteLine();
    }
}