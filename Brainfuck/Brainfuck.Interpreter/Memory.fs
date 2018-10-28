module Brainfuck.Interpreter.Memory

open System.Collections.Generic

type Memory() =
  member __.MoveRight () =
    failwith "implement me"
  member __.MoveLeft () =
    failwith "implement me"
  member __.CurrentValue 
    with get () =
      failwith "implement me"
    and set v = 
      failwith "implement me"
  member this.Incr () =
    failwith "implement me"
  member this.Decr () =
    failwith "implement me"