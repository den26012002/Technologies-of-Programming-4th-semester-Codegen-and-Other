// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
namespace FS
open System

module func =
// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

type Union = X of int | Y of string

type LoggingBuilder() =
    let log p = printfn "expression is %A" p

    member this.Bind(x, f) =
        log x
        f x

    member this.Return(x) =
        x

let printUnion union =
    match union with
    | X i -> printfn "%i" i
    | Y s -> printfn "%s" s
    | _ -> printfn "default"

let logSumOfSqrs a b =
    let logger = new LoggingBuilder()
    let loggedWorkflow =
        logger
            {
            let! x = a * a
            let! y = b * b
            let! z = x + y
            return z
            }
    loggedWorkflow

[<EntryPoint>]
let main argv =
    let message = "F#" |> from // Call the function
    printfn "Hello world %s" message
    let f = Union.Y "alkdfjs"

    f |> printUnion

    logSumOfSqrs 42 43

    0 // return an integer exit code