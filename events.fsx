open System.Windows.Forms

let form = new Form(Text="Click Form", Visible=true, TopMost = true, Width=400, Height=400)

form.Click.Add(fun evArgs -> printfn "Clicked!")

form.MouseMove
    |> Event.filter(fun e -> e.X > 200 && e.Y > 200)
    |> Event.add(fun e -> printfn "%i %i" e.X e.Y)