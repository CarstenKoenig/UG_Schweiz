module Brainfuck.Interpreter.Memory

open System.Collections.Generic

type Memory() =
  let mutable pointer = 0
  let cells = System.Collections.Generic.Dictionary<int, byte>()

  member __.MoveRight () =
    pointer <- pointer + 1
  member __.MoveLeft () =
    pointer <- pointer - 1
  member __.CurrentValue 
    with get () =
      match cells.TryGetValue pointer with
      | (false, _) -> 0uy
      | (true, v)  -> v
    and set v = cells.[pointer] <- v    
  member this.Incr () =
    this.CurrentValue <- this.CurrentValue + 1uy
  member this.Decr () =
    this.CurrentValue <- this.CurrentValue - 1uy