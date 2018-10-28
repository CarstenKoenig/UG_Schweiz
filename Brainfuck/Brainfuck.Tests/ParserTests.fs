namespace Tests

open NUnit.Framework
open Brainfuck.Interpreter.Lexer
open Brainfuck.Interpreter.SimpleParser

[<Ignore("needs to be implemented")>]
type ``Parser tests`` () =
    let parse inp = 
      lex inp
      |> parse
      |> fun res -> printfn "%A" res; res
      |> function
          | Error err -> failwith err
          | Ok res -> printfn "%A" res; res

    [<Test>]
    member test.``+ is just Incr`` () =
      CollectionAssert.AreEqual([Incr], parse "+")

    [<Test>]
    member test.``loop is parsed``() =
      CollectionAssert.AreEqual
        ( [Loop [Decr]]
        , parse "[-]"
        )

    [<Test>]
    member test.``simple program is parsed``() =
      CollectionAssert.AreEqual
        ( [Incr; Incr; Loop [Decr; Write]]
        , parse "++[-.]"
        )