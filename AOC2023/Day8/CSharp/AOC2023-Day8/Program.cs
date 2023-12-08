namespace AOC2023_Day8;

static class Program
{
    const string IntroFile = @"D:\AdventOfCodeAllYears\AOC2023\Day8\Inputs\intro.txt";
    const string IntroFile2 = @"D:\AdventOfCodeAllYears\AOC2023\Day8\Inputs\intro2.txt";
    const string ActualFile = @"D:\AdventOfCodeAllYears\AOC2023\Day8\Inputs\actual.txt";

    static void Main(string[] args)
    {
        //Console.WriteLine($"Intro: {PartOne(IntroFile)}");
        //Console.WriteLine($"Part One: {PartOne(ActualFile)}");
        Console.WriteLine($"Part Two: {PartTwo(ActualFile)}");
    }

    static long PartOne(string file) {
        var lines = File.ReadAllLines(file);
        var directions = lines.First();
        var nodeList = new List<Node>();
        foreach (var line in lines) {
            if (string.IsNullOrWhiteSpace(line)) continue;
            if (!line.Contains('=')) continue;
            var split = line.Split('=',
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var root = split.First();
            var dests = split.Last().Split(", ").Select(s => s.Trim(new []{'(',')'})).ToList();
            nodeList.Add(new Node() {
                Root = root,
                Left = dests.First(),
                Right = dests.Last()
            });
        }

        foreach (var node in nodeList) {
            Console.WriteLine(node);
        }

        Console.WriteLine("------------------------------------------");
        long steps = 0;
        var currentNode = nodeList.First(n => n.Root == "AAA");
        while (currentNode.Root != "ZZZ") {
            foreach (var direction in directions) {
                Console.WriteLine($"Moving {direction}");
                Console.WriteLine(currentNode);
                if (currentNode == null) throw new Exception();
                switch (direction) {
                    case 'L':
                        currentNode = nodeList.Find(n => n.Root == currentNode.Left);
                        break;
                    case 'R':
                        currentNode = nodeList.Find(n => n.Root == currentNode.Right);
                        break;
                    default:
                        break;
                }
                if (currentNode == null) throw new Exception();
                steps++;
            
                if (currentNode.Root == "ZZZ") break;
            }
        }
        return steps;
    }
    
    static long PartTwo(string file) {
        var lines = File.ReadAllLines(file);
        var directions = lines.First();
        var nodeList = new List<Node>();
        foreach (var line in lines) {
            if (string.IsNullOrWhiteSpace(line)) continue;
            if (!line.Contains('=')) continue;
            var split = line.Split('=',
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var root = split.First();
            var dests = split.Last().Split(", ").Select(s => s.Trim(new []{'(',')'})).ToList();
            nodeList.Add(new Node() {
                Root = root,
                Left = dests.First(),
                Right = dests.Last()
            });
        }

        foreach (var node in nodeList) {
            Console.WriteLine(node);
        }
        
        Console.WriteLine("------------------------------------------");
        var currentNodes = nodeList.Where(n => n.Root.Last() == 'A').ToList();
        for (var i = 0; i < currentNodes.Count; i++) {
            long stepsReq = 0;
            var workingNode = currentNodes[i];
            while (workingNode.Root.Last() != 'Z') {
                foreach (var direction in directions) {
                    switch (direction) {
                        case 'L':
                            workingNode = nodeList.First(n => n.Root == workingNode.Left);
                            break;
                        case 'R':
                            workingNode = nodeList.First(n => n.Root == workingNode.Right);
                            break;
                        default:
                            break;
                    }
                    stepsReq++;
                    if (workingNode.Root.Last() == 'Z') {
                        currentNodes[i].StepsReq = stepsReq;
                        break;
                    }
                }
            }
        }
        

        var one = currentNodes[0].StepsReq;
        var two = currentNodes[1].StepsReq;
        var three = currentNodes[2].StepsReq;
        var four = currentNodes[3].StepsReq;
        var five = currentNodes[4].StepsReq;
        var six = currentNodes[5].StepsReq;


        var calc1 = LCM(five, six);
        var calc2 = LCM(four,calc1);
        var calc3 = LCM(three,calc2);
        var calc4 = LCM(two, calc3);
        var calc5 = LCM(one,calc4);
        
        return calc5;
    }
    static long GCF(long a, long b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static long LCM(long a, long b)
    {
        return (a / GCF(a, b)) * b;
    }
}

internal class Node {
    public string Root { get; set; } = "";
    public string Left { get; set; } = "";
    public string Right { get; set; } = "";
    public long StepsReq { get; set; }

    public override string ToString() {
        return $"{Root} = {Left} | {Right}";
    }
}