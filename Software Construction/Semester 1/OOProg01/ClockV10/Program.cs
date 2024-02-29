
Clock clock = new Clock();

clock.setTime(23, 59);

Console.WriteLine(clock.GetTime());

clock.AdvanceTime();

Console.WriteLine(clock.GetTime());