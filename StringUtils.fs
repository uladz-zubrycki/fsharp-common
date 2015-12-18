module StringUtils = 
    let toString(o: obj) = o.ToString()
    let toStringLower(o: obj) = (toString o).ToLower()

    let (|StartsWith|_|) (value: string) (str: string) = 
        if str.StartsWith value then Some() else None