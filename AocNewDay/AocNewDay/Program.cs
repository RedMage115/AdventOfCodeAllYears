﻿using System.Diagnostics;

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
    "Kotlin",
    "Python",
    "Swift",
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
var jsFolder = Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", "JavaScript", $"AOC{year}-Day{day}");
var ktFolder = Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", "Kotlin", $"AOC{year}-Day{day}");
var swiftFolder = Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", "Swift", $"AOC{year}-Day{day}");
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
    ".out/*",
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

if (Directory.GetFiles(swiftFolder).Length < 1) {
    var psi = new ProcessStartInfo() {
        FileName = "swift",
        WorkingDirectory = swiftFolder,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        CreateNoWindow = true,
        UseShellExecute = false,
        Arguments = $"""package init --name AOC{year} --type executable"""
    };
    var process = Process.Start(psi);
    process?.WaitForExit();
    Console.WriteLine("Created Swift sln");
    Console.WriteLine("Creating .gitignores");
    File.WriteAllLines(Path.Combine(swiftFolder, ".gitignore"), gitIgnoreLines);
    Console.WriteLine("Adding input file constants");
    var inputLines = new List<string>() {
        $"""var IntroFile = "{Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", "Inputs", "intro.txt")}""",
        $"""var ActualFile = "{Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", "Inputs", "actual.txt")}"""
    };
    File.AppendAllLines(Path.Combine(swiftFolder,"Sources","main.swift"), inputLines);

}


if (Directory.GetFiles(jsFolder).Length < 1) {
    var inputLines = new List<string>() {
        """const fs = require('fs');""",
        $"""const IntroFile = String.raw`{Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", "Inputs", "intro.txt")}`;""",
        $"""const ActualFile = String.raw`{Path.Combine(aocRoot, $"AOC{year}", $"Day{day}", "Inputs", "actual.txt")}`;"""
    };
    File.AppendAllLines(Path.Combine(jsFolder,"main.js"), inputLines);
    Console.WriteLine("Created .js file");
    Console.WriteLine("Creating .gitignores");
    File.WriteAllLines(Path.Combine(jsFolder, ".gitignore"), gitIgnoreLines);
    Console.WriteLine("Adding input file constants");
}

if (Directory.GetFiles(ktFolder).Length < 1) {
    Console.WriteLine("Creating kotlin .gitignores");
    File.WriteAllLines(Path.Combine(ktFolder, ".gitignore"), gitIgnoreLines);
}

Console.WriteLine("Done!");
Console.ReadLine();