namespace AOC2023_Day3;

class Program
{
    const string IntroFile = @"D:\AdventOfCode\AOC2023\Day3\Inputs\intro.txt";
    const string ActualFile = @"D:\AdventOfCode\AOC2023\Day3\Inputs\actual.txt";
    static void Main(string[] args)
    {
        Console.WriteLine($"Intro: {Intro()}");
        Console.WriteLine($"Part One: {PartOne()}");
        Console.WriteLine($"Part Two: {PartTwo()}");
    }

    static int Intro() {
        var lines = File.ReadAllLines(IntroFile);
        var partPosList = new List<PartNumPos>();
        var symPosList = new List<SymbolPos>();
        for (var i = 0; i < lines.Length; i++) {
            //Console.WriteLine(lines[i]);
            var partPos = new PartNumPos() {
                YPos = i
            };
            for (var j = 0; j < lines[i].Length; j++) {
                var curChar = lines[i][j];
                //Console.WriteLine(curChar);
                if (char.IsDigit(curChar)) {
                    partPos.Number += curChar;
                    partPos.XPositions.Add(j);
                    continue;
                }
                if (curChar == '.') {
                    if (partPos.XPositions.Count > 0) {
                        partPosList.Add(partPos);
                    }
                    partPos = new PartNumPos() {
                        YPos = i
                    };
                    continue;
                }
                symPosList.Add(new SymbolPos() {
                    YPos = i,
                    XPos = j
                });
            }
        }

        var sum = 0;
        foreach (var partPos in partPosList) {
            foreach (var symbolPos in symPosList) {
                if (partPos.XPositions.Any(x => x == symbolPos.XPos || x == symbolPos.XPos + 1 || x == symbolPos.XPos - 1) && 
                    (partPos.YPos == symbolPos.YPos || partPos.YPos == symbolPos.YPos - 1 || partPos.YPos == symbolPos.YPos + 1)) {
                    sum += int.Parse(partPos.Number);
                    //Console.WriteLine($"Good: {partPos}");
                    break;
                }
                //Console.WriteLine($"Failed: {partPos}");
            }
        }
        
        return sum;
    }
    static long PartOne() {
        var lines = File.ReadAllLines(ActualFile).Select(l => l += '.').ToArray();
        var partPosList = new List<PartNumPos>();
        var symPosList = new List<SymbolPos>();
        for (var i = 0; i < lines.Length; i++) {
            //Console.WriteLine(lines[i]);
            var partPos = new PartNumPos() {
                YPos = i
            };
            for (var j = 0; j < lines[i].Length; j++) {
                var curChar = lines[i][j];
                //Console.WriteLine(curChar);
                if (char.IsDigit(curChar)) {
                    partPos.Number += curChar;
                    partPos.XPositions.Add(j);
                    continue;
                }
                else if (curChar == '.') {
                    if (partPos.XPositions.Count > 0) {
                        partPosList.Add(partPos);
                    }
                    partPos = new PartNumPos() {
                        YPos = i
                    };
                    continue;
                }
                else {
                    if (partPos.XPositions.Count > 0) {
                        partPosList.Add(partPos);
                    }
                    partPos = new PartNumPos() {
                        YPos = i
                    };
                    symPosList.Add(new SymbolPos() {
                        YPos = i,
                        XPos = j,
                        Symbol = curChar
                    });
                }
                
            }
        }

        long sum = 0;
        foreach (var partPos in partPosList) {
            foreach (var symbolPos in symPosList) {
                if (partPos.XPositions.Any(x => x == symbolPos.XPos) || partPos.XPositions.Any(x => x + 1 == symbolPos.XPos) || partPos.XPositions.Any(x => x - 1 == symbolPos.XPos)) {
                    if (symbolPos.YPos == partPos.YPos || symbolPos.YPos == partPos.YPos + 1 || symbolPos.YPos == partPos.YPos - 1) {
                        sum += long.Parse(partPos.Number);
                        break;
                    }
                }
                //Console.WriteLine($"Failed: {partPos}");
            }
        }
        
        return sum;
    }
    
    static long PartTwo() {
        var lines = File.ReadAllLines(ActualFile).Select(l => l += '.').ToArray();
        var partPosList = new List<PartNumPos>();
        var symPosList = new List<SymbolPos>();
        for (var i = 0; i < lines.Length; i++) {
            //Console.WriteLine(lines[i]);
            var partPos = new PartNumPos() {
                YPos = i
            };
            for (var j = 0; j < lines[i].Length; j++) {
                var curChar = lines[i][j];
                //Console.WriteLine(curChar);
                if (char.IsDigit(curChar)) {
                    partPos.Number += curChar;
                    partPos.XPositions.Add(j);
                    continue;
                }
                else if (curChar == '.') {
                    if (partPos.XPositions.Count > 0) {
                        partPosList.Add(partPos);
                    }
                    partPos = new PartNumPos() {
                        YPos = i
                    };
                    continue;
                }
                else {
                    if (partPos.XPositions.Count > 0) {
                        partPosList.Add(partPos);
                    }
                    partPos = new PartNumPos() {
                        YPos = i
                    };
                    symPosList.Add(new SymbolPos() {
                        YPos = i,
                        XPos = j,
                        Symbol = curChar
                    });
                }
                
            }
        }

        long sum = 0;
        foreach (var gear in symPosList.Where(s => s.Symbol == '*')) {
            var posList = new List<PartNumPos>();
            foreach (var partPos in partPosList) {
                if (partPos.YPos == gear.YPos || partPos.YPos + 1 == gear.YPos || partPos.YPos - 1 == gear.YPos) {
                    if (partPos.XPositions.Any(x => x == gear.XPos) || partPos.XPositions.Any(x => x + 1 == gear.XPos) || partPos.XPositions.Any(x => x - 1 == gear.XPos)) {
                        posList.Add(partPos);
                    }
                }
            }

            if (posList.Count != 2) continue;
            sum += int.Parse(posList.First().Number) * int.Parse(posList.Last().Number);
        }
    
        
        return sum;
    }


}

internal class SymbolPos {
    public int XPos { get; set; }
    public int YPos { get; set; }

    public char Symbol { get; set; }

    public override string ToString() {
        return $"{Symbol} {XPos} {YPos}";
    }
}

internal class PartNumPos {
    public string Number { get; set; } = "";
    public int YPos { get; set; }
    public List<int> XPositions { get; set; } = new List<int>();

    public override string ToString() {
        var xpos = "";
        foreach (var xPosition in XPositions) {
            xpos += xPosition;
        }
        return $"{YPos} {Number} {xpos}";
    }
}
