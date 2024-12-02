namespace AdventOfCode.Base;

public abstract class Puzzle(string title, string inputFile)
{
    public bool Solved { get; set; }
    
    protected string Title { get; set; } = title;

    protected string InputFile { get; set; } = inputFile;

    public abstract void ShowSolution();
}