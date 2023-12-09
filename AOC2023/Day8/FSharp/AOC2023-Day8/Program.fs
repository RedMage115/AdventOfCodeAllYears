open System.IO

let IntroFile = @"D:\AdventOfCodeAllYears\AOC2023\Day8\Inputs\intro.txt";
let ActualFile = @"D:\AdventOfCodeAllYears\AOC2023\Day8\Inputs\actual.txt";

type Node = {
    root: string
    left: string
    right: string
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
    {root = root; left = left; right = right; }


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



[<EntryPoint>]
let main(args) =
    printfn $"Intro: %d{PartOne(IntroFile)}" 
    printfn $"Part One: %d{PartOne(ActualFile)}" 
    0