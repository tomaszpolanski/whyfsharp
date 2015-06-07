module List

let private split l (s : string) = s.Split(l)
let private trim (s : string) = s.Trim()

let FoldTextToOneLineV3 (multiLineString : string) maxLines foldSeperator = 
    multiLineString
    |> split [| '\n'; ','; ';' |]
    |> Array.map trim
    |> Array.filter ((<>) "")
    |> Array.truncate maxLines
    |> Array.reduce (fun f s -> f + foldSeperator + s) 
