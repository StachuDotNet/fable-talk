module InputView

open Models
open ViewHelpers
open Elmish
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

open SingleTask

let inputView (scheduleTasks: ScheduleTask list) dispatch = 
    [
        h2 [ ClassName "subtitle"] [str "input"]

        a   [ 
                ClassName "button"
                OnClick (fun _ -> AddTask |> dispatch)
            ] 
            [ str "+"]

        table [ ClassName "table" ]
            [
                thead [] [
                    tr [] [
                        plainTh "Name"
                        plainTh "Frequency"
                        plainTh "Start"
                        plainTh "End"
                        plainTh ""
                    ]
                ]

                tbody [] 
                    (scheduleTasks 
                    |> List.sortBy(fun task -> task.StartTime)
                    |> List.map(fun (task) -> 
                       SingleTask.view task dispatch
                    ))
            ]
    ]