//решение квадратного уравнения
let solve a b c = 
    let d = sqrt(b * b - 4.0 * a * c)
    let x1 = (-b + d) * 0.5 / a
    let x2 = (-b - d) * 0.5 / a
    (x1,x2)
let (x1, x2) = solve 1.0 -2.0 -3.0
printfn "%A" (x1)
printfn "%A" (x2)

//длина списка
let list123 = [ 1; 2; 3 ]
let rec len l = 
    match l with
    |hd :: tl -> 1 + len(tl)
    |[]-> 0
printfn "(len list123) = %A " (len list123 )


//сумма элементов списка
let rec sum zero m = 
    match m with
    |hd::tl -> hd + sum zero tl
    |[] -> zero

printfn "The sum is %A" (sum 0 list123)


// сцепить два списка
let list1 = [3;7;1]
let list2 = [90;120;33]
let list3 = list1 @ list2
printfn "The new list is: %A" (list3)
