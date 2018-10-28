module Brainfuck.Interpreter.SimpleParser

open Brainfuck.Interpreter.Lexer

type AST =
  | Incr
  | Decr
  | MoveRight
  | MoveLeft
  | Read
  | Write
  | Loop of AST list

let private parseToken : Token -> AST =
  failwith "implement me"

let rec private parseList (acc : AST list) 
  : Token list -> Result<AST list * Token list, string> =
  failwith "implement me"


let parse (tokens : Token seq) : Result<AST list, string> =
  failwith "implement me"