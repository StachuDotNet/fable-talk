module SingleTask 

open Models
open ViewHelpers
open Elmish
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

let view (task: ScheduleTask) dispatch = 
    let displayFrequency freq = 
        match freq with 
        | Daily -> "Daily"
        | WeekDays -> "Week Days"

    let simpleInput value action =
        td [] [
            input [ 
                OnChange (action)
                Value value
            ]
        ]

    tr [] [
        simpleInput !^task.Name (fun e -> 
            let newName = !!e.target?value 
            (task.Id, newName) |> ChangeName |> dispatch
        )

        td [] [
            a [
                ClassName "button"
                OnClick (fun e -> task.Id |> ToggleFrequency |> dispatch)
            ] [
                str <| displayFrequency task.Frequency
            ]
        ]

        simpleInput !^task.StartTime (fun e -> 
            let newStartTime = !!e.target?value 
            (task.Id, newStartTime) |> ChangeStartTime |> dispatch
        )

        simpleInput !^task.EndTime (fun e -> 
            let newEndTime = !!e.target?value 
            (task.Id, newEndTime) |> ChangeEndTime |> dispatch
        )

        td [] [
            a
                [ 
                    ClassName "button"
                    OnClick (fun _ -> task.Id |> RemoveTask |> dispatch)
                ]
                [ str <| sprintf "x %i" task.Id ]
        ]
    ]