namespace AOC2017_Day2;

class Program {
    private const string IntroFile = @"D:\AdventOfCode\AOC2017\Day2\Inputs\intro.txt";
    private const string ActualFile = @"D:\AdventOfCode\AOC2017\Day2\Inputs\actual.txt";
    
    static void Main(string[] args)
    {
        Console.WriteLine($"Intro: {Intro()}");
        Console.WriteLine($"Part One: {PartOne()}");
        Console.WriteLine($"Part Two: {PartTwo()}");
    }

    static int Intro() {
        var sum = 0;
        var lines = File.ReadAllLines(IntroFile);
        foreach (var line in lines) {
            var numbers = line.Split('\t').Select(int.Parse).ToList();
            sum += numbers.Max() - numbers.Min();
        }

        return sum;
    }
    
    static int PartOne() {
        var sum = 0;
        var lines = File.ReadAllLines(ActualFile);
        foreach (var line in lines) {
            var numbers = line.Split('\t').Select(s => int.Parse(s.Trim())).ToList();
            sum += numbers.Max() - numbers.Min();
        }

        return sum;
    }
    
    static int PartTwo() {
        var sum = 0;
        var lines = File.ReadAllLines(ActualFile);
        foreach (var line in lines) {
            var numbers = line.Split('\t').Select(s => int.Parse(s.Trim())).ToList();
            for (var i = 0; i < numbers.Count; i++) {
                for (var x = i+1; x < numbers.Count; x++) {
                    if (numbers[i] % numbers[x] == 0) {
                        sum += numbers[i] / numbers[x];
                        Console.WriteLine($"{numbers[i]} / {numbers[x]}");
                        break;
                    }
                    if (numbers[x] % numbers[i] == 0) {
                        sum += numbers[x] / numbers[i];
                        Console.WriteLine($"{numbers[x]} / {numbers[i]}");
                        break;
                    }
                }
            }
        }
        
        return sum;
    }
}
