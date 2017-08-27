module Output

open Models
open ViewHelpers
open Elmish
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

open SingleTask

let outputView (model: Model) dispatch = 
    let tab tabDay = 
        let activeClass = 
            if tabDay = model.DisplayDay then "is-active"
            else ""

        li [ClassName activeClass] [
            a 
                [OnClick (fun _ -> tabDay |> ToggleView |> dispatch)] 
                [str <| sprintf "%A" tabDay]
        ]

    [
        h2  [ ClassName "subtitle" ] 
            [   
                div [ClassName "tabs is-boxed"] [
                    [Monday; Tuesday; Wednesday; Thursday; Friday; Saturday; Sunday] 
                        |> List.map tab 
                        |> (ul []) // wrap.
                ]
            ]

        model.InputTasks
            |> (TaskScheduler.taskScheduler model.DisplayDay)
            |> DayView.dayView
    ]