namespace AOC2023_Day6;

class Program
{
    const string IntroFile = @"D:\AdventOfCodeAllYears\AOC2023\Day6\Inputs\intro.txt";
    const string ActualFile = @"D:\AdventOfCodeAllYears\AOC2023\Day6\Inputs\actual.txt";
    const string ActualFile2 = @"D:\AdventOfCodeAllYears\AOC2023\Day6\Inputs\actual2.txt";
    static void Main(string[] args)
    {
        Console.WriteLine($"Intro: {PartOne(IntroFile)}");
        Console.WriteLine($"Part One: {PartOne(ActualFile)}");
        Console.WriteLine($"Part Two: {PartTwo(ActualFile2)}");
    }

    static long PartOne(string file) {
        var lines = File.ReadAllLines(file);
        var times = lines.First()
            .Split(':')
            .Last()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var distances = lines.Last()
            .Split(':')
            .Last()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var races = new List<Race>();
        for (long i = 0; i < times.Length; i++) {
            races.Add(new Race() {
                Time = long.Parse(times[i]),
                Dist = long.Parse(distances[i])
            });
        }

        foreach (var race in races) {
            for (var speed = 0; speed < race.Time; speed++) {
                var timeRem = race.Time - speed;
                if (timeRem * speed > race.Dist) {
                    race.PossibleWins.Add(speed);
                }
            }
        }

        return races.Aggregate(1, (current, race) => current * race.PossibleWins.Count);
    }
    static long PartTwo(string file) {
        var lines = File.ReadAllLines(file);
        var times = lines.First()
            .Split(':')
            .Last();
        var distances = lines.Last()
            .Split(':')
            .Last();


        var race = new Race() {
            Time = long.Parse(times),
            Dist = long.Parse(distances)
        };
        var possibleWins = 0;
        for (var speed = 0; speed < race.Time; speed++) {
            var timeRem = race.Time - speed;
            if (timeRem * speed > race.Dist) {
                possibleWins += 1;
            }
        }
        
        return possibleWins;
    }
    
}

internal class Race {
    public long Time { get; set; }
    public long Dist { get; set; }
    public List<long> PossibleWins { get; set; } = new List<long>();
}

