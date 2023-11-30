namespace AOC2017_Day1; 

static class Program {
    
    private const string Intro = @"D:\AdventOfCode\AOC2017\Day1\Inputs\intro.txt";
    private const string Actual = @"D:\AdventOfCode\AOC2017\Day1\Inputs\actual.txt";
    
    public static void Main() {
        Console.WriteLine($"Intro Sum: {PartIntro()}");
        Console.WriteLine($"Part One Sum: {PartOne()}");
        Console.WriteLine($"Part Two Sum: {PartTwo()}");
    }

    private static int PartIntro() {
        var text = File.ReadAllText(Intro);
        var sum = 0;
        for (var i = 0; i < text.Length-1; i++) {
            var cur = (int)char.GetNumericValue(text[i]);
            var next = (int)char.GetNumericValue(text[i+1]);
            if (cur == next) {
                sum += cur;
            }
        }

        if ((int)char.GetNumericValue(text.First()) == (int)char.GetNumericValue(text.Last())) {
            sum += (int)char.GetNumericValue(text.First());
        }

        return sum;
    }
    private static int PartOne() {
        var text = File.ReadAllText(Actual);
        var sum = 0;
        for (var i = 0; i < text.Length-1; i++) {
            var cur = (int)char.GetNumericValue(text[i]);
            var next = (int)char.GetNumericValue(text[i+1]);
            if (cur == next) {
                sum += cur;
            }
        }

        if ((int)char.GetNumericValue(text.First()) == (int)char.GetNumericValue(text.Last())) {
            sum += (int)char.GetNumericValue(text.First());
        }

        return sum;
    }
    
    private static int PartTwo() {
        var text = File.ReadAllText(Actual);
        var loop = text + text;
        var sum = 0;
        var half = text.Length / 2;
        for (var i = 0; i < text.Length; i++) {
            var cur = (int)char.GetNumericValue(loop[i]);
            var next = (int)char.GetNumericValue(loop[i+half]);
            if (cur == next) {
                sum += cur;
            }
        }
        return sum;
    }
    
}
