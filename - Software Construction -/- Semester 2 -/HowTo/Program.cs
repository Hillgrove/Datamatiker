
// To ensure console output writes proper Ø's and not O's.
Console.OutputEncoding = System.Text.Encoding.UTF8;

#region Person.01
Person01 person01 = new Person01();
#endregion

#region Person.02
Person02 person02 = new Person02();
person02.Name = "Peter";

Console.WriteLine("Exercise Person.02:");
Console.WriteLine("============================");
Console.WriteLine(person02.Name);
Console.WriteLine();
Console.WriteLine();
#endregion

#region Person.03
Person03 person03 = new Person03();
//person03.Name = "Peter";

Console.WriteLine("Exercise Person.03:");
Console.WriteLine("============================");
Console.WriteLine(person03.Name);
Console.WriteLine();
Console.WriteLine();
#endregion

#region Person.04
Person04 person04_1 = new Person04("Peter");
Person04 person04_2 = new Person04("Lars");

Console.WriteLine("Exercise Person.04:");
Console.WriteLine("============================");
Console.WriteLine($"Navn 1: {person04_1.Name}");
Console.WriteLine($"Navn 2: {person04_2.Name}");
Console.WriteLine();
Console.WriteLine();
#endregion

#region Person.05
Person05 person05 = new Person05("Peter", 1.8, 75);

Console.WriteLine("Exercise Person.05:");
Console.WriteLine("============================");
Console.WriteLine($"Navn: {person05.Name}");
Console.WriteLine($"Højde i meter: {person05.Height}");
Console.WriteLine($"Vægt i kg: {person05.Weight}");
Console.WriteLine();
Console.WriteLine();

person05.Height = 2.3;
person05.Weight = 100;

Console.WriteLine($"Navn: {person05.Name}");
Console.WriteLine($"Højde i meter: {person05.Height}");
Console.WriteLine($"Vægt i kg: {person05.Weight}");
Console.WriteLine();
Console.WriteLine();
#endregion

#region Person.06
Person06 person06 = new Person06("Peter", 1.8, 75);

Console.WriteLine("Exercise Person.06:");
Console.WriteLine("============================");
Console.WriteLine($"Navn: {person06.Name}");
Console.WriteLine($"Højde i meter: {person06.Height}");
Console.WriteLine($"Vægt i kg: {person06.Weight}");
Console.WriteLine($"BMI: {person06.BMI:F2}");
Console.WriteLine();
Console.WriteLine();
#endregion

#region Person.07
Person07 person07 = new Person07("Peter", 1.8, 75);

Console.WriteLine("Exercise Person.07:");
Console.WriteLine("============================");
Console.WriteLine($"Navn: {person07.Name}");
Console.WriteLine($"Højde i meter: {person07.Height}");
Console.WriteLine($"Vægt i kg: {person07.Weight}");
Console.WriteLine($"BMI: {person07.BMI:F2}");
Console.WriteLine($"Undervægtig: {person07.Underweight}");
Console.WriteLine();
Console.WriteLine();

person07.Height = 2.3;
person07.Weight = 50;

Console.WriteLine("med ændret data:");
Console.WriteLine($"Højde i meter: {person07.Height}");
Console.WriteLine($"Vægt i kg: {person07.Weight}");
Console.WriteLine($"BMI: {person07.BMI:F2}");
Console.WriteLine($"Undervægtig: {person07.Underweight}");
Console.WriteLine();
Console.WriteLine();
#endregion

#region Person.08
Person08 person08 = new Person08("Peter", 1.8, 75);

Console.WriteLine("Exercise Person.08:");
Console.WriteLine("============================");
Console.WriteLine($"Navn: {person08.Name}");
Console.WriteLine($"Højde i meter: {person08.Height}");
Console.WriteLine($"Vægt i kg: {person08.Weight}");
Console.WriteLine($"BMI: {person08.BMI:F2}");
Console.WriteLine($"Undervægtig (under 20): {person08.IsUnderweight(20)}");
Console.WriteLine();
Console.WriteLine();
#endregion

#region Person.09
Person09 person09 = new Person09("Peter", 1.8, 75);

Console.WriteLine("Exercise Person.09:");
Console.WriteLine("============================");
person09.PrintPersonData();
Console.WriteLine();
Console.WriteLine();
#endregion

#region Person.10
Person10 person10 = new Person10("Peter", 1.8, 75);

Console.WriteLine("Exercise Person.10:");
Console.WriteLine("============================");
Console.WriteLine(person10.PersonDataAsString());
Console.WriteLine();
Console.WriteLine();
#endregion

#region Person.11
Person11 person11 = new Person11("Peter", 1.8, 75);

Console.WriteLine("Exercise Person.11:");
Console.WriteLine("============================");
Console.WriteLine(person11.PersonDataAsString());
Console.WriteLine();
Console.WriteLine();
#endregion

#region Player.01
Player01 player01 = new Player01("Salah");

Console.WriteLine("Exercise Player.01:");
Console.WriteLine("============================");
Console.WriteLine($"Player name: {player01.Name}");
Console.WriteLine();
Console.WriteLine();
#endregion

#region Player.02
Player02 player0201 = new Player02("Salah", 120);
Player02 player0202 = new Player02("Eddin");

Console.WriteLine("Exercise Player.02:");
Console.WriteLine("============================");
Console.WriteLine($"{player0201.Name} : {player0201.LifePoints}");
Console.WriteLine($"{player0202.Name} : {player0202.LifePoints}");

player0202.LifePoints += 10;

Console.WriteLine($"{player0202.Name} : {player0202.LifePoints}");
Console.WriteLine();
Console.WriteLine();
#endregion

#region Player.03
Player03 player03 = new Player03("Salah");
player03.LowerLifePoints(50);
player03.RaiseLifePoints(100);
#endregion

#region Player.04
Player04 player04 = new Player04("Salah");

Console.WriteLine("Exercise Player.04:");
Console.WriteLine("============================");
Console.WriteLine($"{player04.Name} : {player04.LifePoints}");

player04.RaiseLifePoints(-100);
player04.LowerLifePoints(-123);

Console.WriteLine($"{player04.Name} : {player04.LifePoints}");
Console.WriteLine();
Console.WriteLine();
#endregion

#region Player.05
Player05 player05 = new Player05("Salah");

Console.WriteLine("Exercise Player.05:");
Console.WriteLine("============================");
Console.WriteLine($"Er {player05.Name} død? {player05.IsDead}");

player05.LowerLifePoints(120);

Console.WriteLine($"Er {player05.Name} død? {player05.IsDead}");
Console.WriteLine();
Console.WriteLine();
#endregion

#region Player.06
Player06 player06 = new Player06("Lars");

Console.WriteLine("Exercise Player.06:");
Console.WriteLine("============================");
Console.WriteLine($"Damage dealt by {player06.Name} : {player06.DealDamage()}");
Console.WriteLine();
Console.WriteLine();
#endregion

#region Player.07
Player07 player07 = new Player07("Lars");

Console.WriteLine("Exercise Player.07:");
Console.WriteLine("============================");
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Damage dealt by {player07.Name} : {player07.DealDamage()}");
}

Console.WriteLine();
Console.WriteLine();
#endregion

#region Player.08
Player08 player08 = new Player08("Lars");

int numberOfLoops = 1000000;
int totalDamage = 0;
double averageDamage = 0;

for (int loop = 0; loop < numberOfLoops; loop++)
{
    totalDamage += player08.DealDamage();
}

averageDamage = (double)totalDamage / numberOfLoops;

Console.WriteLine("Exercise Player.08:");
Console.WriteLine("============================");
Console.WriteLine($"The average damge is : {averageDamage:F2}");
Console.WriteLine();
Console.WriteLine();
#endregion

#region Player.09
Player09 player09 = new Player09("lars", 100);

Console.WriteLine("Exercise Player.09:");
Console.WriteLine("============================");

for (int rounds = 1; rounds < 6; rounds++)
{
    int damage = player09.DealDamage();
    Console.WriteLine($"Round {rounds}: Damage dealt: {damage}");
}

Console.WriteLine();
Console.WriteLine();
#endregion

#region Player.10
Sword sword1001 = new Sword();
Sword sword1002 = new Sword(100, 250);
Player10 player1001 = new Player10("lars", 100, sword1001);
Player10 player1002 = new Player10("Bent", 100, sword1002 );

Console.WriteLine("Exercise Player.10:");
Console.WriteLine("============================");

for (int rounds = 1; rounds < 6; rounds++)
{
    int damage = player1001.DealDamage();
    Console.WriteLine($"Round {rounds}. {player1001.Name} dealt {damage} damage.");
}

Console.WriteLine();

for (int rounds = 1; rounds < 6; rounds++)
{
    int damage = player1002.DealDamage();
    Console.WriteLine($"Round {rounds}. {player1002.Name} dealt {damage} damage.");
}

Console.WriteLine();
Console.WriteLine();
#endregion

#region Player.11
Console.WriteLine("Exercise Player.11:");
Console.WriteLine("============================");
Sword sword11 = new Sword(100, 250);
Player11 player11 = new Player11("Lars", 100, sword11);
DamageTester damageTester = new DamageTester();
damageTester.TestPlayerDamage(player11, 100000);

Console.WriteLine();
Console.WriteLine();
#endregion

#region Collection.01
List<int> collection01 = new List<int>();
collection01.Add(17);
collection01.Add(42);
collection01.Add(30);

Console.WriteLine("Exercise Collection.01:");
Console.WriteLine("============================");

for (int i = 0; i < collection01.Count; i++)
{
    Console.WriteLine($"Element {i}: {collection01[i]}");
}

Console.WriteLine();
Console.WriteLine();
#endregion

#region Collection.02
Console.WriteLine("Exercise Collection.02:");
Console.WriteLine("============================");
Console.WriteLine("Already did this step in previous task");
Console.WriteLine();
Console.WriteLine();
#endregion

#region Collection.03
List<int> collection03 = new List<int>();
collection03.Add(17);
collection03.Add(42);
collection03.Add(30);
collection03.RemoveAt(1);

Console.WriteLine("Exercise Collection.03:");
Console.WriteLine("============================");

for (int i = 0; i < collection03.Count; i++)
{
    Console.WriteLine($"Element {i}: {collection03[i]}");
}

Console.WriteLine();
Console.WriteLine();
#endregion

#region Collection.04
List<int> collection04 = new List<int>();
collection04.Add(17);
collection04.Add(42);
collection04.Add(30);

Console.WriteLine("Exercise Collection.04:");
Console.WriteLine("============================");

foreach (var value in collection04)
{
    Console.WriteLine(value);
}

Console.WriteLine();
Console.WriteLine();
#endregion

#region Collection.05
List<Company> companies05 = new List<Company>();
companies05.Add(new Company(123, "ABC", 7));
companies05.Add(new Company(456, "DEF", 9));
companies05.Add(new Company(789, "GHI", 13));

Console.WriteLine("Exercise Collection.05:");
Console.WriteLine("============================");

foreach (var company in companies05)
{
    Console.WriteLine(company);
}

Console.WriteLine();
Console.WriteLine();
#endregion

#region Collection.06
List<Company> companies06 = new List<Company>();
companies06.Add(new Company(123, "ABC", 7));
companies06.Add(new Company(456, "DEF", 9));
companies06.Add(new Company(789, "GHI", 13));
CollectionMethods06 collMethods06 = new CollectionMethods06();
Company? test0601 = collMethods06.FindCompanyFromCVR(123, companies06);
Company? test0602 = collMethods06.FindCompanyFromCVR(234, companies06);

Console.WriteLine("Exercise Collection.06:");
Console.WriteLine("============================");
Console.WriteLine($"Company found: {test0601}");
Console.WriteLine($"Company found: {test0602}");
Console.WriteLine();
Console.WriteLine();
#endregion

#region Collection.07
List<Company> companies07 = new List<Company>();
companies07.Add(new Company(123, "ABC", 7));
companies07.Add(new Company(456, "DEF", 9));
companies07.Add(new Company(789, "GHI", 13));
CollectionMethods07 collMethods07 = new CollectionMethods07();
List<Company> test0701 = collMethods07.FindCompaniesByEmployees(5, companies07);
List<Company> test0702 = collMethods07.FindCompaniesByEmployees(13, companies07);
List<Company> test0703 = collMethods07.FindCompaniesByEmployees(21, companies07);

Console.WriteLine("Exercise Collection.07:");
Console.WriteLine("============================");
Console.WriteLine("Companies with 5 or more employees");

foreach (Company company in test0701)
{
    Console.WriteLine(company);
}

Console.WriteLine();

Console.WriteLine("Companies with 13 or more employees");
foreach (Company company in test0702)
{
    Console.WriteLine(company);
}

Console.WriteLine();

Console.WriteLine("Companies with 21 or more employees");
foreach (Company company in test0703)
{
    Console.WriteLine(company);
}

Console.WriteLine();
Console.WriteLine();
#endregion

#region Collection.08
int correctCVR08 = 123;
int falseCVR08 = 124;

Dictionary<int, Company> companies08 = new Dictionary<int, Company>();
Company c81 = new Company(123, "ABC", 7);
Company c82 = new Company(456, "DEF", 9);
Company c83 = new Company(789, "GHI", 13);
companies08.Add(c81.CVRNo, c81);
companies08.Add(c82.CVRNo, c82);
companies08.Add(c83.CVRNo, c83);
CollectionMethods08 collMethods08 = new CollectionMethods08();

Company? test0801 = collMethods08.FindCompanyFromCVR(correctCVR08, companies08);
Company? test0802 = collMethods08.FindCompanyFromCVR(falseCVR08, companies08);

List<Company> test0803 = collMethods08.FindCompaniesByEmployees(5, companies08);
List<Company> test0804 = collMethods08.FindCompaniesByEmployees(13, companies08);
List<Company> test0805 = collMethods08.FindCompaniesByEmployees(21, companies08);

Console.WriteLine("Exercise Collection.08:");
Console.WriteLine("============================");
Console.WriteLine($"Company with CVR {correctCVR08} is : {test0801}");
Console.WriteLine($"Company with CVR {falseCVR08} is : {test0802}");

Console.WriteLine();

Console.WriteLine("Companies with 5 or more employees");
foreach (Company company in test0803)
{
    Console.WriteLine(company);
}

Console.WriteLine();

Console.WriteLine("Companies with 13 or more employees");
foreach (Company company in test0804)
{
    Console.WriteLine(company);
}

Console.WriteLine();

Console.WriteLine("Companies with 21 or more employees");
foreach (Company company in test0805)
{
    Console.WriteLine(company);
}

Console.WriteLine();
Console.WriteLine();
#endregion

#region Collection.09
Purse purse = new Purse();

Console.WriteLine("Exercise Collection.09:");
Console.WriteLine("============================");
Console.WriteLine($"Value of purse is: {purse.ValueInKr}");
Console.WriteLine($"Number of 5kr coins: {purse.GetNoOfCoins(CoinType.kr5)}");

purse.AddCoins(CoinType.kr50, 2);
purse.AddCoins(CoinType.kr5, 7);
purse.AddCoins(CoinType.kr5, 7);
purse.AddCoins(CoinType.kr20, 3);

Console.WriteLine();
Console.WriteLine($"Value of purse is: {purse.ValueInKr}");
Console.WriteLine($"Number of 5kr coins: {purse.GetNoOfCoins(CoinType.kr5)}");
Console.WriteLine();
Console.WriteLine();
#endregion

#region Inheritance.01
List<string> lines = new List<string> {
    "Hello.My name is Inigo Montoya. You killed my father. Prepare to die!",
    "May the Force be with you.",
    "I'll be back.",
    "Here's looking at you, kid.",
    "Bond. James Bond.",
    "E.T. phone home.",
    "You talking to me?",
    "Just keep swimming.",
    "There's no place like home.",
    "I see dead people.",
    "To infinity and beyond!"
};
NPC npc01 = new NPC("Who Am I?", 100, 50, lines);

Console.WriteLine("Exercise Inheritance.01:");
Console.WriteLine("============================");

for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Quote {i + 1}: {npc01.Talk()}");
}

Console.WriteLine();
Console.WriteLine();
#endregion

#region Inheritance.02
PassiveNPC passiveNPC = new PassiveNPC("Lars", 100, lines, 50);

Console.WriteLine("Exercise Inheritance.02:");
Console.WriteLine("============================");

for (int i = 1; i < 6;i++)
{
    Console.WriteLine($"Quote {i}: {passiveNPC.Talk()}");
}

Console.WriteLine();

for (int round = 1; round < 6;round++)
{
    Console.WriteLine($"Round {round}: {passiveNPC.DealDamage()} damage dealt.");
}
Console.WriteLine();
Console.WriteLine();
#endregion

#region Inheritance.03
Character03 character03 = new PassiveNPC03("Lars", 100, lines);

Console.WriteLine("Exercise Inheritance.03:");
Console.WriteLine("============================");

for (int i = 1; i < 6;i++)
{
    Console.WriteLine($"Quote {i}: {character03.Talk()}");
}

Console.WriteLine();

for (int round = 1;round < 6;round++)
{
    Console.WriteLine($"Round {round}: {character03.DealDamage()} damage dealt.");
}

Console.WriteLine();
Console.WriteLine();
#endregion

#region Inheritance.04
ICharacter character04 = new PassiveNPC04("Lars", 100, lines);
Console.WriteLine("Exercise Inheritance.04:");
Console.WriteLine("============================");

for (int i = 1; i < 6; i++)
{
    Console.WriteLine($"Quote {i}: {character04.Talk()}");
}

Console.WriteLine();

for (int round = 1; round < 6; round++)
{
    Console.WriteLine($"Round {round}: {character04.DealDamage()} damage dealt.");
}

Console.WriteLine();
Console.WriteLine();
#endregion

#region Inheritance.05
ICharacter aZombie = new Zombie();

Console.WriteLine("Exercise Inheritance.05:");
Console.WriteLine("============================");

for (int i = 1; i < 6; i++)
{
    Console.WriteLine($"Quote {i}: {aZombie.Talk()}");
}

Console.WriteLine();

for (int round = 1; round < 6; round++)
{
    Console.WriteLine($"Round {round}: {aZombie.DealDamage()} damage dealt.");
}

Console.WriteLine();

GameSetup gameSetup = new GameSetup();
gameSetup.AllTalk();

Console.WriteLine();
Console.WriteLine();
#endregion

#region Generics.01
ChainLinkInt chainIntFive = new ChainLinkInt(5);
ChainLinkInt chainIntFour = new ChainLinkInt(4, chainIntFive);
ChainLinkInt chainIntThree = new ChainLinkInt(3, chainIntFour);
ChainLinkInt chainIntTwo = new ChainLinkInt(2, chainIntThree);
ChainLinkInt chainIntOne = new ChainLinkInt(1, chainIntTwo);

Console.WriteLine("Generics.01:");
Console.WriteLine("============================");

ChainLinkInt? intLink = chainIntOne;
while (intLink != null)
{
    Console.WriteLine(intLink.Value);
    intLink = intLink.Next;
}

Console.WriteLine();

ChainLinkString chainLinkC = new ChainLinkString("!");
ChainLinkString chainLinkB = new ChainLinkString("lists", chainLinkC);
ChainLinkString chainLinkA = new ChainLinkString("Linked", chainLinkB);

ChainLinkString? stringLink = chainLinkA;
while (stringLink != null)
{
    Console.WriteLine(stringLink.Value);
    stringLink = stringLink.Next;
}

Console.WriteLine();
Console.WriteLine();
#endregion

#region Generics.03
ChainLink<ICharacter> link03 = new ChainLink<ICharacter>(character04);
ChainLink<ICharacter> link02 = new ChainLink<ICharacter>(aZombie, link03);
ChainLink<ICharacter> link01 = new ChainLink<ICharacter>(character04, link02);

Console.WriteLine("Generics.03:");
Console.WriteLine("============================");

ChainLink<ICharacter>? link = link01;
int linkNo = 1;
while (link != null)
{
    Console.WriteLine($"Link {linkNo} - {link.Value} says: \"{link.Value.Talk()}\"");
    link = link.Next;
    linkNo++;
}

Console.WriteLine();

void PrintChainedCollection<T>(ChainLink<T>? startlink)
{
    ChainLink<T>? link = startlink;
    while (link != null)
    {
        Console.WriteLine(link.Value);
        link = link.Next;
    }
}

PrintChainedCollection(link01);

Console.WriteLine();
Console.WriteLine();
#endregion

#region Generics.04
IdBase<string> testString = new IdBase<string>(122);
IdBase<float> testFloat = new IdBase<float>(312);
IdBase<int> testInt = new IdBase<int>(3245);
IdBase<List<string>> testList = new IdBase<List<string>>(13);

Console.WriteLine("Generics.04:");
Console.WriteLine("============================");
Console.WriteLine(testString);
Console.WriteLine(testFloat);
Console.WriteLine(testInt);
Console.WriteLine(testList);
Console.WriteLine();

Item testItem = new Item(22, "Dingenot");
Person testPerson = new Person(42, "Lars");

Console.WriteLine(testItem);
Console.WriteLine(testPerson);
Console.WriteLine();
Console.WriteLine();
#endregion

#region Generics.05
Person personA = new Person(123, "Lars");
Person personB = new Person(2212, "Kurt");
Person personC = new Person(7913, "D. And");
Item itemA = new Item(31, "Hammer");
Item itemB = new Item(123, "Skruetrækker");
Item itemC = new Item(313, "Flaske");

ChainedCollection<IHasId> chainedCollection = new ChainedCollection<IHasId>();
chainedCollection.AddStart(personA);
chainedCollection.AddEnd(personB);
chainedCollection.AddStart(personC);
chainedCollection.AddEnd(itemA);
chainedCollection.AddStart(itemB);
chainedCollection.AddEnd(itemC);

Console.WriteLine("Generics.05:");
Console.WriteLine("============================");
Console.WriteLine("Test af Read-funktion");
Console.WriteLine(chainedCollection.Read(2212));
Console.WriteLine(chainedCollection.Read(123));
Console.WriteLine(chainedCollection.Read(14));
Console.WriteLine();

Console.WriteLine("Test af GetAll-funktion");
List<IHasId> chainedList = chainedCollection.GetAll();
foreach (IHasId id in chainedList)
{
    Console.WriteLine(id);
}
Console.WriteLine();
Console.WriteLine();
#endregion