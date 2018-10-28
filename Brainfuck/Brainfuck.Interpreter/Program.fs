namespace Brainfuck.Interpreter

module Main =
  open System
  open Brainfuck.Interpreter

  [<EntryPoint>]
  let main argv =

    IO.File.ReadAllText argv.[0]
    |> interpret
    |> function
      | Error err -> printfn "Error: %s" err
      | Ok ()     -> printfn "DONE"
    0 // return an integer exit code
