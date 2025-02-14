
using System.ComponentModel;

NumberGenerator generator = new NumberGenerator();
BattleLog log = new BattleLog();

// Battle logic (1-on-1)
#region 1-on-1 battle logic
//Hero theHero = new Hero(generator, log, "Olafur", 100, 10, 30);
//Beast theBeast = new Beast(generator, log, "Zakhial", 90, 10, 25);

//while (!theHero.Dead && !theBeast.Dead)
//{
//    int damageByHero = theHero.DealDamage();
//    theBeast.ReceiveDamage(damageByHero);

//    if (!theBeast.Dead)
//    {
//        int damageByBeast = theBeast.DealDamage();
//        theHero.ReceiveDamage(damageByBeast);
//    }
//}

//log.PrintLog();
//Console.WriteLine();
//if (theBeast.Dead)
//{
//    Console.WriteLine($"The Hero {theHero.Name} was Victorious!!");
//}
//else
//{
//    Console.WriteLine($"The Beast {theBeast.Name} won... ;-(");
//}

//Console.WriteLine();
//log.Reset();
#endregion


// New battle logic (1-on-many)
#region 1-on-many battle logic
//Hero _theHero     = new  Hero(generator, log, "Thor",      250, 15, 50);
//Beast beastOne   = new Beast(generator, log, "Arkenthorn", 30, 10, 20);
//Beast beastTwo   = new Beast(generator, log, "Brimstail",  30, 10, 20);
//Beast beastThree = new Beast(generator, log, "Craghorn",   30, 10, 20);
//Beast beastFour  = new Beast(generator, log, "Duskfang",   30, 10, 20);
//Beast beastFive  = new Beast(generator, log, "Emberclaw",  30, 10, 20);
//BeastArmy beastArmy = new BeastArmy();
//beastArmy.AddBeast(beastOne);
//beastArmy.AddBeast(beastTwo);
//beastArmy.AddBeast(beastThree);
//beastArmy.AddBeast(beastFour);
//beastArmy.AddBeast(beastFive);


//// TODO - implement 1-on-many battle logic
//while (!_theHero.Dead && !beastArmy.Dead)
//{
//    int heroDamage = _theHero.DealDamage();
//    beastArmy.ReceiveDamage(heroDamage);
     
//    if (!beastArmy.Dead)
//    {
//        int beastDamage = beastArmy.DealDamage();
//        _theHero.ReceiveDamage(beastDamage);
//    }
//}
//log.PrintLog(); 
//Console.WriteLine();

//if (beastArmy.Dead)
//{
//    Console.WriteLine($"The Hero {_theHero.Name} was Victorious!!");
//}
//else
//{
//    Console.WriteLine($"The beast army won... ;-(");
//}

#endregion

// New battle logic (1-on-many for X rounds)
#region 1-on-many battle logic
Hero theHero =     new Hero(generator,  log, "Thor",      250, 15, 50);
Beast beastOne =   new Beast(generator, log, "Arkenthorn", 30, 10, 20);
Beast beastTwo =   new Beast(generator, log, "Brimstail",  30, 10, 20);
Beast beastThree = new Beast(generator, log, "Craghorn",   30, 10, 20);
Beast beastFour =  new Beast(generator, log, "Duskfang",   30, 10, 20);
Beast beastFive =  new Beast(generator, log, "Emberclaw",  30, 10, 20);

BeastArmy beastArmy = new BeastArmy();
beastArmy.AddBeast(beastOne);
beastArmy.AddBeast(beastTwo);
beastArmy.AddBeast(beastThree);
beastArmy.AddBeast(beastFour);
beastArmy.AddBeast(beastFive);

Battle battle = new Battle(theHero, beastArmy);

int rounds = 1000;
battle.Start(rounds);

int heroWins = battle.HeroWins;
int beastWins = battle.BeastsWins;

Console.WriteLine($"Statistics after {rounds} rounds of combat.\n" +
                  $"Our hero won {heroWins} ({(double)heroWins / rounds * 100:F1}%) times\n" +
                  $"The beasts won {beastWins} ({(double)beastWins / rounds * 100:F1}%) times");
#endregion