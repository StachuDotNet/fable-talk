// Inverts a decimal
let invert n =
    match n with
    | 0.0 -> None
    | _ -> Some (1.0 / n)

// Calls the invert function, then prints out the result
let invertPrinter n =
    let inverted = invert n

    match inverted with
    | None -> printfn "Could not invert: %f" n
    | Some i -> printfn "The inverse of %f is %f" n i