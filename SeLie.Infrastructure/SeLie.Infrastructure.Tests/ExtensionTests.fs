module ExtensionTests

open System
open Xunit
open FsUnit
open SeLie.Infrastructure
    
let inline add x y = x + y


[<Fact>]
let ``CheckNotNull 1 should not throw exception``() = 
    Extension.CheckNotNull 1 |> Xunit.should CustomMatchers.equal null

[<Fact>]
let ``CheckNotNull null shuold throw exception``() = 
    (fun () -> Extension.CheckNotNull null |> ignore) |> Xunit.should CustomMatchers.throw typeof<ArgumentNullException>
