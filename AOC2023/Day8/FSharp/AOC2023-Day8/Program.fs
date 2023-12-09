open System
open System.Collections.Generic
open System.IO

let IntroFile = @"D:\AdventOfCodeAllYears\AOC2023\Day8\Inputs\intro.txt";
let ActualFile = @"D:\AdventOfCodeAllYears\AOC2023\Day8\Inputs\actual.txt";

type Node = {
    root: string
    left: string
    right: string
    mutable steps: Int64
}

type LineType =
    | Blank
    | NodeLine
    | DirLine
    

let GetLineType(line:string) =
    let lineType =
        if line.Contains '=' then
            LineType.NodeLine
        elif line.Trim().Length < 1 then
            LineType.Blank
        else LineType.DirLine
    lineType

let LineList file =
    File.ReadAllLines file

let ParseLines(lines:array<string>, lineType:LineType) =
    lines |> Array.where(fun line -> GetLineType(line) = lineType) |> Array.map(_.Trim()) |> Array.toList

let ParseNodeFromString(text:string) =
    let root = text.Split '=' |> Seq.map(_.Trim()) |>Seq.head
    let directions = text.Split '=' |> Seq.tail |> Seq.map(fun dir -> dir.Trim().Trim('(').Trim(')')) |> Seq.toList
    let left = directions.Head.Split ", " |> Seq.head
    let right = directions.Head.Split ", " |> Seq.tail |> Seq.head
    {root = root; left = left; right = right; steps = 0; }


let PartOne(file:string) =
    let lines = LineList file
    let dirLine = ParseLines(lines, LineType.DirLine).Head |> Seq.toList
    let nodeLines = ParseLines(lines, LineType.NodeLine) |> List.map(ParseNodeFromString)
    let mutable currentNode = nodeLines |> List.find(fun n -> n.root.Equals("AAA"))
    let mutable steps = 0
    while not (currentNode.root.Equals("ZZZ")) do
        for dir in dirLine do
            match dir with
            | 'L' -> currentNode <- nodeLines |> List.find(fun x -> x.root = currentNode.left)
            | 'R' -> currentNode <- nodeLines |> List.find(fun x -> x.root = currentNode.right)
            steps <- steps + 1
    steps


let GCF(x,y) =
    let mutable a:Int64 = x
    let mutable b:Int64 = y
    while not(b = 0) do
        let temp = b
        b <- a % b
        a <- temp
    a


let LCM x y =
    (x / GCF(x,y)) * y
    

let PartTwo(file:string) =
    let lines = LineList file
    let dirLine = ParseLines(lines, LineType.DirLine).Head |> Seq.toList
    let nodeLines = ParseLines(lines, LineType.NodeLine) |> List.map(ParseNodeFromString)
    let mutable currentNodes = nodeLines |> List.filter(fun n -> n.root |> Seq.last = 'A')
    for x in 0..currentNodes.Length - 1 do
        let mutable cNode = currentNodes[x]
        while not (cNode.root |> Seq.last = 'Z') do
            for dir in dirLine do
                match dir with
                | 'L' -> cNode <- nodeLines |> List.find(fun n -> n.root = cNode.left)
                | 'R' -> cNode <- nodeLines |> List.find(fun n -> n.root = cNode.right)
                currentNodes[x].steps <- currentNodes[x].steps + 1L
    currentNodes |> List.map(_.steps) |> List.reduce(LCM) 




[<EntryPoint>]
let main(args) =
    printfn $"Intro: %d{PartOne(IntroFile)}" 
    printfn $"Part One: %d{PartOne(ActualFile)}" 
    printfn $"Part Two: %d{PartTwo(ActualFile)}" 
    0