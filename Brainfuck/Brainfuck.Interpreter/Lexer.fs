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
  failwith "implement me"