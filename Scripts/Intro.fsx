(*
                                    WW  WW                                      
                                  WNO0WNXKKNW                                   
                                WNOdlkWNKOdkKNW                                 
                              WNOdlclkWNKOdddk0NW                               
                            WNOdlccclkWNKOdddddk0NW                             
                          WXOdlccccclkWNKkdddddddx0NW                           
                        WNOdlccccccclkNNKOdddddddddx0XW                         
                       NOdlccccccccclkNNKOdddddddddddx0XW                       
                    WNOdlccccccccccclkWNKOdddddddddddddxOXW                     
                  WNOdlcccccccccccccoOWNX0dddddddddddddddxOXW                   
                WNOdlccccccccccccclxKW  WNKkdddddddddddddddxOXW                 
              WNOdlccccccccccccclxKW       WKkdddddddddddddddxOXW               
            WNOdlccccccccccccclxKW WKXW      NKkdddddddddddddddxOKW             
          WXOdlccccccccccccclxKW WKxokW        NKkdddddddddddddddxkKN           
        WNOdlccccccccccccclxKW WKxlclkW          NKkddddddddddddddddkKN         
      WNOdlccccccccccccclxKW WKxlccclkW            NKkddddddddddddddddkKN       
    WNOdlccccccccccccclxKW WKxlccccclkW              WKkddddddddddddddddkKN     
  WXOdlccccccccccccclxKW WKxlccccccclkW                NKkddddddddddddddddk0NW  
  NOlcccccccccccccclxX  WKdlcccccccclkW                 WXkddddddddddddddddx0W  
   N0dlcccccccccccccld0N WXkoccccccclkW               WN0kddddddddddddddddkKN   
     N0dlcccccccccccccld0N WXkoccccclkW              N0kdddddddddddddddxOKW     
       N0dlcccccccccccccld0N WXkoccclkW            N0kdddddddddddddddxOXW       
         N0dlcccccccccccccld0N WXkoclkW          N0kdddddddddddddddxOXW         
           N0dlcccccccccccccld0NWWXkokW        N0kdddddddddddddddxOXW           
            WN0dlcccccccccccccld0N WXXW     WN0kdddddddddddddddxOXW             
               N0dlccccccccccccclx0N      WN0kdddddddddddddddx0XW               
                 N0dlcccccccccccccld0N  WN0kdddddddddddddddx0XW                 
                   N0dlccccccccccccclOWNXOdddddddddddddddx0NW                   
                     N0dlccccccccccclkWNKOdddddddddddddk0NW                     
                       N0dlccccccccclkWNKOdddddddddddk0NW                       
                         N0dlccccccclkNNKOdddddddddkKNW                         
                           N0dlccccclkWNKOdddddddkKN                            
                            WN0dlccclkWNKOdddddkKNW                             
                               N0dlclkWNXOdddkKW                                
                                 N0dlkWNKOxOKW                                  
                                   N0KWWXKXW                                    
                                        W                                       
*)

open System





// Einfache Werte


let zahl = 42

let fZahl = 42.42

let wort = "Hallo"




let wieVoid = ()


let fZahl2 = zahl + 42.0
















// Funktionen

let lambda = fun x -> x + x








// Vorsicht

let hey x =
  "Hey " + x.ToUpper() + "!"










// Pipe

let mitPipe zahl =
  zahl
  |> fun x -> x * x + 3.0
  |> sqrt


let composition =
  (fun x -> x * x + 3.0) >> sqrt






// Vorsicht

let g x = f (x+3)
let f x = x + x








// mehrere Argumente


// Tupel
let plusT (x,y) =
  x + y


// curry
let plus x y = 
  x + y
  // fun x -> (fun y -> x + y)





// partial application
let plus10 = plus 10








// Vorsicht


let sqr x = x * x

printfn "%d" sqr zahl

printfn "%s" DateTime.Now.ToString()





// Übung


let mystery (f : 'a -> () -> 'b) (b : 'b) : 'a =
  failwith "implement me"




// if

let isAnswer =
  if zahl < 42 then "not the answer"
















// Übung: FizzBuzz


// fizzBuzz 1 = "1"
// fizzBuzz 2 = "2"
// fizzBuzz 3 = "Fizz"
// fizzBuzz 4 = "4"
// fizzBuzz 5 = "Buzz"
// fizzBuzz 6 = "Fizz"
// ...
// fizzBuzz 15  = "FizzBuzz"
let fizzBuzz (n : int) : string =
  failwith "implement me please"















// Rekursion


let rec fib n = 
  if n < 0 then failwith "only non-negative values valid"
  if n <= 1 then n else
  fib (n-1) + fib (n-2)
















(************************************************************************)
// TYPEN

// Type Alias


type Zahl = int

type Generisch<'a> = 'a

type 'a Generisch2 = 'a

let x : int Generisch = 5

















// Tuple

let tupel = (zahl, wort)



// pattern-match (Dekonstruktion)
let (z,w) = tupel



let patterMatch t =
  match t with
  | (42, "Hallo") -> "freundliche Antwort auf Alles"
  | (42, _)       -> "Antwort auf Alles"
  | (_, "Hallo")  -> "Begrüßung"
  | (z,w) when z % 2 = 0 
                  -> sprintf "gerade Zahl %d mit Wort %s" z w
  | (z,w)         -> sprintf "Zahl %d mit Wort %s" z w






// Übung


let erstes (tupel : 'a * 'b) : 'a =
  failwith "implement me"

let uncurry (f : 'a -> 'b -> 'c) : ('a * 'b -> 'c) =
  failwith "implement me"
















// Listen

let zahlen = 1 :: 2 :: 3 :: 4 :: 5 :: []

let mitNull =
  0 :: zahlen

let zahlen2 = [1,2,3,4,5]

let zahlen3 = [1..10]


let kopf (ls : 'a list) : 'a =
  match ls with
  | []     -> failwith "Liste ist leer"
  | (x::_) -> x




// Übung:

let rec append (xs : 'a list) (ys : 'a list) : 'a list =
  failwith "implement me"





let appended =
  zahlen @ [6..10]
















// DUs



type Expr =
  | Zero
  | Zahl of int
  | Plus of Expr * Expr



let rec eval expr =
  match expr with
  | Zero       -> 0
  | Zahl n     -> n
  | Plus (a,b) -> eval a + eval b



// Options

let nichts : int option = None
let etwas = Some 5


let safeHead xs =
  match xs with
  | []     -> None
  | (x::_) -> Some x


let doppelterKopf xs =
  match safeHead xs with
  | None   -> "leer"
  | Some x -> string x



type Positiv = 
  private | Positiv of int
  member this.Value =
    match this with
    | Positiv n -> n
  override this.ToString () =
    this.Value.ToString ()
  static member Create n =
    if n <= 0 then None else
    Some n