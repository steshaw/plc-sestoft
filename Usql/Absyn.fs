(* Abstract syntax for micro-SQL, very simple SQL SELECT statements 
   sestoft@itu.dk 2009-09-03
 *)

module Absyn

type constant =
  | CstI of int                         (* Integer constant               *)
  | CstB of bool                        (* Boolean constant               *)
  | CstS of string                      (* String constant                *)

type stmt =
  | Select of expr list                 (* fields are expressions         *)
            * string list               (* FROM ...                       *)

and column =
  | Column of string                    (* A column name: c               *)
  | TableColumn of string * string      (* A qualified column: t.c        *)

and expr = 
  | Star
  | Cst of constant                     (* Constant                       *)
  | ColumnExpr of column                (* Column                         *)
  | Prim of string * expr list          (* Built-in function              *)
