namespace AOC2023_Day9;

class Program
{
    const string IntroFile = @"D:\AdventOfCodeAllYears\AOC2023\Day9\Inputs\intro.txt";
    const string ActualFile = @"D:\AdventOfCodeAllYears\AOC2023\Day9\Inputs\actual.txt";
    static void Main(string[] args)
    {
        Console.WriteLine($"Intro: {PartOne(IntroFile)}");
        Console.WriteLine($"Part One: {PartOne(ActualFile)}");
        Console.WriteLine($"Part Two: {PartTwo(ActualFile)}");
    }

    static long PartOne(string file) {
        var lines = File.ReadAllLines(file);
        var sum = 0L;
        var readingList = new List<Reading>();
        foreach (var line in lines) {
            var split = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var nums = split.Select(long.Parse).ToList();
            var diffLists = new List<List<long>>() {
                nums
            };
            while (diffLists.Last().Any(x => x != 0)) {
                var list = new List<long>();
                for (var i = 1; i < diffLists.Last().Count; i++) {
                    list.Add(diffLists.Last()[i] - diffLists.Last()[i-1]);
                }
                diffLists.Add(list);
            }

            diffLists.Reverse();
            readingList.Add(new Reading() {
                InitialSeq = nums,
                DiffLists = diffLists,
            });
        }

        foreach (var reading in readingList) {
            for (var x = 1; x < reading.DiffLists.Count; x++) {
                Console.WriteLine($"List: {x}");
                var list = reading.DiffLists[x];
                var inc = reading.DiffLists[x - 1].Last();
                Console.WriteLine($"last: {list.Last()}");
                Console.WriteLine($"Inc: {inc}");
                list.Add(list.Last() + inc);
            }
            Console.WriteLine($"Final Inc: {reading.DiffLists.Last().Last()}");
            Console.WriteLine($"Final Last: {reading.InitialSeq.Last()}");
            reading.NextNumber = reading.InitialSeq.Last();
        }

        foreach (var reading in readingList) {
            sum += reading.NextNumber;
            Console.WriteLine(sum);
        }
        
        
        return sum;
    }
    
    static long PartTwo(string file) {
        var lines = File.ReadAllLines(file);
        var sum = 0L;
        var readingList = new List<Reading>();
        foreach (var line in lines) {
            var split = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var nums = split.Select(long.Parse).ToList();
            var diffLists = new List<List<long>>() {
                nums
            };
            while (diffLists.Last().Any(x => x != 0)) {
                var list = new List<long>();
                for (var i = 1; i < diffLists.Last().Count; i++) {
                    list.Add(diffLists.Last()[i] - diffLists.Last()[i-1]);
                }
                
                diffLists.Add(list);
            }
            readingList.Add(new Reading() {
                InitialSeq = nums,
                DiffLists = diffLists,
            });
        }
        
        foreach (var reading in readingList) {
            
            for (var x = reading.DiffLists.Count - 2; x >= 0 ; x--) {
                var list1 = reading.DiffLists[x];
                var list2 = reading.DiffLists[x+1];
                list1.Insert(0,list1.First() - list2.First());
                Console.WriteLine(list1.First());
            }
            reading.NextNumber = reading.InitialSeq.First() - reading.DiffLists.Last().First();
            Console.WriteLine("----------------");
        }
        

        foreach (var reading in readingList) {
            sum += reading.NextNumber;
            Console.WriteLine(sum);
        }
        
        
        return sum;
    }
    
}

internal class Reading {
    public List<long> InitialSeq { get; set; } = new List<long>();
    public List<List<long>> DiffLists { get; set; } = new List<List<long>>();
    public long NextNumber { get; set; }
}

