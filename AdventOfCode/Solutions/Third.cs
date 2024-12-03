using System.Text.RegularExpressions;
using AdventOfCode.Base;

namespace AdventOfCode.Solutions;

public class Third(string title, string inputFile) : Puzzle(title, inputFile)
{
    private int SolutionPart1 { get; set; }

    private int SolutionPart2 { get; set; }
    
    public override void ShowSolution()
    {
        if (SolvePart1() && SolvePart2())
        {
            Solved = true;
        }

        Console.WriteLine(Title);
        Console.WriteLine($"Solution Part 1: What do you get if you add up all of the results of the multiplications? {SolutionPart1}");
        Console.WriteLine($"Solution Part 2: What do you get if you add up all of the results of just the enabled multiplications? {SolutionPart2}");
    }
    
    private bool SolvePart1()
    {
        var text = ReadInput().Trim();
        
        var pattern = @"mul\(\d*,\d*\)";
        var optionRegex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        var matches = optionRegex.Matches(text);

        var matchedStrings = matches.Select(x => x.Value).ToList();

        SolutionPart1 = CountResultFromMatches(matchedStrings);
        return true;
    }

    private bool SolvePart2()
    {
        var text = ReadInput().Trim();
        
        var pattern = @"(mul\(\d*,\d*\))|(don't\(\))|(do\(\))";
        var optionRegex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        var matches = optionRegex.Matches(text);

        var matchedStrings = matches.Select(x => x.Value).ToList();
        var matchedStringAfterCheck = new List<string>();

        var isEnabled = true;
        foreach (var match in matchedStrings)
        {
            isEnabled = match switch
            {
                "don't()" => false,
                "do()" => true,
                _ => isEnabled
            };

            if (isEnabled && match != "do()" && match != "don't()")
            {
                matchedStringAfterCheck.Add(match);
            }
        }
        
        SolutionPart2 = CountResultFromMatches(matchedStringAfterCheck);
        return true;
    }
    
    private string ReadInput()
    {
        var fullPath = Path.GetFullPath(Path.Combine(Config.InputPath, InputFile));
        using StreamReader reader = new StreamReader(fullPath);
        return reader.ReadToEnd();
    }
    
    private int CountResultFromMatches(List<string> matches)
    {
        var result = 0;
        for (int i = 0; i < matches.Count; i++)
        {
            var substring = matches[i].Substring(4, (matches[i].Length - 1) - 4).Split(',');
            result += int.Parse(substring[0]) * int.Parse(substring[1]);
        }
        return result;
    }
}