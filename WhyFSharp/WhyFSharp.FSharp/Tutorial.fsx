#r @".\..\WhyFSharp.FSharp.Api\bin\Debug\WhyFSharp.FSharp.Api.dll"
open Model


let test = List.FoldTextToOneLineV3 "kalsjdfosdaoijsdlkdsjfkl sdklfjal,sdjkflsadjflkadf,asdfasdf,dfsafd,        ,sdf" 2 ":)"

let point = {X = 1; Y = 2}

let point2 = {X = 2; Y = 2}

point = point2