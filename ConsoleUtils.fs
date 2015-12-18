module FSharpCommon.ConsoleUtils

open System

let private printColored color message = 
    let cmdColor = Console.ForegroundColor
    Console.ForegroundColor <- color
    printfn "%s" message
    Console.ForegroundColor <- cmdColor

let printInfo message = printColored ConsoleColor.DarkGray message
let printWarn message = printColored ConsoleColor.DarkYellow message
let printSuccess message = printColored ConsoleColor.DarkGreen message 
let printError message = printColored ConsoleColor.DarkRed message