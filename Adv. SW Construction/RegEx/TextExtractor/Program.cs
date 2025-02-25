using System.Text.RegularExpressions;

string text = "Two swindlers arrive at the capital city of an emperor who spends lavishly " +
              "on clothing at the expense of state matters. Posing as weavers, they offer " +
              "to supply him with magnificent clothes that are invisible to those who are " +
              "stupid or incompetent. The emperor hires them, and they set up looms and go " +
              "to work. A succession of officials, and then the emperor himself, visit them " +
              "to check their progress. Each sees that the looms are empty but pretends " +
              "otherwise to avoid being thought a fool. Finally, the weavers report that " +
              "the emperor's suit is finished. They mime dressing him and he sets off in a " +
              "procession before the whole city. The townsfolk uncomfortably go along with " +
              "the pretense, not wanting to appear inept or stupid, until a child blurts " +
              "out that the emperor is wearing nothing at all. The people then realize that " +
              "everyone has been fooled. Although startled, the emperor continues the " +
              "procession, walking more proudly than ever";


string pattern = @"[Ee]mperor";
Regex regex = new Regex(pattern);
Dictionary<int, string> matches = new Dictionary<int, string>();


// Find the indexes of where the word emperor occur – with or without starting uppercase E.
foreach (Match match in regex.Matches(text))
{
    matches.Add(match.Index, match.Value);
}

Console.WriteLine("Index of each match:");
foreach ((int key, string match) in matches)
{
    Console.WriteLine($"Found match: {match} at index: {key}");
}


// Change the ‘emperor’ to ‘teacher’ and print out the new text.
string newText = regex.Replace(text, "teacher");
Console.WriteLine("\nOriginal text with emperor changed to teacher:");
Console.WriteLine(newText);


// Make capture groups of sentences, extract these and print them out
pattern = @"([\w\s,']+\.)\s*";
regex = new Regex(pattern);

MatchCollection sentences = regex.Matches(text);

Console.WriteLine("\nEach sentence in the original text");
for (int i = 0;  i < sentences.Count; i++)
{
    string sentence = sentences[i].Value.Trim();
    Console.WriteLine($"Sentence {i+1}:\n{sentence}\n");
}