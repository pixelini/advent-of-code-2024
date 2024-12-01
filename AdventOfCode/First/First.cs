namespace AdventOfCode.First;

public static class First
{
    private const string Title = "--- Day 1: Historian Hysteria ---";

    private const string InputFilePathRelative = @"First\01_input.txt";

    private static int SolutionPart1 { get; set; }
    
    private static int SolutionPart2 { get; set; }
    
    public static void ShowSolution()
    {
        CalculateSolutionPart1();
        CalculateSolutionPart2();
        
        Console.WriteLine(Title);
        Console.WriteLine($"Solution Part 1: Total distance: {SolutionPart1}.");
        Console.WriteLine($"Solution Part 2: Similarity score: {SolutionPart2}.");
    }

    private static void CalculateSolutionPart1()
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
    }

    private static void CalculateSolutionPart2()
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
    }

    private static (List<int> left, List<int> right) GetLeftAndRightList()
    {
        var fullPath = Path.GetFullPath(Path.Combine(Config.BasePath, InputFilePathRelative));
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