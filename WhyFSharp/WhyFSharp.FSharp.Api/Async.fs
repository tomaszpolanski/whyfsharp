module Async

open System.Net
open System
open System.IO
open Microsoft.FSharp.Control.CommonExtensions

let DelayPrint time text c = 
    let asyncDelay = 
        async { 
            do! Async.Sleep(time)
            return text
        }
    Async.StartAsTask(asyncDelay, cancellationToken = c)

let DownloadStuff cancellation =

    // Fetch the contents of a URL asynchronously
    let fetchUrlAsync url  = 
        async { // "async" keyword and curly braces 
            // creates an "async" object
            let req = WebRequest.Create(Uri(url))
            use! resp = req.AsyncGetResponse()
            // use! is async assignment
            use stream = resp.GetResponseStream()
            // "use" triggers automatic close()
            // on resource at end of scope
            use reader = new IO.StreamReader(stream)
            let html = reader.ReadToEnd()
            return html.Length
        }

    // a list of sites to fetch
    let sites = 
        [ "http://www.bing.com"; "http://www.google.com"; "http://www.microsoft.com"; "http://www.amazon.com"; 
          "http://www.yahoo.com" ]

    let startAsTask c a = Async.StartAsTask(a, cancellationToken = c)
    // do it
    sites
    |> List.map fetchUrlAsync // make a list of async tasks
    |> Async.Parallel // set up the tasks to run in parallel
    |> startAsTask cancellation
    
