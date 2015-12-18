open System
open System.IO

module PathUtils =
    let (@@) fst snd = Path.Combine(fst, snd)
    
    let normalizePath path relativeRoot =
        try
            path
            |> Environment.ExpandEnvironmentVariables
            |> (fun p -> if Path.IsPathRooted p then p else relativeRoot @@ p)
            |> Path.GetFullPath
            |> (fun p -> p.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar))
        with
            | :? System.Security.SecurityException
            | :? System.NotSupportedException 
            | :? System.IO.PathTooLongException as ex ->
              raise <| new System.IO.IOException (sprintf "Can't normalize path '%s'." path, ex)