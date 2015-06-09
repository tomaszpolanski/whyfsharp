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
