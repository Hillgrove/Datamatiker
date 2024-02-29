public class RandomNumberGenerator
{
    private Random random;

    public RandomNumberGenerator()
    {
        random = new Random();
    }

    public int RandomNumber()
    {
        int number = random.Next(10, 25);
        return number;
    }
}