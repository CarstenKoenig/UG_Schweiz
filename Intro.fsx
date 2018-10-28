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



// explizite Umwandlung

let fZahl2 = double zahl + 42.0







// Vorsicht

zahl * 42.0















// Funktionen

let lambda = fun x -> x + x

let lambda' x = x + x








// Vorsicht

let hey x =
  "Hey " + x.ToUpper() + "!"










// Pipe

let zahl2 =
  zahl
  |> lambda
  |> lambda'


let zahl2' =
  (lambda >> lambda') zahl






// Vorsicht

let g x = f (x+3)
let f x = x + x








// mehrere Argumente



let plus x y = x + y


// (curry)
let plusWAT = 
  fun x -> (fun y -> x + y)




let plus10 = plus 10








// Vorsicht


let sqr x = x * x

printfn "%d" sqr zahl

printfn "%s" DateTime.Now.ToString()





// if

let isAnswer = if zahl < 42 then "not the answer"
















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

















// TYPEN

// Type Alias


type Zahl = int

type Generisch<'a> = 'a

type 'a Generisch2 = 'a

let x : int Generisch = 5



















// Tuple

let tupel = (zahl, wort)



let (z,w) = tupel



let patterMatch t =
  match t with
  | (42, "Hallo") -> "freundliche Antwort auf Alles"
  | (42, _)       -> "Antwort auf Alles"
  | (_, "Hallo")  -> "Begrüßung"
  | (z,w)         -> sprintf "Zahl %d mit Wort %s" z w






// Übung


let erstes (tupel : 'a * 'b) : 'a =
  failwith "implement me"

let uncurry (f : 'a -> 'b -> 'c) : ('a * 'b -> 'c) =
  failwith "implement me"
















// Listen

let zahlen = 1 :: 2 :: 3 :: 4 :: 5 :: []

let zahlen2 = [1,2,3,4,5]

let zahlen3 = [1..10]


let kopf (ls : 'a list) : 'a =
  match ls with
  | []     -> failwith "Liste ist leer"
  | (x::_) -> x




// Übung:

let rec concat (xs : 'a list) (ys : 'a list) : 'a list =
  failwith "implement me"






















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

