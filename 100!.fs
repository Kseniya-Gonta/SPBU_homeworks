open System.Numerics
let rec fact (x: int) (acc:bigint) : bigint =
    match x with
    |1 -> acc
    |_ -> fact (x-1) (acc*bigint(x))

let a:bigint = fact 100 (bigint(1))
