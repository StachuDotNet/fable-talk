module App

open Elmish
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Elmish.React

importAll "../sass/main.sass"

Program.mkProgram Models.init Update.update View.view
    |> Program.withReact "elmish-app"
    |> Program.run