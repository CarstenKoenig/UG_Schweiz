open System
open FSharp.Data

type Stocks = CsvProvider<"./MSFT.csv">


[<EntryPoint>]
let main argv =

  let file = argv.[0]
  let rows = Stocks.Load(uri=file).Rows

  printfn "Some stock values"
  for row in Seq.take 10 rows do
    printfn "%s %.2f" (row.Date.ToString ("dd.MM.yyyy")) row.Open

  0