[<AutoOpen>]
module Brainfuck.Interpreter.Interpreter

open Brainfuck.Interpreter.Lexer
open Brainfuck.Interpreter.SimpleParser
open Brainfuck.Interpreter.Memory
open Brainfuck.Interpreter.Parser

let private write (b : byte) =
  printf "%c" (char b)

let private read () =
  byte <| System.Console.Read ()

let rec private interpretOneWith (mem : Memory) =
  function
  | Incr      -> mem.Incr ()
  | Decr      -> mem.Decr ()
  | MoveLeft  -> mem.MoveLeft ()
  | MoveRight -> mem.MoveRight ()
  | Write     -> write mem.CurrentValue
  | Read      -> mem.CurrentValue <- read ()
  | Loop ins  ->
    while mem.CurrentValue <> 0uy do
      interpretWith mem ins

and private interpretWith (mem : Memory) (ast : AST seq) =
  Seq.iter (interpretOneWith mem) ast

let interpret (input : string) =
  lex input
  |> parse
  |> Result.map (interpretWith <| Memory ())