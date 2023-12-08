using System.Diagnostics;

Console.WriteLine("======================================================");
Console.WriteLine("|             Advent Of Code Day Gen                 |");
Console.WriteLine("======================================================");

const string aocRoot = @"D:\AdventOfCodeAllYears";
Console.WriteLine("Enter Year...");
var year = Console.ReadLine();
if (string.IsNullOrWhiteSpace(year)) return;
Console.WriteLine("Enter Day...");
var day = Console.ReadLine();
if (string.IsNullOrWhiteSpace(day)) return;
Console.WriteLine($"Creating {year}/{day}");

var langs = new List<string> {
    "C",
    "CPlusPlus",
    "CSharp",
    "FSharp",
    "Rust",
    "Javascript",
    "Java",
    "Python",
};

foreach (var dir in langs.Select(lang =>
             Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", lang, $"AOC{year}-Day{day}"))) {
    Directory.CreateDirectory(dir);
    Console.WriteLine($"Created: {dir}");
}
Console.WriteLine("Creating input folder...");

Directory.CreateDirectory(Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", "Inputs"));
if (!File.Exists(Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", "Inputs", "actual.txt"))) {
    Console.WriteLine("Creating actual.txt");
    File.WriteAllText(Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", "Inputs", "actual.txt"),"");
}

if (!File.Exists(Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", "Inputs", "intro.txt"))) {
    Console.WriteLine("Creating intro.txt");
    File.WriteAllText(Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", "Inputs", "intro.txt"),"");
}
    

Console.WriteLine("Creating .sln files...");

var csFolder = Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", "CSharp", $"AOC{year}-Day{day}");
var fsFolder = Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", "FSharp", $"AOC{year}-Day{day}");
var gitIgnoreLines = new List<string>() {
    ".idea",
    "out",
    "obj",
    "bin",
    "*.exe",
    "bin/*",
    "out/*",
    "obj/*",
    ".idea/*",
};
if (Directory.GetFiles(fsFolder).Length < 1) {
    var psi = new ProcessStartInfo() {
        FileName = "dotnet",
        WorkingDirectory = fsFolder,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        CreateNoWindow = true,
        UseShellExecute = false,
        Arguments = """new console -lang="F#" """
    };
    var process = Process.Start(psi);
    process?.WaitForExit();
    Console.WriteLine("Created F# sln");
    Console.WriteLine("Creating .gitignores");
    File.WriteAllLines(Path.Combine(fsFolder, ".gitignore"), gitIgnoreLines);
    Console.WriteLine("Adding input file constants");
    var inputLines = new List<string>() {
        $"""let IntroFile = @"{Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", "Inputs", "intro.txt")}";""",
        $"""let ActualFile = @"{Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", "Inputs", "actual.txt")}";"""
    };
    File.WriteAllLines(Path.Combine(fsFolder,"Program.fs"), inputLines);
}
if (Directory.GetFiles(csFolder).Length < 1) {
    var psi = new ProcessStartInfo() {
        FileName = "dotnet",
        WorkingDirectory = csFolder,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        CreateNoWindow = true,
        UseShellExecute = false,
        Arguments = """new console -lang="C#" --use-program-main"""
    };
    var process = Process.Start(psi);
    process?.WaitForExit();
    Console.WriteLine("Created C# sln");
    Console.WriteLine("Creating .gitignores");
    File.WriteAllLines(Path.Combine(csFolder, ".gitignore"), gitIgnoreLines);
    Console.WriteLine("Adding input file constants");
    var inputLines = new List<string>() {
        $"""const string IntroFile = @"{Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", "Inputs", "intro.txt")}";""",
        $"""const string ActualFile = @"{Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", "Inputs", "actual.txt")}";"""
    };
    File.AppendAllLines(Path.Combine(csFolder,"Program.cs"), inputLines);

}







Console.WriteLine("Done!");
Console.ReadLine();