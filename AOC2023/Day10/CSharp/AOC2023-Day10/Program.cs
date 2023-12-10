using System.Text;
using System.Threading.Tasks.Dataflow;

namespace AOC2023_Day10;

class Program
{
    const string IntroFile = @"D:\AdventOfCodeAllYears\AOC2023\Day10\Inputs\intro.txt";
    const string IntroFile2 = @"D:\AdventOfCodeAllYears\AOC2023\Day10\Inputs\intro2.txt";
    const string IntroFile3 = @"D:\AdventOfCodeAllYears\AOC2023\Day10\Inputs\intro3.txt";
    const string ActualFile = @"D:\AdventOfCodeAllYears\AOC2023\Day10\Inputs\actual.txt";
    const string ActualFile2 = @"D:\AdventOfCodeAllYears\AOC2023\Day10\Inputs\output.txt";
    static void Main(string[] args)
    {
        //Console.WriteLine($"Intro: {PartOne(IntroFile)}");
        //Console.WriteLine($"Intro2: {PartOne(IntroFile2)}");
        //Console.WriteLine($"Part One: {PartOne(ActualFile)}");
        Console.WriteLine($"Part Two: {PartTwo(IntroFile3)}");
        
    }

    static int PartOne(string file) {
        var lines = File.ReadAllLines(file);
        var grid = new Dictionary<(int row, int col), char>();
        var row = 0;
        var col = 0;
        foreach (var line in lines) {
            foreach (var pipe in line) {
                if (pipe == '.') {
                    col++;
                    continue;
                }
                grid.Add((row, col),pipe);
                col++;
            }

            col = 0;
            row++;
        }

        (int row, int col) startPos = (0,0);

        foreach (var kvp in grid) {
            if (kvp.Value == 'S') {
                startPos = kvp.Key;
            }
        }
        Console.WriteLine($"Start Pos: {startPos.row},{startPos.col}");
        var looped = false;
        var lastPos = (0, 0);
        var currentPos = startPos;
        var currentPipe = grid[startPos];
        var steps = 0;
        var actualLoop = new Dictionary<(int row, int col), char>();
        while (!looped) {
            var searchArea = new List<(int row, int col)>() {
                (currentPos.row, currentPos.col+1),
                (currentPos.row, currentPos.col-1),
                (currentPos.row+1, currentPos.col),
                (currentPos.row-1, currentPos.col),
            };
            var foundPipes = grid.Where(kvp => searchArea.Contains(kvp.Key) && kvp.Value != '.' && kvp.Key != lastPos).ToList();
            var validPipes =
                foundPipes.Where(p => IsValidMove(currentPipe,GetDirectionFromPipes(currentPos,p.Key) , p.Value));
            
            lastPos = currentPos;
            currentPos = validPipes.First().Key;
            Console.WriteLine($"Going from {lastPos} to {currentPos}");
            currentPipe = grid[currentPos];
            actualLoop.Add(currentPos, currentPipe);
            steps++;
            if (currentPipe == 'S') {
                looped = true;
            }
        }

        var sb = new StringBuilder();

        for (int r = 0; r < grid.Last().Key.row + 2; r++) {
            for (int c = 0; c < grid.Last().Key.col + 2; c++) {
                if (actualLoop.TryGetValue((r, c), out var found)) {
                    sb.Append(found);
                }
                else {
                    sb.Append('.');
                }
            }

            sb.Append('\n');
        }
        File.WriteAllText(@"D:\AdventOfCodeAllYears\AOC2023\Day10\Inputs\output.txt", sb.ToString());
        return steps / 2;
    }

    static int PartTwo(string file) {
        var lines = File.ReadAllLines(file);
        var grid = new Dictionary<Position, Pipe>();
        var row = 0;
        foreach (var line in lines) {
            var col = 0;
            foreach (var pipe in line) {
                grid.Add(new Position(col, row),new Pipe(pipe, col < 1 || row < 1));
                col++;
            }
            row++;
        }

        var enclosedPipes = new Dictionary<Position, Pipe>();
        Console.WriteLine($"{grid.Last().Key.XPos}, {grid.Last().Key.YPos}");
        for (int i = 0; i < 10; i++) {
            for (var y = 0; y < grid.Last().Key.YPos; y++) {
                for (var x = 0; x < grid.Last().Key.XPos; x++) {
                    var currentPos = new Position(x, y);
                    var checkPositions = new List<Position>() {
                        new(x, y),
                        new(x + 1, y),
                        new(x - 1, y),
                        new(x, y - 1),
                        new(x, y - 1),
                    };
                    
                    if (grid.TryGetValue(currentPos, out var currentPipe)) {
                        if (currentPipe.Checked) {
                            continue;
                        }
                        if (currentPipe.PipeChar == '.') {
                            if (currentPos.XPos == 0) {
                                currentPipe.Open = true;
                            }
                            else if (currentPos.YPos == 0) {
                                currentPipe.Open = true;
                            }
                            else if (currentPos.XPos == grid.Last().Key.XPos) {
                                currentPipe.Open = true;
                            }
                            else if (currentPos.YPos == grid.Last().Key.YPos) {
                                currentPipe.Open = true;
                            }
                            else if (grid.Where(p => checkPositions.Contains(p.Key)).Any(u => u.Value.Open)) {
                                currentPipe.Open = true;
                            }
                            else {
                                currentPipe.Open = false;
                            }
                        }
                        else {
                            grid[currentPos].Open = false;
                            grid[currentPos].Checked = true;
                        }
                    }
                }
            }
        }


        foreach (var pipe in grid) {
            Console.WriteLine($"[{pipe.Key.XPos},{pipe.Key.YPos}] {pipe.Value.PipeChar} {pipe.Value.Open}");
        }
        var sb = new StringBuilder();

        for (int r = 0; r < grid.Last().Key.YPos + 1; r++) {
            for (int c = 0; c < grid.Last().Key.XPos + 1; c++) {
                if (grid.TryGetValue(new Position(c, r), out var pipe)) {
                    if (pipe.Open) {
                        sb.Append('X');
                    }
                    else {
                        sb.Append(pipe.PipeChar);
                    }
                }
                else {
                    sb.Append('?');
                }
            }

            sb.Append('\n');
        }
        File.WriteAllText(@"D:\AdventOfCodeAllYears\AOC2023\Day10\Inputs\output2.txt", sb.ToString());
        
        return grid.Where(p => p.Value.PipeChar == '.').Count(p => !p.Value.Open);
    }
    
    internal struct Position {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public Position(int xPos, int yPos) {
            XPos = xPos;
            YPos = yPos;
        }
    }
    
    internal class Pipe {
        public char PipeChar { get; set; }
        public bool Open { get; set; }
        public bool Checked { get; set; } = false;
        
        public Pipe(char pipeChar) {
            PipeChar = pipeChar;
            Open = false;
        }
        public Pipe(char pipeChar, bool open) {
            PipeChar = pipeChar;
            Open = open;
        }
    }
    
    static Direction GetDirectionFromPipes((int row, int col) currentPosition, (int row, int col) targetPosition) {
        if (currentPosition.col == targetPosition.col) {
            if (currentPosition.row < targetPosition.row) {
                return Direction.South;
            }
            else {
                return Direction.North;
            }
        }
        else {
            if (currentPosition.col < targetPosition.col) {
                return Direction.East;
            }
            return Direction.West;
        }
    }
    

    static bool IsValidMove(char currentPipe, Direction direction, char targetPipe) {
        var validChars = new List<char>();
        if (currentPipe == 'S') {
            switch (direction) {
                case Direction.North:
                    validChars.AddRange(new []{'|','F','7'});
                    break;
                case Direction.South:
                    validChars.AddRange(new []{'|','L','J'});
                    break;
                case Direction.East:
                    validChars.AddRange(new []{'-','J','7'});
                    break;
                case Direction.West:
                    validChars.AddRange(new []{'-','F','L'});
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
        else if (currentPipe == '|') {
            switch (direction) {
                case Direction.North:
                    validChars.AddRange(new []{'S','F','7','|'});
                    break;
                case Direction.South:
                    validChars.AddRange(new []{'S','L','J','|'});
                    break;
                case Direction.East:
                    break;
                case Direction.West:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
        else if (currentPipe == '-') {
            switch (direction) {
                case Direction.North:
                    break;
                case Direction.South:
                    break;
                case Direction.East:
                    validChars.AddRange(new []{'S','J','7','-'});
                    break;
                case Direction.West:
                    validChars.AddRange(new []{'S','L','F','-'});
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
        else if (currentPipe == 'F') {
            switch (direction) {
                case Direction.North:
                    break;
                case Direction.South:
                    validChars.AddRange(new []{'S','J','|','L'});
                    break;
                case Direction.East:
                    validChars.AddRange(new []{'S','J','7','-'});
                    break;
                case Direction.West:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
        else if (currentPipe == 'L') {
            switch (direction) {
                case Direction.North:
                    validChars.AddRange(new []{'S','|','F','7'});
                    break;
                case Direction.South:
                    break;
                case Direction.East:
                    validChars.AddRange(new []{'S','J','7','-'});
                    break;
                case Direction.West:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
        else if (currentPipe == '7') {
            switch (direction) {
                case Direction.North:
                    break;
                case Direction.South:
                    validChars.AddRange(new []{'S','|','L','J'});
                    break;
                case Direction.East:
                    break;
                case Direction.West:
                    validChars.AddRange(new []{'S','L','F','-'});
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
        else if (currentPipe == 'J') {
            switch (direction) {
                case Direction.North:
                    validChars.AddRange(new []{'S','|','F','7'});
                    break;
                case Direction.South:
                    break;
                case Direction.East:
                    break;
                case Direction.West:
                    validChars.AddRange(new []{'S','L','F','-'});
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
        
        return validChars.Contains(targetPipe);
    }
    
    
    
}

internal enum Direction {
    North,South,East,West
}