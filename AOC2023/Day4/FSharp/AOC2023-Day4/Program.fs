namespace AOC2023

open System.IO

module DayFour =
    let IntroFile = @"D:\AdventOfCode\AOC2023\Day4\Inputs\intro.txt";
    let ActualFile = @"D:\AdventOfCode\AOC2023\Day4\Inputs\actual.txt"
    
    type Card = {
        id:int
        player: list<int>
        winNums: list<int>
        points: int
    }
    
    
    
    [<EntryPoint>]
    let Main(args) =
        0