namespace AOC2023

open System
open System.IO

module DaySix =

    let IntroFile = @"D:\AdventOfCodeAllYears\AOC2023\Day6\Inputs\intro.txt";
    let ActualFile = @"D:\AdventOfCodeAllYears\AOC2023\Day6\Inputs\actual.txt";

    let rec parseNumbers list results =
        match list with
        | head :: tail -> parseNumbers tail (Int32.Parse(head) :: results)
        | [] -> results

    
    
    
    let Intro =
        let lines = File.ReadAllLines IntroFile |> Seq.toList
        let res = lines.Head.Split ':'
                  |> Seq.tail
                  |> Seq.head
                  |> fun s -> s.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                              |> Seq.toList
                              |> parseNumbers
        res
        
    
    
    [<EntryPoint>]
    let main(args) =
        let i = Intro
        i |> Seq.iter(fun s -> printfn "%d" s)
        0