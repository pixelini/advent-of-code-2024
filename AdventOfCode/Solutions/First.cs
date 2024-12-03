using AdventOfCode.Base;

namespace AdventOfCode.Solutions;

public class First(string title, string inputFile) : Puzzle(title, inputFile)
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
        Console.WriteLine($"Solution Part 1: Total distance: {SolutionPart1}");
        Console.WriteLine($"Solution Part 2: Similarity score: {SolutionPart2}");
    }

    private bool SolvePart1()
    {
        var (left, right) = GetLeftAndRightList();

        left.Sort();
        right.Sort();

        var sumDistances = 0;
        for (int i = 0; i < left.Count; i++)
        {
            sumDistances += Math.Abs(left[i] - right[i]);
        }

        SolutionPart1 = sumDistances;
        return true;
    }

    private bool SolvePart2()
    {
        var (left, right) = GetLeftAndRightList();

        var similarityScore = 0;
        foreach (var numberToCount in left)
        {
            var count = numberToCount;
            var appearances = right.Count(x => count == x);

            similarityScore += numberToCount * appearances;
        }

        SolutionPart2 = similarityScore;
        return true;
    }

    private (List<int> left, List<int> right) GetLeftAndRightList()
    {
        var fullPath = Path.GetFullPath(Path.Combine(Config.InputPath, InputFile));
        using StreamReader reader = new StreamReader(fullPath);

        var left = new List<int>();
        var right = new List<int>();

        while (reader.ReadLine() is { } line)
        {
            var parts = line.Split(' ');
            left.Add(int.Parse(parts[0]));
            right.Add(int.Parse(parts[3]));
        }

        return (left, right);
    }
}