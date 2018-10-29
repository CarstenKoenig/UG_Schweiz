namespace Tests

open NUnit.Framework
open Brainfuck.Interpreter.Memory

[<Ignore("needs to be implemented")>]
type ``Memory tests`` () =

    [<Test>]
    member test.``initial cell is 0`` () =
      let memory = new Memory()
      Assert.AreEqual (0uy, memory.CurrentValue)

    [<Test>]
    member test.``cell can be set`` () =
      let memory = new Memory()
      memory.CurrentValue <- 4uy
      Assert.AreEqual (4uy, memory.CurrentValue)

    [<Test>]
    member test.``value can be increased`` () =
      let memory = new Memory()
      memory.Incr ()
      Assert.AreEqual (1uy, memory.CurrentValue)

    [<Test>]
    member test.``value can be decreased`` () =
      let memory = new Memory()
      memory.CurrentValue <- 40uy
      memory.Decr ()
      Assert.AreEqual (39uy, memory.CurrentValue)


    [<Test>]
    member test.``pointer can be moved and initial values are 0`` () =
      let memory = new Memory()
      memory.Incr()
      memory.Incr()
      memory.MoveRight()
      memory.Incr()
      memory.MoveRight()
      Assert.AreEqual(0uy, memory.CurrentValue)
      memory.MoveLeft()
      Assert.AreEqual(1uy, memory.CurrentValue)
      memory.MoveLeft()
      Assert.AreEqual(2uy, memory.CurrentValue)
