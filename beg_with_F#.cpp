let solve a b c = 
    let d = sqrt(b * b - 4.0 * a * c)
    let x1 = (-b + d) * 0.5 / a
    let x2 = (-b - d) * 0.5 / a
    (x1,x2)
let (x1, x2) = solve 1.0 -2.0 -3.0
printfn "%A" (x1)
printfn "%A" (x2)


let list123 = [ 1; 2; 3 ]
let rec len l = 
    match l with
    |hd :: tl -> 1 + len(tl)
    |[]-> 0
printfn "(len list123) = %A " (len list123 )



