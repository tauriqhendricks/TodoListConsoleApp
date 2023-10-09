var words = new List<string> { "one", "TWO123", "THREE!&^", "four" };

var uppercaseWords = GetOnlyUpperCaseWords(words);
Console.WriteLine("count" + uppercaseWords.Count());
foreach (var item in uppercaseWords)
{
    Console.WriteLine(item);
}

Console.ReadKey();

static List<string> GetOnlyUpperCaseWords(List<string> words)
{
    var result = new List<string>();
    foreach (var word in words)
    {
        if (result.Contains(word))
        {
            continue;
        }

        var charToWord = "";
        foreach (char @char in word)
        {
            if (!char.IsLetter(@char))
            {
                charToWord = "";
                continue;
            }

            if (char.IsUpper(@char))
            {
                charToWord += @char;
            }
        }

        if (!string.IsNullOrEmpty(charToWord))
            result.Add(charToWord);
    }

    return result;
}