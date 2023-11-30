open System
open System.IO

let introPath = @"D:\AdventOfCode\AOC2017\Day1\Inputs\intro.txt"

let actualPath = @"D:\AdventOfCode\AOC2017\Day1\Inputs\actual.txt"

let ParseInt(c:char) =
    Double.Parse(c.ToString()) |> int

let Intro() =
    let text = File.ReadAllText(introPath)
    let len = text.Length - 1
    let loop = text + text
    let mutable sum = 0
    for i = 0 to len do
        if ParseInt(loop[i]) = ParseInt(loop[i+1]) then
            sum <- sum + ParseInt(loop[i])
    sum
    
    
let PartOne() =
    let text = File.ReadAllText(actualPath)
    let len = text.Length - 1
    let loop = text + text
    let mutable sum = 0
    for i = 0 to len do
        if ParseInt(loop[i]) = ParseInt(loop[i+1]) then
            sum <- sum + ParseInt(loop[i])
    sum
    
let PartTwo() =
    let text = File.ReadAllText(actualPath)
    let len = text.Length - 1
    let half = text.Length / 2
    let loop = text + text
    let mutable sum = 0
    for i = 0 to len do
        if ParseInt(loop[i]) = ParseInt(loop[i + half]) then
            sum <- sum + ParseInt(loop[i])
    sum
    
[<EntryPoint>]
let Main(args) =   
    Intro() |> printfn "Intro: %d" 
    PartOne() |> printfn "Part One: %d" 
    PartTwo() |> printfn "Part Two: %d" 
    0