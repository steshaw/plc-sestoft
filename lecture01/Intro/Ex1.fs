module Ex1

// max2 : int * int -> int
let max2 (n, m) = if n > m then n else m

// max3 : int * int * int -> int
let max3 (n, m, o) = max2 (n, max2(m, o))

// int list -> bool
let isPositive xs = List.forall (fun n -> n > 0) xs

// int list -> bool
let isSorted xs = xs = List.sort xs

open Appendix

// count : IntTree -> int
// XXX: Why does this not ned to be `let rec`?
let count = function
  | Lf           -> 0
  | Br (i, l, r) -> 1 + count l + count r

let testCount = count (Br(37, Br(117, Lf, Lf), Br(42, Lf, Lf))) = 3

// depth : IntTree -> int
let rec depth = function
  | Lf           -> 0
  | Br (i, l, r) -> 1 + max (depth l) (depth r)

let testDepth = depth (Br(37, Br(117, Lf, Lf), Br(42, Lf, Lf))) = 2
