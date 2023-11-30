namespace AOC2023_Day4;

class Program
{
    const string IntroFile = @"D:\AdventOfCode\AOC2023\Day4\Inputs\intro.txt";
    const string ActualFile = @"D:\AdventOfCode\AOC2023\Day4\Inputs\actual.txt";
    static void Main(string[] args)
    {
        Console.WriteLine($"Intro: {Intro()}");
        Console.WriteLine($"Part 1: {PartOne()}");
        Console.WriteLine($"Part 2: {PartTwo()}");
    }

    static int Intro() {
        var lines = File.ReadAllLines(IntroFile);
        var games = new List<Card>();
        foreach (var line in lines) {
            var card = new Card();
            var split = line.Split(':');
            card.Id = int.Parse(split.First().Split(' ').Last());
            var game = split.Last().Split('|');
            var winning = game.First().Split(' ');
            foreach (var num in winning) {
                if (int.TryParse(num, out var x)) {
                    card.WinningNumbers.Add(x);
                }
            }
            var player = game.Last().Split(' ');
            foreach (var num in player) {
                if (int.TryParse(num, out var x)) {
                    card.PlayerNumbers.Add(x);
                }
            }
            games.Add(card);
        }

        foreach (var card in games) {
            foreach (var playerNumber in card.PlayerNumbers) {
                foreach (var winning in card.WinningNumbers) {
                    if (winning == playerNumber) {
                        card.Points = card.Points switch {
                            0 => 1,
                            _ => card.Points * 2
                        };
                    }
                }
            }
        }

        return games.Sum(g => g.Points);
    }
    static int PartOne() {
        var lines = File.ReadAllLines(ActualFile);
        var games = new List<Card>();
        foreach (var line in lines) {
            var card = new Card();
            var split = line.Split(':');
            card.Id = int.Parse(split.First().Split(' ').Last());
            var game = split.Last().Split('|');
            var winning = game.First().Split(' ');
            foreach (var num in winning) {
                if (int.TryParse(num, out var x)) {
                    card.WinningNumbers.Add(x);
                }
            }
            var player = game.Last().Split(' ');
            foreach (var num in player) {
                if (int.TryParse(num, out var x)) {
                    card.PlayerNumbers.Add(x);
                }
            }
            games.Add(card);
        }

        foreach (var card in games) {
            foreach (var playerNumber in card.PlayerNumbers) {
                foreach (var winning in card.WinningNumbers) {
                    if (winning == playerNumber) {
                        card.Points = card.Points switch {
                            0 => 1,
                            _ => card.Points * 2
                        };
                    }
                }
            }
        }

        return games.Sum(g => g.Points);
    }
    
    static int PartTwo() {
        var lines = File.ReadAllLines(ActualFile);
        var games = new List<Card>();
        foreach (var line in lines) {
            var card = new Card();
            var split = line.Split(':');
            card.Id = int.Parse(split.First().Split(' ').Last());
            var game = split.Last().Split('|');
            var winning = game.First().Split(' ');
            foreach (var num in winning) {
                if (int.TryParse(num, out var x)) {
                    card.WinningNumbers.Add(x);
                }
            }
            var player = game.Last().Split(' ');
            foreach (var num in player) {
                if (int.TryParse(num, out var x)) {
                    card.PlayerNumbers.Add(x);
                }
            }
            games.Add(card);
        }

        var loop = true;
        var y = 0;
        //Console.WriteLine(games.Count);
        //Console.WriteLine("-------------");
        while (loop) {
            var card = games[y];
            var wins = card.WinningNumbers.Count(p => card.PlayerNumbers.Contains(p));
            for (var i = 1; i <= wins; i++) {
                var id = card.Id + i;
                games.Add(games.First(c => c.Id == id));
            }
            
            //Console.WriteLine(games.Count);
            y++;
            if (games.Count <= y) {
                loop = false;
            }
        }

        //Console.WriteLine("-------------");
        //foreach (var card in games) {
            //Console.WriteLine($"{card.Id}");
        //}

        return games.Count;
    }
}

internal class Card {
    public int Id { get; set; }
    public List<int> WinningNumbers { get; set; } = new List<int>();
    public List<int> PlayerNumbers { get; set; } = new List<int>();
    public int Points { get; set; } = 0;
}