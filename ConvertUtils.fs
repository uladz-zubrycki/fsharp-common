open System

module ConvertUtils = 
    let private parseWith parser value = 
        match parser value with
            | true, v -> Some(v)
            | false, _ -> None

    let private castTo<'a, 'b> (o: 'a) = 
        match o.GetType() with
        | t when t = typeof<'b> -> Some((box o) :?> 'b)
        | _ -> None

    let (|DateTimeString|_|) = parseWith DateTime.TryParse
    let (|FloatString|_|) = parseWith Double.TryParse
    let (|Int32String|_|) = parseWith Int32.TryParse
    let (|DateTime|_|) = castTo<'a, DateTime>
    let (|Float|_|) = castTo<'a, float>
    let (|Int32|_|) = castTo<'a, int>
    let (|String|_|) = castTo<'a, string>