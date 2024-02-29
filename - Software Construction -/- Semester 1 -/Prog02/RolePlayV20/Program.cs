
NumberGenerator theNumberGenerator = new NumberGenerator();
BattleLog theLog = new BattleLog();

Hero theHero = new Hero(5, 30, theNumberGenerator, theLog);
Beast theBeast = new Beast(theNumberGenerator, theLog);

// Now battle...How do we do that (Hint: You need a loop)
while (!theHero.Dead && !theBeast.Dead)
{
    int damage = theHero.DealDamage();
    theBeast.ReceiveDamage(damage);

    if (!theBeast.Dead)
    {
        damage = theBeast.DealDamage();
        theHero.ReceiveDamage(damage);
    }
}

theLog.PrintLog();
