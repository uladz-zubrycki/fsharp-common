open Microsoft.FSharp.Reflection

module UnionUtils = 
    let toString (v: 'a) =
        let (case, _) = FSharpValue.GetUnionFields(v, typeof<'a>) 
        case.Name