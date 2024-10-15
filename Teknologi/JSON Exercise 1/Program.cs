
using JSON_Exercise_1.Solutions;

const int SOLUTION_TO_RUN = 2;

switch (SOLUTION_TO_RUN)
{
	case 1:
        new JsonStringSerialization().Run();
		break;
	case 2:
        new JsonListSerialization().Run();
		break;
    default:
        Console.WriteLine("Invalid Solution Specified");
		break;
}

enum Solutions
{
    JSON_STRING_SERIALIZATION = 1,
    JSON_LIST_SERIALIZATION = 2
}