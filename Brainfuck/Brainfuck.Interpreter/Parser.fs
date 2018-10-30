module Brainfuck.Interpreter.Parser

open Brainfuck.Interpreter.Lexer

type AST =
  | Incr
  | Decr
  | MoveRight
  | MoveLeft
  | Read
  | Write
  | Loop of AST list


module private Combinators = 
  type Parser<'a> = Token list -> Result<'a * Token list, string>

  let succeed (value : 'a) : Parser<'a> =
    fun ts -> Result.Ok (value, ts)


  let error (err : string) : Parser<'a> =
    fun _ -> Result.Error err


  let token (t : Token) : Parser<Token> = function
    | [] -> Result.Error (sprintf "expected %A but got end of file" t)
    | (t' :: rest) when t' = t -> Result.Ok (t, rest)
    | (t' :: _) -> Result.Error (sprintf "expected %A but got %A" t t')


  let map (f : 'a -> 'b) (p : Parser<'a>) : Parser<'b> =
    p >> Result.map (fun (a,rest) -> (f a, rest))


  let bind (f : 'a -> Parser<'b>) (p : Parser<'a>) : Parser<'b> =
    fun ts ->
      match p ts with
      | Error err -> Error err
      | Ok (a,rest) -> (f a) rest


  type ParserBuilder() =
    member __.Bind (m,f) = bind f m
    member __.Return (x) = succeed x
    member __.Delay (f) = f ()

  let parse = ParserBuilder()


  let (>>=) = (fun p f -> bind f p)

  let (>*>) ign p = ign >>= (fun _ -> p)
  let (<*<) p ign = p >>= (fun res -> ign >>= (fun _ -> succeed res))

  let orElse (p : Parser<'a>) (p' : Parser<'a>) : Parser<'a> =
    fun tokens ->
      match p tokens with
      | (Ok _) as res -> res
      | Error _       -> p' tokens


  let choice (ps : Parser<'a> seq) : Parser<'a> =
    Seq.reduce orElse ps
    >> Result.mapError (fun _ -> "none of the parsers matched")


  let rec many (p : Parser<'a>) : Parser<'a list> =
    fun ts ->
      match p ts with
      | Error _     -> Ok ([], ts)
      | Ok (x,rest) -> 
        many p rest 
        |> Result.map (fun (xs,rest') -> (x::xs, rest'))


  let between (pl : Parser<'l>) (p : Parser<'a>) (pr : Parser<'r>) : Parser<'a> =
    // pl >*> p <*< pr
    parse {
      let! _ = pl
      let! res = p
      let! _ = pr
      return res
    }


  let instruction : Parser<AST> =
    [
      (IncrToken, Incr)
      (DecrToken, Decr)
      (MoveLeftToken, MoveLeft)
      (MoveRightToken, MoveRight)
      (ReadToken, Read)
      (WriteToken, Write) 
    ]
    |> List.map (fun (t,ins) -> token t |> map (fun _ -> ins))
    |> choice

  let createForwardedRef () =
    let dummyParser = ref (error "not initialized")
    (fun ts -> !dummyParser ts), dummyParser

  let (instructions, instructionsRef) = createForwardedRef ()

  let loop : Parser<AST>=
    between (token LoopStartToken) instructions (token LoopEndToken)
    |> map Loop

  instructionsRef :=  
    many (loop |> orElse instruction)


let parse (tokens : Token seq) : Result<AST list, string> =
  tokens
  |> Seq.toList
  |> Combinators.instructions
  |> Result.map fst