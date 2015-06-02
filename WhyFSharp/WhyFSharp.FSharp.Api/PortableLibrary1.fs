namespace WhyFSharp.FSharp.Api

type List() = 
    static let split l (s : string) = s.Split(l)
    static let trim (s : string) = s.Trim()
    
    static let lift3 f x y z = 
        match x with
        | None -> None
        | Some x' -> 
            match y with
            | None -> None
            | Some y' -> 
                match z with
                | None -> None
                | Some z' -> Some <| f x' y' z'
    
    static let foldTextToOneLine (multiLineString : string) maxLines foldSeperator = 
        multiLineString
        |> split [| '\n'; ','; ';' |]
        |> Array.map trim
        |> Array.filter ((<>) "")
        |> Array.truncate maxLines
        |> Array.fold (fun f s -> f + foldSeperator + s) ""
    
    static member FoldTextToOneLineV3 arg = arg |||> foldTextToOneLine

    static member FoldTextToOneLineV4(?multiLineString, ?maxLines, ?foldSeperator) = 
        match lift3 foldTextToOneLine multiLineString maxLines foldSeperator with
        | Some s -> s
        | None -> ""
