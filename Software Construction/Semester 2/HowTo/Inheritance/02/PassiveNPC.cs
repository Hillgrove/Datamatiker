
public class PassiveNPC : NPC02
{
    private int _chanceToTalk;

    public PassiveNPC(string name, int lifePoints, List<string> lines, int chanceToTalk)
        : base(name, lifePoints, 0, lines)
    {
        _chanceToTalk = chanceToTalk;
    }

    public override string Talk()
    {
        int percent = GetRandomNumber(0, 100);
        if (percent < _chanceToTalk)
            return base.Talk();
        else
            return "";
    }
}
