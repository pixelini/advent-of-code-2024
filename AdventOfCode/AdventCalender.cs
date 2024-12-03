using AdventOfCode.Base;
using AdventOfCode.Solutions;

namespace AdventOfCode;

public class AdventCalender
{
    private List<Puzzle> Puzzles { get; } =
    [
        new First("--- Day 1: Historian Hysteria ---", "01_input.txt"),
        new Second("--- Day 2: Red-Nosed Reports ---", "02_input.txt"),
        new Third("--- Day 3: Mull It Over ---", "03_input.txt")
    ];

    public void Run()
    {
        foreach (var puzzle in Puzzles)
        {
            puzzle.ShowSolution();
        }
    }

    public void ShowStats()
    {
        var solved = Puzzles.CountBy(puzzle => puzzle.Solved).First().Value;
        var puzzlesTotal = 24;
        
        var percentage = solved * 100 / Puzzles.Count;
        var percentageOverall = solved * 100 / puzzlesTotal;

        Console.WriteLine();
        Console.WriteLine("----------------- STATS -----------------");
        Console.WriteLine($"{solved}/{Puzzles.Count} ({percentage}%) puzzles solved");
        Console.WriteLine($"{solved}/{puzzlesTotal} ({percentageOverall}%) puzzles solved [OVERALL]");
    }
}