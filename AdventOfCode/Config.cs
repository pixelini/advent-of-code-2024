namespace AdventOfCode;

public static class Config
{
    private static readonly string BasePath =
        Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName;

    public static readonly string InputPath = Path.GetFullPath(Path.Combine(BasePath, "Inputs"));
}