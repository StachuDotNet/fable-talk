module DayView

open TaskScheduler
open ViewHelpers
open Fable.Helpers.React
open Fable.Helpers.React.Props
open SingleTask

let dayView (scheduledTasks: ScheduledTask list) = 
    table [ ClassName "table" ]
        [
            thead [] [
                tr [] [
                    plainTh "Name"
                    plainTh "Start"
                    plainTh "End"
                ]
            ]

            tbody [] 
                (scheduledTasks |> List.map(fun(task) -> 
                    tr [] [
                        plainTd task.Name;
                        plainTd (sprintf "%A" task.StartTime)
                        plainTd (sprintf "%A" task.EndTime)
                    ]
                ))
        ]