using AdventOfCode.Base;

namespace AdventOfCode.Solutions;

public class Second(string title, string inputFile) : Puzzle(title, inputFile)
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
        Console.WriteLine($"Solution Part 1: How many reports are safe? {SolutionPart1}");
        Console.WriteLine($"Solution Part 2: How many reports are now safe? {SolutionPart2}");
    }

    private bool SolvePart1()
    {
        var reports = GetReports();

        var saveReports = 0;
        for (int i = 0; i < reports.Count; i++)
        {
            if (IsSave(reports[i]))
            {
                saveReports++;
            }
        }

        SolutionPart1 = saveReports;
        return true;
    }

    private bool SolvePart2()
    {
        var reports = GetReports();

        var saveReports = 0;
        for (int i = 0; i < reports.Count; i++)
        {
            if (IsSave(reports[i]))
            {
                saveReports++;
            }
            else
            {
                for (int j = 0; j < reports[i].Count; j++)
                {
                    var tempReport = new List<int>(reports[i]);
                    tempReport.RemoveAt(j);

                    if (IsSave(tempReport))
                    {
                        saveReports++;
                        break;
                    }
                }
            }
        }

        SolutionPart2 = saveReports;
        return true;
    }

    private List<List<int>> GetReports()
    {
        var fullPath = Path.GetFullPath(Path.Combine(Config.InputPath, InputFile));
        using StreamReader reader = new StreamReader(fullPath);

        var reports = new List<List<int>>();
        while (reader.ReadLine() is { } line)
        {
            var report = Array.ConvertAll(line.Split(' '), int.Parse).ToList();
            reports.Add(report);
        }

        return reports;
    }

    private static bool IsSave(List<int> report)
    {
        bool increasing = report[0] < report[^1];

        var isSafe = true;
        for (int i = 0; i < report.Count - 1; i++)
        {
            var value1 = report[i];
            var value2 = report[i + 1];
            var adjacentLevel = Math.Abs(value1 - value2);

            if (increasing && (value1 > value2 || (adjacentLevel < 1 || adjacentLevel > 3)))
            {
                isSafe = false;
                break;
            }

            if (!increasing && (value1 < value2 || (adjacentLevel < 1 || adjacentLevel > 3)))
            {
                isSafe = false;
                break;
            }
        }

        return isSafe;
    }
}