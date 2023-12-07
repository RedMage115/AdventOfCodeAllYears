using System.Text;

namespace AOC2023_Day7;

class Program
{
    const string IntroFile = @"D:\AdventOfCodeAllYears\AOC2023\Day7\Inputs\intro.txt";
    const string ActualFile = @"D:\AdventOfCodeAllYears\AOC2023\Day7\Inputs\actual.txt";
    static void Main(string[] args)
    {
        Console.WriteLine($"Intro: {PartOne(IntroFile)}");
        Console.WriteLine($"Part One: {PartOne(ActualFile)}");
        Console.WriteLine($"Part Two: {PartTwo(ActualFile)}");
    }

    static long PartOne(string file) {
        var lines = File.ReadAllLines(file);
        var hands = new List<Hand>();
        var cardValues = new List<char>(){'2','3','4','5','6','7','8','9','T','J','Q','K','A'};
        foreach (var line in lines) {
            var split = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var bid = long.Parse(split.Last());
            var cards = split.First().ToList();
            var val = new List<int>();
            foreach (var card in cards) {
                var v = cardValues.FindIndex(c => c == card);
                val.Add(v+1);
            }
            hands.Add(new Hand() {
                Bid = bid,
                Cards = cards,
                CardValues = val
            });
        }

        foreach (var hand in hands) {
            var counts = new Dictionary<char, int>();
            foreach (var card in hand.Cards) {
                if (counts.TryGetValue(card, out _)) {
                    counts[card] += 1;
                }
                else {
                    counts.Add(card, 1);
                }
            }

            if (counts.Any(c => c.Value == 5)) {
                hand.HandType = HandType.FiveOfAKind;
            }
            else if (counts.Any(c => c.Value == 4)) {
                hand.HandType = HandType.FourOfAKind;
            }
            else if (counts.Any(c => c.Value == 3) && counts.Any(c => c.Value == 2)) {
                hand.HandType = HandType.FullHouse;
            }
            else if (counts.Any(c => c.Value == 3)) {
                hand.HandType = HandType.ThreeOfAKind;
            }
            else if (counts.Count(c => c.Value == 2) == 2) {
                hand.HandType = HandType.TwoPair;
            }
            else if (counts.Count(c => c.Value == 2) == 1) {
                hand.HandType = HandType.OnePair;
            }
            else {
                hand.HandType = HandType.HighCard;
            }
        }

        var lists = new List<List<Hand>>();
        
        lists.Add(hands.Where(h => h.HandType == HandType.FiveOfAKind).ToList());
        lists.Add(hands.Where(h => h.HandType == HandType.FourOfAKind).ToList());
        lists.Add(hands.Where(h => h.HandType == HandType.FullHouse).ToList());
        lists.Add(hands.Where(h => h.HandType == HandType.ThreeOfAKind).ToList());
        lists.Add(hands.Where(h => h.HandType == HandType.TwoPair).ToList());
        lists.Add(hands.Where(h => h.HandType == HandType.OnePair).ToList());
        lists.Add(hands.Where(h => h.HandType == HandType.HighCard).ToList());
        
        foreach (var list in lists) {
            list.Sort(Comparison);
        }
        
        lists.Where(l => l.Count > 0).ToList().Sort((listA, listB) => listA.First().HandType - listB.First().HandType);
        
        var finalLists = new List<Hand>();
        foreach (var list in lists) {
            finalLists.AddRange(list);
        }
        finalLists.Reverse();
        for (var i = finalLists.Count - 1; i >= 0; i--) {
            finalLists[i].Rank = i+1;
        }

        long sum = 0;
        foreach (var hand in finalLists) {
            Console.WriteLine(hand);
            Console.WriteLine($"{hand.Rank} * {hand.Bid}");
            sum += hand.Rank * hand.Bid;
        }
        
        return sum;
    }
    
    static long PartTwo(string file) {
        var lines = File.ReadAllLines(file);
        var hands = new List<Hand>();
        var cardValues = new List<char>(){'J','2','3','4','5','6','7','8','9','T','Q','K','A'};
        foreach (var line in lines) {
            var split = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var bid = long.Parse(split.Last());
            var cards = split.First().ToList();
            var val = new List<int>();
            foreach (var card in cards) {
                var v = cardValues.FindIndex(c => c == card);
                val.Add(v+1);
            }
            hands.Add(new Hand() {
                Bid = bid,
                Cards = cards,
                CardValues = val
            });
        }

        foreach (var hand in hands) {
            var counts = new Dictionary<char, int>();
            foreach (var card in hand.Cards) {
                if (counts.TryGetValue(card, out _)) {
                    counts[card] += 1;
                }
                else {
                    counts.Add(card, 1);
                }
            }

            if (counts.Count > 1) {
                counts.Remove('J', out var jokers);
                (char car,int cnt) maxC = ('x', 0);
                foreach (var count in counts) {
                    if (count.Value > maxC.cnt) {
                        maxC = (count.Key, count.Value);
                    }
                }

                counts[maxC.car] += jokers;
            }
            
            
            if (counts.Any(c => c.Value >= 5)) {
                hand.HandType = HandType.FiveOfAKind;
            }
            else if (counts.Any(c => c.Value >= 4)) {
                hand.HandType = HandType.FourOfAKind;
            }
            else if (counts.Any(c => c.Value >= 3) && counts.Any(c => c.Value == 2)) {
                hand.HandType = HandType.FullHouse;
            }
            else if (counts.Any(c => c.Value >= 3)) {
                hand.HandType = HandType.ThreeOfAKind;
            }
            else if (counts.Count(c => c.Value >= 2) == 2) {
                hand.HandType = HandType.TwoPair;
            }
            else if (counts.Count(c => c.Value >= 2) == 1) {
                hand.HandType = HandType.OnePair;
            }
            else {
                hand.HandType = HandType.HighCard;
            }
        }

        var lists = new List<List<Hand>>();
        
        lists.Add(hands.Where(h => h.HandType == HandType.FiveOfAKind).ToList());
        lists.Add(hands.Where(h => h.HandType == HandType.FourOfAKind).ToList());
        lists.Add(hands.Where(h => h.HandType == HandType.FullHouse).ToList());
        lists.Add(hands.Where(h => h.HandType == HandType.ThreeOfAKind).ToList());
        lists.Add(hands.Where(h => h.HandType == HandType.TwoPair).ToList());
        lists.Add(hands.Where(h => h.HandType == HandType.OnePair).ToList());
        lists.Add(hands.Where(h => h.HandType == HandType.HighCard).ToList());
        
        foreach (var list in lists) {
            list.Sort(Comparison);
        }
        
        lists.Where(l => l.Count > 0).ToList().Sort((listA, listB) => listA.First().HandType - listB.First().HandType);
        
        var finalLists = new List<Hand>();
        foreach (var list in lists) {
            finalLists.AddRange(list);
        }
        finalLists.Reverse();
        for (var i = finalLists.Count - 1; i >= 0; i--) {
            finalLists[i].Rank = i+1;
        }

        long sum = 0;
        foreach (var hand in finalLists) {
            Console.WriteLine(hand);
            Console.WriteLine($"{hand.Rank} * {hand.Bid}");
            sum += hand.Rank * hand.Bid;
        }
        
        return sum;
    }

    private static int Comparison(Hand x, Hand y) {
        for (var i = 0; i < x.CardValues.Count; i++) {
            if (x.CardValues[i] == y.CardValues[i]) continue;
            if (x.CardValues[i] != y.CardValues[i]) {
                return y.CardValues[i] - x.CardValues[i];
            }
        }

        return 0;
    }
}


internal class Hand {
    public long Bid { get; set; }
    public List<char> Cards { get; set; } = new List<char>();
    public long Rank { get; set; }
    public List<int> CardValues { get; set; } = new List<int>();

    public HandType HandType { get; set; }

    public override string ToString() {
        var s = "";
        foreach (var c in Cards) {
            s += c;
        }
        return $"{s} {CardValues.First()} {Rank} {HandType} {Bid}";
    }
}

internal enum HandType {
    FiveOfAKind,
    FourOfAKind,
    FullHouse,
    ThreeOfAKind,
    TwoPair,
    OnePair,
    HighCard,
}