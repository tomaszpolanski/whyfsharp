#r @".\..\WhyFSharp.FSharp.Api\bin\Debug\WhyFSharp.FSharp.Api.dll"
open Model

module Lines = 
    let multilineTest = List.FoldTextToOneLineV3 "kalsjdfosdaoijsdlkdsjfkl sdklfjal,sdjkflsadjflkadf,asdfasdf,dfsafd,        ,sdf" 2 ":)"

module Comparison =
    let point = {X = 1; Y = 2}

    let point2 = {X = 2; Y = 2}

    point = point2

module ``Extension methods`` =
    let max f i l = if List.isEmpty l then i else l |> List.maxBy f  

    [2;3;1;2345;12;54;7] |> max id 0

    let repeat count str = str |> List.replicate count |> List.fold (+) ""

    "Na" |> repeat 7 |> (+) <| " Batman!"

module ``Primitive obsession`` = 
    
    let test = CustomerId.create "asdfasdf"

    let repeat count str = str |> List.replicate count 
                               |> List.fold (+) ""
    let test2 = "Na" |> repeat 7 
                     |> (+) <| " Batman!" 
                     |> CustomerId.create 

    match test with
    | Some id -> printfn "%A" id
    | None -> printfn "Invalid id"

    let str = "jskfasdfasdsk"
    str |> Option.ofObj
        |> Option.filter (String.length >> (<) 3)        
        |> Option.map (String.replicate 2)
        |> function
            | Some s -> printfn "Long string: %s" s
            | None -> printfn "No string there"
