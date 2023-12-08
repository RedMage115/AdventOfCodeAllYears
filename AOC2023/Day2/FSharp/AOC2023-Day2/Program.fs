namespace Aoc2023

open System
open System.IO
open System.Text.RegularExpressions
open Microsoft.FSharp.Core


module Day2 =
    type Round = {
        Red: int
        Green: int
        Blue: int
    }
    type Game = {
        Id: int
        Rounds: list<Round>
        Possible: bool
        MaxRed: int
        MaxGreen: int
        MaxBlue: int
    }
    
    
    
    let IntroFile = @"D:\AdventOfCodeAllYears\AOC2023\Day2\Inputs\intro.txt";
    let ActualFile = @"D:\AdventOfCodeAllYears\AOC2023\Day2\Inputs\actual.txt"
    
    let MaxBlue = 14
    let MaxRed = 12
    let MaxGreen = 13
    
    let RegexRed = Regex(@"\d+ red")
    let RegexBlue = Regex(@"\d+ blue")
    let RegexGreen = Regex(@"\d+ green")
    
    let mutable GameList:list<Game> = []

    
    let IsPossible(list:list<Round>) =
        list |> List.forall(fun x -> x.Blue <= MaxBlue && x.Green <= MaxGreen && x.Red <= MaxRed)
        
    let ParseRoundRed(round:string) =
        let split = round.Replace(" red", "")
        let trimmed = split.Trim()
        match trimmed.Length with
        | 0 -> 0
        | _ -> int trimmed
        
    let ParseRoundGreen(round:string) =
        let split = round.Replace(" green", "")
        let trimmed = split.Trim()
        match trimmed.Length with
        | 0 -> 0
        | _ -> int trimmed
    
    let ParseRoundBlue(round:string) =
        let split = round.Replace(" blue", "")
        let trimmed = split.Trim()
        match trimmed.Length with
        | 0 -> 0
        | _ -> int trimmed
        
        
       
        
        
    let PartOne(file:string) =
        let lines = File.ReadAllLines file
        for line in lines do
            let gameId = line.Split ':' |> Array.head |> fun x-> x.Split ' ' |> Array.last |> int
            let rounds = line.Split ':' |> Array.last |> fun x -> x.Split "; "
            let mutable roundList:list<Round> = []
            for round in rounds do
                let red = RegexRed.Match round |> _.Value
                let green = RegexGreen.Match round |> _.Value
                let blue = RegexBlue.Match round |> _.Value
                roundList <- {Red = ParseRoundRed red; Blue = ParseRoundBlue blue; Green = ParseRoundGreen green } :: roundList
            GameList <- {Id = gameId; Rounds = roundList; Possible = IsPossible(roundList); MaxGreen = 0; MaxBlue = 0; MaxRed = 0 } :: GameList
            GameList <- GameList |> List.distinctBy(_.Id)
        GameList |> List.where(_.Possible) |> List.sumBy(_.Id)
      
      
    let GetMaxRed(rounds:list<Round>) =
        rounds |> List.maxBy(_.Red)  |> _.Red
        
    let GetMaxGreen(rounds:list<Round>) =
        rounds |> List.maxBy(_.Green)  |> _.Green
        
    let GetMaxBlue(rounds:list<Round>) =
        rounds |> List.maxBy(_.Blue) |> _.Blue
      
    let PartTwo(file:string) =
        let lines = File.ReadAllLines file
        for line in lines do
            let gameId = line.Split ':' |> Array.head |> fun x-> x.Split ' ' |> Array.last |> int
            let rounds = line.Split ':' |> Array.last |> fun x -> x.Split "; "
            let mutable roundList:list<Round> = []
            for round in rounds do
                let red = RegexRed.Match round |> _.Value
                let green = RegexGreen.Match round |> _.Value
                let blue = RegexBlue.Match round |> _.Value
                roundList <- {Red = ParseRoundRed red; Blue = ParseRoundBlue blue; Green = ParseRoundGreen green } :: roundList
            GameList <- {Id = gameId; Rounds = roundList
                         Possible = IsPossible(roundList)
                         MaxGreen = GetMaxGreen roundList; MaxBlue = GetMaxBlue roundList; MaxRed = GetMaxRed roundList } :: GameList
            GameList <- GameList |> List.distinctBy(_.Id)
            GameList |> List.iter(fun s -> printfn $"%d{s.Id} %b{s.Possible}")
        GameList |> List.map(fun g -> g.MaxBlue * g.MaxRed * g.MaxGreen) |> List.sum
        
    
    
    [<EntryPoint>]
    let main(args) =
        printfn $"Intro: %d{PartOne(IntroFile)}"
        printfn $"Part One: %d{PartOne(ActualFile)}"
        printfn $"Part Two: %d{PartTwo(ActualFile)}"
        0
