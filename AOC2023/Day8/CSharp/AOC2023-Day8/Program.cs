namespace AOC2023_Day8;

static class Program
{
    const string IntroFile = @"D:\AdventOfCodeAllYears\AOC2023\Day8\Inputs\intro.txt";
    const string ActualFile = @"D:\AdventOfCodeAllYears\AOC2023\Day8\Inputs\actual.txt";

    static void Main(string[] args)
    {
        Console.WriteLine($"Intro: {PartOne(IntroFile)}");
        Console.WriteLine("Part One: {PartOne(ActualFile)}");
        Console.WriteLine("Part Two: {PartTwo(ActualFile)}");
    }

    static int PartOne(string file) {
        var lines = File.ReadAllLines(file);


        return 0;
    }
    
}
