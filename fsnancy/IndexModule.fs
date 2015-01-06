namespace fsnancy

open Nancy
open FSharp.Configuration

type Settings = AppSettings<"web.config">
type MyModel = {TestKey:string}

type IndexModule() as x =
    inherit NancyModule()
    let webConfigVal = Settings.TestKey
    let m ={TestKey = webConfigVal}
    do x.Get.["/"] <- fun _ -> box x.View.["index", m]

