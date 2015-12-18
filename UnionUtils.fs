module FSharpCommon.UnionUtils

open Microsoft.FSharp.Reflection

let toString (v: 'a) =
    let (case, _) = FSharpValue.GetUnionFields(v, typeof<'a>) 
    case.Name