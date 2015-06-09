module Model

type TwoDPointF = { X : int; Y : int } override this.ToString() = sprintf "%A" this
    
module CustomerId = 

    type T = {Id:string}

    let create id = id |> Option.ofObj
                       |> Option.filter (fun str -> String.length str = 22)
                       |> Option.map (fun str -> {Id = str})