using System.Text.RegularExpressions;

namespace AocDay2;

internal static class Day2 {
    private const string IntroFile = @"D:\AdventOfCode\AOC2023\Day2\Inputs\intro.txt";
    private const string ActualFile = @"D:\AdventOfCode\AOC2023\Day2\Inputs\actual.txt";

    public static void Main() {
        Console.WriteLine("Day 2");
        Console.WriteLine($"Intro: {Intro()} games possible");
        Console.WriteLine($"Part 1: {Part1()} games possible");
        Console.WriteLine($"Part 2: {Part2()} power of min possible cubes");
    }

    private static int Intro() {
        const int maxRed = 12;
        const int maxGreen = 13;
        const int maxBlue = 14;

        var lines = File.ReadAllLines(IntroFile);
        var games = new List<Game>();
        foreach (var line in lines) {
            var gameNum = int.Parse(line.Split(':').First().Split(' ').Last());
            var rounds = line.Split(':').Last().Split(';');
            var roundList = new List<Round>();
            foreach (var round in rounds) {
                roundList.Add(new Round {
                    BlueCount = GetBlue(round),
                    GreenCount = GetGreen(round),
                    RedCount = GetRed(round)
                });
            }

            games.Add(new Game {
                GameId = gameNum,
                Rounds = roundList
            });
        }

        foreach (var game in games) {
            foreach (var gameRound in game.Rounds) {
                if (gameRound.RedCount > maxRed) game.IsPossible = false;
                if (gameRound.GreenCount > maxGreen) game.IsPossible = false;
                if (gameRound.BlueCount > maxBlue) game.IsPossible = false;
            }
        }

        return games.Where(g => g.IsPossible).Sum(g => g.GameId);
    }

    private static int Part1() {
        const int maxRed = 12;
        const int maxGreen = 13;
        const int maxBlue = 14;

        var lines = File.ReadAllLines(ActualFile);
        var games = new List<Game>();
        foreach (var line in lines) {
            var gameNum = int.Parse(line.Split(':').First().Split(' ').Last());
            var rounds = line.Split(':').Last().Split(';');
            var roundList = new List<Round>();
            foreach (var round in rounds) {
                roundList.Add(new Round {
                    BlueCount = GetBlue(round),
                    GreenCount = GetGreen(round),
                    RedCount = GetRed(round)
                });
            }

            games.Add(new Game {
                GameId = gameNum,
                Rounds = roundList
            });
        }

        foreach (var game in games) {
            foreach (var gameRound in game.Rounds) {
                if (gameRound.RedCount > maxRed) game.IsPossible = false;
                if (gameRound.GreenCount > maxGreen) game.IsPossible = false;
                if (gameRound.BlueCount > maxBlue) game.IsPossible = false;
            }
        }

        return games.Where(g => g.IsPossible).Sum(g => g.GameId);
    }

    private static int Part2() {
        const int maxRed = 12;
        const int maxGreen = 13;
        const int maxBlue = 14;

        var lines = File.ReadAllLines(ActualFile);
        var games = new List<Game>();
        foreach (var line in lines) {
            var gameNum = int.Parse(line.Split(':').First().Split(' ').Last());
            var rounds = line.Split(':').Last().Split(';');
            var roundList = new List<Round>();
            foreach (var round in rounds) {
                roundList.Add(new Round {
                    BlueCount = GetBlue(round),
                    GreenCount = GetGreen(round),
                    RedCount = GetRed(round)
                });
            }

            games.Add(new Game {
                GameId = gameNum,
                Rounds = roundList
            });
        }

        foreach (var game in games) {
            foreach (var gameRound in game.Rounds) {
                if (gameRound.RedCount > maxRed) game.IsPossible = false;
                if (gameRound.GreenCount > maxGreen) game.IsPossible = false;
                if (gameRound.BlueCount > maxBlue) game.IsPossible = false;
            }
        }

        foreach (var game in games) {
            foreach (var gameRound in game.Rounds) {
                if (gameRound.RedCount > game.MinRed) game.MinRed = gameRound.RedCount;
                if (gameRound.GreenCount > game.MinGreen) game.MinGreen = gameRound.GreenCount;
                if (gameRound.BlueCount > game.MinBlue) game.MinBlue = gameRound.BlueCount;
            }
        }

        var sum = 0;
        foreach (var game in games) {
            var cnt = game.MinBlue * game.MinGreen * game.MinRed;
            sum += cnt;
        }


        return sum;
    }

    private static int GetRed(string roundText) {
        var regex = new Regex("[0-9]+ red");
        var match = regex.Match(roundText);
        return !match.Success ? 0 : int.Parse(match.Value.TrimEnd('r', 'e', 'd', ' '));
    }

    private static int GetGreen(string roundText) {
        var regex = new Regex("[0-9]+ green");
        var match = regex.Match(roundText);
        return !match.Success ? 0 : int.Parse(match.Value.TrimEnd('g', 'r', 'e', 'e', 'n', ' '));
    }

    private static int GetBlue(string roundText) {
        var regex = new Regex("[0-9]+ blue");
        var match = regex.Match(roundText);
        return !match.Success ? 0 : int.Parse(match.Value.TrimEnd('b', 'l', 'u', 'e', ' '));
    }
}

internal class Game {
    public int GameId { get; set; }
    public List<Round> Rounds { get; set; } = new();
    public bool IsPossible { get; set; } = true;

    public int MinRed { get; set; }
    public int MinGreen { get; set; }
    public int MinBlue { get; set; }
}

internal class Round {
    public int RedCount { get; set; }
    public int BlueCount { get; set; }
    public int GreenCount { get; set; }
}