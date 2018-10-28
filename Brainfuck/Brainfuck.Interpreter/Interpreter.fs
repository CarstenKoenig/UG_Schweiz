[<AutoOpen>]
module Brainfuck.Interpreter.Interpreter

open Brainfuck.Interpreter.Lexer
open Brainfuck.Interpreter.SimpleParser
open Brainfuck.Interpreter.Memory
open Brainfuck.Interpreter.Parser

let private write (b : byte) =
  failwith "implement me"

let private read () =
  failwith "implement me"

let rec private interpretOneWith (mem : Memory) =
  failwith "implement me"

and private interpretWith (mem : Memory) (ast : AST seq) =
  failwith "implement me"

let interpret (input : string) =
  failwith "implement me"