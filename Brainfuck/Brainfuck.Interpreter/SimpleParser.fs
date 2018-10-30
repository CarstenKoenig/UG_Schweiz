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

let private parseToken =
  function
  | IncrToken -> Incr
  | DecrToken -> Decr
  | MoveLeftToken -> MoveLeft
  | MoveRightToken -> MoveRight
  | ReadToken -> Read
  | WriteToken -> Write 
  | LoopEndToken | LoopStartToken -> failwith "loops not simple"

let rec private parseList acc =
  function
  | [] -> Ok (List.rev acc, [])
  | (LoopStartToken :: rest) ->
    match parseList [] rest with
    | Error _ as err -> err
    | Ok (loopBody, rest') ->
      parseList (Loop loopBody :: acc) rest'
  | (LoopEndToken :: rest) ->
    Ok (List.rev acc, rest)
  | (token :: rest) ->
    parseList (parseToken token :: acc) rest


let parse (tokens : Token seq) : Result<AST list, string> =
  tokens
  |> Seq.toList
  |> parseList []
  |> Result.map fst