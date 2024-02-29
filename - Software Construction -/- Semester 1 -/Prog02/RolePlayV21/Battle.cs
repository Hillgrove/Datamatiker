class Battle
{
    private Hero _hero;
    private BeastArmy _beastArmy;
    
    public Battle(Hero hero, BeastArmy beastArmy)
    {
        HeroWins = 0;
        BeastsWins = 0;
        _hero = hero;
        _beastArmy = beastArmy;
    }

    public int HeroWins { get; private set; }
    public int BeastsWins { get; private set; }

    public void Start(int rounds)
    {
        for (int i = 0; i < rounds; i++)
        {
            Console.WriteLine($"Round: {i + 1}");
            string winner = Logic();
            
            _beastArmy.Reset();
            _hero.Reset();

            Console.WriteLine($"Results: {winner}");
            Console.WriteLine();
        }
    }

    public string Logic()
    {
        while (!_hero.Dead && !_beastArmy.Dead)
        {
            int heroDamage = _hero.DealDamage();
            _beastArmy.ReceiveDamage(heroDamage);

            if (!_beastArmy.Dead)
            {
                int beastDamage = _beastArmy.DealDamage();
                _hero.ReceiveDamage(beastDamage);
            }
        }

        if (_hero.Dead) { BeastsWins++; return "Beasts win."; }
        else { HeroWins++; return "Hero wins!";  }
    }
}

