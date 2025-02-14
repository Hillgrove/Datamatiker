Sword excalibur = new Sword("Excalibur", 15, 60);
Sword sting = new Sword("Sting", 12, 50);

Warrior warriorA = new Warrior("Ragnar", 200, 1.2, excalibur);
Warrior warriorB = new Warrior("Lagertha", 240, 2.5, sting);

Console.WriteLine("Just after creation:");
Console.WriteLine(warriorA.GetInfo());
Console.WriteLine(warriorB.GetInfo());
Console.WriteLine();

int damageFromA = warriorA.DealDamage();
int damageFromB = warriorB.DealDamage();
warriorA.ReceiveDamage(damageFromB);
warriorB.ReceiveDamage(damageFromA);

Console.WriteLine("After damage:");
Console.WriteLine(warriorA.GetInfo());
Console.WriteLine(warriorB.GetInfo());
Console.WriteLine();

Sword omegaSword = new Sword("OMEGADAMAGE", 100, 250);

warriorA.changeSword(omegaSword);
warriorB.changeSword(excalibur, excalibur);

damageFromA = warriorA.DealDamage();
damageFromB = warriorB.DealDamage();
warriorA.ReceiveDamage(damageFromB);
warriorB.ReceiveDamage(damageFromA);

Console.WriteLine("After changing swords:");
Console.WriteLine(warriorA.GetInfo());
Console.WriteLine(warriorB.GetInfo());
Console.WriteLine();