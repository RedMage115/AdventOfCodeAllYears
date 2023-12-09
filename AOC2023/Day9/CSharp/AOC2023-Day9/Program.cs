namespace AOC2023_Day9;

class Program
{
    const string IntroFile = @"D:\AdventOfCodeAllYears\AOC2023\Day9\Inputs\intro.txt";
    const string ActualFile = @"D:\AdventOfCodeAllYears\AOC2023\Day9\Inputs\actual.txt";
    static void Main(string[] args)
    {
        Console.WriteLine($"Intro: {PartOne(IntroFile)}");
        Console.WriteLine("Part One: {}");
        Console.WriteLine("Part Two: {}");
    }

    static long PartOne(string file) {
        var lines = File.ReadAllLines(file);

        return 0L;
    }
    
}

