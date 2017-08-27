module View

open Models
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

let view (model: Model) dispatch =
    div [ ClassName "container is-fluid"] 
        [
            h1 [ClassName "title"] [str "test"]

            div [ClassName "columns"] [
                div [ClassName "column"] <| InputView.inputView model.InputTasks dispatch
                div [ClassName "column"] <| Output.outputView model dispatch
            ]
        ]
