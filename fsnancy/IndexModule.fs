namespace fsnancy

open Nancy
open FSharp.Configuration

type Settings = AppSettings<"web.config">
type MyModel = {TestKey:string}

type IndexModule() as x =
    inherit NancyModule()
    let webConfigVal = Settings.TestKey
    let webConfigVal2 = System.Configuration.ConfigurationManager.AppSettings.["TestKey"]
    let m ={TestKey = webConfigVal2}
    do x.Get.["/"] <- fun _ -> box x.View.["index", m]

