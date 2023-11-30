
open System
open System.IO

let IntroFile = @"D:\AdventOfCode\AOC2023\Day1\Inputs\intro.txt"
let ActualFile = @"D:\AdventOfCode\AOC2023\Day1\Inputs\actual.txt"




let Part1() =
    let lines = File.ReadAllLines(ActualFile)
    let mutable sum = 0;
    for line in lines do
        let digits = line |> Seq.where(Char.IsDigit)
        let first = digits |> Seq.head
        let last = digits |> Seq.last
        let result = $"%c{first}%c{last}"
        sum <- sum +  int result
    sum    

let numberStrings = Map [("one", "o1e"); ("two", "t2o"); ("three", "thr3e"); ("four", "fo4r"); ("five", "fi5e"); ("six", "s6x"); ("seven", "sev7en"); ("eight", "eig8t"); ("nine", "ni9e");]
    

let ReplaceStr(s:string) =
    let mutable res = s
    for num in numberStrings do
        res <- res.Replace(num.Key, num.Value)
    res

let Part2() =
    let lines = File.ReadAllLines(ActualFile)
    let mutable sum = 0
    let edited = lines |> Seq.map(ReplaceStr)
    for r in edited do
        let digits = r |> Seq.where(Char.IsDigit)
        let first = digits |> Seq.head
        let last = digits |> Seq.last
        let result = $"%c{first}%c{last}"
        sum <- sum +  int result
    sum
        
             
    



[<EntryPoint>]
let main(args) =
    Part1() |> printfn "%d" 
    Part2() |> printfn "%d" 
    0
