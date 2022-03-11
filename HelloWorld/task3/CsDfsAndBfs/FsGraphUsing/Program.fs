// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
open System

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let a = CsDfsAndBfs.Entities.Graph<int>(10)
    a.AddEdge(0, 1)
    a.AddEdge(1, 2)
    a.ChangeVertex(0, 10)
    a.ChangeVertex(1, 20)
    a.ChangeVertex(2, 50)
    let twiceOp = CsDfsAndBfs.Tools.TwiceOperation()
    let newGraph = CsDfsAndBfs.Services.Algorithms.Bfs(a, 0, twiceOp)
    let outputOp = CsDfsAndBfs.Tools.OutputOperation()
    CsDfsAndBfs.Services.Algorithms.Dfs(newGraph, 0, outputOp)
    let message = from "F#" // Call the function
    printfn "Hello world %s" message
    0 // return an integer exit code