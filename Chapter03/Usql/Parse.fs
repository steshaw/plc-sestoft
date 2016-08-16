(* Lexing and parsing of micro-SQL SELECT statements using fslex and fsyacc *)

open System
open System.IO
open Microsoft.FSharp.Text.Lexing
open Absyn

(* Plain parsing from a string, with poor error reporting *)

let fromString (str : string) : stmt =
    let lexbuf = Lexing.LexBuffer<char>.FromString(str)
    try 
      UsqlPar.Main UsqlLex.Token lexbuf
    with 
      | exn -> let pos = lexbuf.EndPos 
               failwithf "%s near line %d, column %d\n" 
                  (exn.Message) (pos.Line+1) pos.Column

(* Parsing from a file *)

let fromFile (filename : string) =
    use reader = new StreamReader(filename)
    let lexbuf = Lexing.LexBuffer<char>.FromTextReader reader
    try 
      UsqlPar.Main UsqlLex.Token lexbuf
    with 
      | exn -> let pos = lexbuf.EndPos 
               failwithf "%s in file %s near line %d, column %d\n" 
                  (exn.Message) filename (pos.Line+1) pos.Column

(* Exercise it *)

let e1 = fromString "SELECT name, salary * (1 - taxrate) FROM Employee";;

let e2 = fromString "SELECT department, AVG(salary * (1 - taxrate)) FROM Employee";;

