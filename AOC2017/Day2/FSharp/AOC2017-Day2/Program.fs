open System
open System.IO

let IntroFile = @"D:\AdventOfCode\AOC2017\Day2\Inputs\intro.txt";
let ActualFile = @"D:\AdventOfCode\AOC2017\Day2\Inputs\actual.txt"


let ToInt(s: string) =
    s |> int
let ListToInt(s:string[]) =
    s |> Seq.map(ToInt)

let GetMin(n: seq<int>) =
    n |> Seq.min
    
let GetMax(n: seq<int>) =
    n |> Seq.max
 
let ParseLine(line:string) =
    let split = line.Split('\t')
    let nums = ListToInt(split)
    let max = GetMax(nums)
    let min = GetMin(nums)
    max - min
    
 
let Intro() =
    let lines = File.ReadAllLines(IntroFile)
    let mutable sum = 0
    for i = 0 to lines.Length - 1 do
        sum <- sum + ParseLine(lines[i])
    sum
  
let PartOne() =
    let lines = File.ReadAllLines(ActualFile)
    let mutable sum = 0
    for i = 0 to lines.Length - 1 do
        sum <- sum + ParseLine(lines[i])
    sum      
            
    
let Part2 =
    let lines = File.ReadAllLines(ActualFile)
    let answer = seq {
        for line in lines do
            let nums = ListToInt(line.Split('\t'))
            for x in nums do
            for y in nums do
                if x <> y && x % y  = 0 then  x / y else 0
    }
    answer |> Seq.sum


[<EntryPoint>]
let main(args) =
    Intro() |> printfn "%d"
    PartOne() |> printfn "%d"
    Part2 |> printfn "%d"
    0