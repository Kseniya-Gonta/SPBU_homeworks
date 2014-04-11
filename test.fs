let xs = ["table"; "apple"; "sea" ; "boom"]
let len = 15
type lineEl = 
     | Word of string
     | Space of int

let formLines (xs:string list) len = 
    let rec formLinesTR curline curlen (buf:string list) formedLines = 
        match buf with 
            | h :: t ->  
                match len - curlen - h.Length - 1 with 
                    | x when x >= 0 -> 
                        formLinesTR <| (Word h) :: (Space 1) :: curline <| curlen + h.Length + 1 <| t <| formedLines
                    | _ -> formLinesTR <| [] <| -1 <| buf <| (List.rev curline).Tail :: formedLines
            | [] -> (List.rev curline).Tail :: formedLines
    List.rev (formLinesTR [] -1 xs [])

let formedLines = formLines xs len

printfn "%A" (formedLines)



let lineLen = List.fold (fun acc x -> acc + match x with | Word w -> w.Length | Space s -> s) 0
           
exception Error            

let alignMid (formedLines: lineEl list list) = 
    match formedLines with
        | h :: t ->
            let wide = (len - lineLen h )/ 2
            let check = (len - lineLen h) % 2  
            List.map(fun formedLines -> (Space(wide) :: formedLines) @ [Space(wide + check)])
        | [] -> raise Error

printfn "!!!%A!!!" (alignMid(formedLines))

//let alignRight (formedLines: lineEl list list) = function
  //  | h :: t ->
    //    let add = len - 
    //
    //
ignore <| System.Console.ReadKey()
