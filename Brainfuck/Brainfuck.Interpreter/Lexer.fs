module Brainfuck.Interpreter.Lexer

type Token =
  | IncrToken
  | DecrToken
  | MoveRightToken
  | MoveLeftToken
  | ReadToken
  | WriteToken
  | LoopStartToken
  | LoopEndToken

let lex (input : string) : Token seq =
  let readChar = function
    | '+' -> Some IncrToken
    | '-' -> Some DecrToken
    | '>' -> Some MoveRightToken
    | '<' -> Some MoveLeftToken
    | ',' -> Some ReadToken
    | '.' -> Some WriteToken
    | '[' -> Some LoopStartToken
    | ']' -> Some LoopEndToken
    | _   -> None
  input
  |> Seq.choose readChar