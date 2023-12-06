namespace AOC2023_Day5;

class Program
{
    const string IntroFile = @"D:\AdventOfCodeAllYears\AOC2023\Day5\Inputs\intro.txt";
    const string ActualFile = @"D:\AdventOfCodeAllYears\AOC2023\Day5\Inputs\actual.txt";

    static List<DictRange> seedToSoil = new();
    static List<DictRange> soilToFert = new();
    static List<DictRange> fertToWater = new();
    static List<DictRange> waterToLight = new();
    static List<DictRange> lightToTemp = new();
    static List<DictRange> tempToHumidity = new();
    static List<DictRange> humidityToLoc = new();
    static List<Seed> seedList = new List<Seed>();
    
    static void Main(string[] args)
    {
        //Console.WriteLine($"Intro: {PartOne(IntroFile)}");
        //Console.WriteLine($"Part One: {PartOne(ActualFile)}");
        Console.WriteLine($"Part Two: {PartTwo(ActualFile)}");
    }
    
    private static long PartOne(string file) {
        var lines = File.ReadAllLines(file);
        var currentMap = CurrentList.Seed2Soil;
        var currentLines = new List<string>();
        for (var index = 0; index < lines.Length; index++) {
            var line = lines[index];
            //Console.WriteLine($"{currentLines.Count} - {line}");
            if (string.IsNullOrWhiteSpace(line) && currentLines.Count > 1) {
                ParseLinesToDict(currentLines, currentMap);
                currentLines = new List<string>();
                //Console.WriteLine($"List Parsed To {currentMap}");
            }
            else if (string.IsNullOrWhiteSpace(line) && currentLines.Count == 0) {
               
            }
            else if (line.Contains("seeds:")) {
                seedList = ParseSeedsFromLine(line);
                //Console.WriteLine("Current List: Seeds");
            }
            else if (line.Contains("seed-to-soil map:")) {
                currentMap = CurrentList.Seed2Soil;
                //Console.WriteLine("Current List: Soil");
            }
            else if (line.Contains("soil-to-fertilizer map:")) {
                currentMap = CurrentList.Soil2Fert;
                //Console.WriteLine("Current List: Fert");
            }
            else if (line.Contains("fertilizer-to-water map:")) {
                currentMap = CurrentList.Fert2Water;
                //Console.WriteLine("Current List: Water");
            }
            else if (line.Contains("water-to-light map:")) {
                currentMap = CurrentList.Water2Light;
                //Console.WriteLine("Current List: Light");
            }
            else if (line.Contains("light-to-temperature map:")) {
                currentMap = CurrentList.Light2Temp;
                //Console.WriteLine("Current List: Temp");
            }
            else if (line.Contains("temperature-to-humidity map:")) {
                currentMap = CurrentList.Temp2Humidity;
                //Console.WriteLine("Current List: Humidity");
            }
            else if (line.Contains("humidity-to-location map:")) {
                currentMap = CurrentList.Humidity2Location;
                //Console.WriteLine("Current List: Loc");
            }
            else {
                currentLines.Add(line);
                //Console.WriteLine($"Added {line} to {currentMap}");
            }
        }
        if (currentLines.Count > 1) {
            ParseLinesToDict(currentLines, currentMap);
        }
        foreach (var seed in seedList) {
            seed.Soil = GetDictValue(seed.Id, CurrentList.Seed2Soil);
            seed.Fert = GetDictValue(seed.Soil, CurrentList.Soil2Fert);
            seed.Water = GetDictValue(seed.Fert, CurrentList.Fert2Water);
            seed.Light = GetDictValue(seed.Water, CurrentList.Water2Light);
            seed.Temp = GetDictValue(seed.Light, CurrentList.Light2Temp);
            seed.Humidity = GetDictValue(seed.Temp, CurrentList.Temp2Humidity);
            seed.Location = GetDictValue(seed.Humidity, CurrentList.Humidity2Location);
        }
        if (true) {
            foreach (var seed in seedList) {
                Console.WriteLine(seed);
                Console.WriteLine("=====================================");
            }
        }
        
        
        return seedList.Min(s => s.Location);
    }
    
    private static  long PartTwo(string file) {
        var lines = File.ReadAllLines(file);
        var currentMap = CurrentList.Seed2Soil;
        var currentLines = new List<string>();
        var seedFile = "";
        Console.WriteLine("Parsing Lines");
        for (var index = 0; index < lines.Length; index++) {
            var line = lines[index];
            //Console.WriteLine($"{currentLines.Count} - {line}");
            if (string.IsNullOrWhiteSpace(line) && currentLines.Count > 1) {
                ParseLinesToDict(currentLines, currentMap);
                currentLines = new List<string>();
                //Console.WriteLine($"List Parsed To {currentMap}");
            }
            else if (string.IsNullOrWhiteSpace(line) && currentLines.Count == 0) {
               
            }
            else if (line.Contains("seeds:")) {
                seedFile = ParseSeedsFromLinePartTwo(line);
                //Console.WriteLine("Current List: Seeds");
            }
            else if (line.Contains("seed-to-soil map:")) {
                currentMap = CurrentList.Seed2Soil;
                //Console.WriteLine("Current List: Soil");
            }
            else if (line.Contains("soil-to-fertilizer map:")) {
                currentMap = CurrentList.Soil2Fert;
                //Console.WriteLine("Current List: Fert");
            }
            else if (line.Contains("fertilizer-to-water map:")) {
                currentMap = CurrentList.Fert2Water;
                //Console.WriteLine("Current List: Water");
            }
            else if (line.Contains("water-to-light map:")) {
                currentMap = CurrentList.Water2Light;
                //Console.WriteLine("Current List: Light");
            }
            else if (line.Contains("light-to-temperature map:")) {
                currentMap = CurrentList.Light2Temp;
                //Console.WriteLine("Current List: Temp");
            }
            else if (line.Contains("temperature-to-humidity map:")) {
                currentMap = CurrentList.Temp2Humidity;
                //Console.WriteLine("Current List: Humidity");
            }
            else if (line.Contains("humidity-to-location map:")) {
                currentMap = CurrentList.Humidity2Location;
                //Console.WriteLine("Current List: Loc");
            }
            else {
                currentLines.Add(line);
                //Console.WriteLine($"Added {line} to {currentMap}");
            }
        }

        Console.WriteLine("Parsed Lines");
        if (currentLines.Count > 1) {
            ParseLinesToDict(currentLines, currentMap);
        }

        Console.WriteLine("Getting Seeds From File");
        using var fs = new StreamReader(seedFile);
        long lowest = -1;
        var tasks = new List<Task<long>>();
        while (!fs.EndOfStream) {
            var line =  fs.ReadLine();
            if (!long.TryParse(line, out var id)) continue;
            var seed = id;
            var Soil = GetDictValue(seed, CurrentList.Seed2Soil);
            var Fert = GetDictValue(Soil, CurrentList.Soil2Fert);
            var Water = GetDictValue(Fert, CurrentList.Fert2Water);
            var Light = GetDictValue(Water, CurrentList.Water2Light);
            var Temp = GetDictValue(Light, CurrentList.Light2Temp);
            var Humidity = GetDictValue(Temp, CurrentList.Temp2Humidity);
            var Location = GetDictValue(Humidity, CurrentList.Humidity2Location);
            if (Location < lowest || lowest == -1) {
                Console.WriteLine($"Lowest: {lowest}");
                lowest = Location;
            }
        }
        fs.Close();
        
        return lowest;
    }

    private static long GetDictValue(long id, CurrentList list) {
        var curDict = list switch {
            CurrentList.Seed2Soil => seedToSoil,
            CurrentList.Soil2Fert => soilToFert,
            CurrentList.Fert2Water => fertToWater,
            CurrentList.Water2Light => waterToLight,
            CurrentList.Light2Temp => lightToTemp,
            CurrentList.Temp2Humidity => tempToHumidity,
            CurrentList.Humidity2Location => humidityToLoc,
            _ => throw new ArgumentOutOfRangeException(nameof(list), list, null)
        };
        foreach (var range in curDict.Where(range => id >= range.SourceStart && id <= range.SourceEnd)) {
            var d = range.DestStart;
            var s = range.SourceStart;
            var offset = d - s;
            return offset + id;
        }

        return id;
    }
    
    
    private static void ParseLinesToDict(List<string> lines, CurrentList list) {
        var curDict = list switch {
            CurrentList.Seed2Soil => seedToSoil,
            CurrentList.Soil2Fert => soilToFert,
            CurrentList.Fert2Water => fertToWater,
            CurrentList.Water2Light => waterToLight,
            CurrentList.Light2Temp => lightToTemp,
            CurrentList.Temp2Humidity => tempToHumidity,
            CurrentList.Humidity2Location => humidityToLoc,
            _ => throw new ArgumentOutOfRangeException(nameof(list), list, null)
        };

        foreach (var line in lines) {
            var split = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine(line);
            var dest = long.Parse(split[0]);
            var source = long.Parse(split[1]);
            var len = long.Parse(split[2]);
            curDict.Add(new DictRange() {
                DestStart = dest,
                DestEnd = dest+len,
                SourceStart = source,
                SourceEnd = source+len
            });
        }
    }

    private static List<Seed> ParseSeedsFromLine(string line) {
        Console.WriteLine("Creating Seeds");
        var split = line.Split(':').Last().Trim().Split(' ');
        var list = new List<Seed>();
        foreach (var s in split) {

            if (int.TryParse(s, out var id)) {
                list.Add(new Seed() {
                    Id = id
                });
            }
        }
        
        return list;
    }
    private static string ParseSeedsFromLinePartTwo(string line) {
        Console.WriteLine("Creating Seeds");
        
        var entries = new List<(long seedStart, long seedQty, long seedEnd)>();
        var split = line.Split(':').Last().Trim().Split(' ');
        var list = new List<Seed>();

        for (var i = 0; i < split.Length; i += 2) {
            var seedStart = long.Parse(split[i]);
            var seedQty = long.Parse(split[i+1]);
            var seedEnd = seedStart + seedQty;
            entries.Add((seedStart,seedQty,seedEnd));
        }
        Console.WriteLine($"Seeds found: {entries.Count}");
        Console.WriteLine("Filtering Seeds");
        var actual = new List<(long seedStart, long seedQty, long seedEnd)>();
        foreach (var entry in entries) {
            if (actual.Count < 1) {
                actual.Add(entry);
            }
            if (!actual.Any(e => e.seedStart <= entry.seedStart && e.seedEnd >= entry.seedEnd)) {
                actual.Add(entry);
            }
        }
        File.WriteAllText("ids.txt", "");
        using var sw = new StreamWriter("ids.txt");
        Console.WriteLine($"Seeds filtered: {actual.Count}");
        Console.WriteLine("Finishing Seeds");
        var seedsDone = new List<(long start, long end)>();
        foreach (var entry in actual) {
            Console.WriteLine($"{entry.seedStart} - {entry.seedEnd}");
            if (seedsDone.Any(s => s.start >= entry.seedStart && s.end <= entry.seedEnd)) {
                Console.WriteLine("Skipped");
            }
            else {
                seedsDone.Add((entry.seedStart, entry.seedEnd));
                for (var j = entry.seedStart; j <= entry.seedStart + entry.seedQty; j++) {
                    sw.WriteLine($"{j}");
                }
            }
        }
        Console.WriteLine($"Seeds finished: {list.Count}");
        sw.Close();
        return "ids.txt";
    }
}

internal enum CurrentList {
    Seed2Soil,
    Soil2Fert,
    Fert2Water,
    Water2Light,
    Light2Temp,
    Temp2Humidity,
    Humidity2Location
}


internal class DictRange {
    public long DestStart { get; set; }
    public long DestEnd { get; set; }
    public long SourceStart { get; set; }
    public long SourceEnd { get; set; }
}


internal class Seed {
    public long Id { get; set; }
    public long Soil { get; set; }
    public long Fert { get; set; }
    public long Water { get; set; }
    public long Light { get; set; }
    public long Temp { get; set; }
    public long Humidity { get; set; }
    public long Location { get; set; }

    public override string ToString() {
        return $"ID: {Id} \tSoil: {Soil} \tFert: {Fert} \tWater: {Water} \tLight: {Light} \nTemp: {Temp} \tHumidity: {Humidity} \tLocation: {Location}";
    }
}

