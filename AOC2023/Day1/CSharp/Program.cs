using System.Text.RegularExpressions;

namespace AOCCSharp;

static class AOC {
    private const string IntroFile = @"D:\AdventOfCode\AOC2023\Day1\Inputs\intro.txt";
    private const string InputFile = @"D:\AdventOfCode\AOC2023\Day1\Inputs\actual.txt";
    
    public static void Main() {
        //Console.WriteLine($"part One: {PartOne()}");
        Console.WriteLine($"part Two: {PartTwo()}");
    }

    private static int PartOne() {
        var input = File.ReadAllLines(InputFile);
        var total = 0;

        foreach (var line in input) {
            Console.WriteLine($"LINE: {line}");
            var num = "";
            for (var i = 0; i < line.Length; i++) {
                if (!int.TryParse(line.AsSpan(i, 1), out _)) continue;
                num+=line[i];
                break;
            }
            for (var i = line.Length - 1; i >= 0; i--) {
                if (!int.TryParse(line.AsSpan(i, 1), out _)) continue;
                num+=line[i];
                break;
            }
            Console.WriteLine($"RESULT: {num}");
            total += int.Parse(num);
            num = "";
        }
        
        
        return total;
    }
    private static int PartTwo() {
        var input = File.ReadAllLines(InputFile);
        var total = 0;
        
        foreach (var line in input) {
            if (line.Contains("qc1kcpnpqdthreeeightwoj")) {
                Console.WriteLine();
            }
            Console.WriteLine($"LINE: {line}");
            var num = RegexMe(line.ToLower());
            Console.WriteLine($"RESULT: {num}");
            total += int.Parse(num);
            num = "";
        }
        
        
        return total;
    }

    private static string RegexMe(string line) {
        var regex = new Regex(@"1|one|2|two|3|three|4|four|5|five|6|six|7|seven|8|eight|9|nine|0");
        var regex2 = new Regex(@"eighthree|oneight|twone|eightwo|1|one|2|two|3|three|4|four|5|five|6|six|7|seven|8|eight|9|nine|0");
        var matches = regex.Matches(line);
        var matches2 = regex2.Matches(line);
        var first = matches.First().Value;
        var last = matches2.Last().Value;

        if (!int.TryParse(first, out var firstNum)) {
            firstNum = GetNumFromString(first);
        }
        if (!int.TryParse(last, out var secondNum)) {
            secondNum = GetNumFromString(last);
        }
        
        return $"{firstNum}{secondNum}";
    }

    private static int GetNumFromString(string input) { 
        switch (input) {
            case "one":
                return 1;
            case "two":
                return 2;
            case "three":
                return 3;
            case "four":
                return 4;
            case "five":
                return 5;
            case "six":
                return 6;
            case "seven":
                return 7;
            case "eight":
                return 8;
            case "nine":
                return 9;
            case "eightwo":
                return 2;
            case "eighthree":
                return 3;
            case "oneight":
                return 8;
            case "twone":
                return 1;
            default:
                break;
        }

        return 0;
    }
    
}


