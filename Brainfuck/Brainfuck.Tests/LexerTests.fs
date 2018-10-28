namespace Tests

open NUnit.Framework
open Brainfuck.Interpreter.Lexer
open NUnit.Framework
open NUnit.Framework
open NUnit.Framework

[<TestFixture>]
type ``Lexer recognizes tokens`` () =
    let lexer = lex

    [<Test>]
    member test.``+ is increment`` () =
        CollectionAssert.AreEqual([IncrToken], lexer "+")

    [<Test>]
    member test.``- is decrement`` () =
        CollectionAssert.AreEqual([DecrToken], lexer "-")
    [<Test>]
    member test.``> is move-right`` () =
        CollectionAssert.AreEqual([MoveRightToken], lexer ">")
    [<Test>]
    member test.``less-than is move-left`` () =
        CollectionAssert.AreEqual([MoveLeftToken], lexer "<")

    [<Test>]
    member test.``dot is write`` () =
        CollectionAssert.AreEqual([WriteToken], lexer ".")
    [<Test>]
    member test.``, is read`` () =
        CollectionAssert.AreEqual([ReadToken], lexer ",")
    [<Test>]
    member test.``[ is loop-start`` () =
        CollectionAssert.AreEqual([LoopStartToken], lexer "[")
    [<Test>]
    member test.``] is loop-end`` () =
        CollectionAssert.AreEqual([LoopEndToken], lexer "]")
    
    [<Test>]
    member test.``other symbosl are ignores``() =
        CollectionAssert.AreEqual([IncrToken], lexer "comment on\n start + on end\n")

    [<Test>]
    member test.``recognizes multiple tokens``() =
        CollectionAssert.AreEqual(
            [IncrToken; LoopStartToken; DecrToken; LoopEndToken],
            lexer "+[-]")