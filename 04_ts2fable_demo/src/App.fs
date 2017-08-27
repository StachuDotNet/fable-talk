module WebMidiDemo

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.WebMIDI
open Fable.Import.WebAudio
open Fable.Import.JS
open Fable.PowerPack
open Fable.Core.JsInterop

[<Emit("navigator")>]
let navigator : Fable.Import.WebMIDI.Navigator = jsNative

let audioContext = Globals.AudioContext.Create()

let mutable everStarted = false

let oscillator = audioContext.createOscillator()
oscillator.``type`` <- "triangle"
oscillator.connect audioContext.destination

let respondToMidiMessage (msg: WebMidi.MIDIMessageEvent) = 
    printfn "%A" msg.data

    if not everStarted then
        oscillator.start 0.0
        everStarted <- true

    let newFrequency = 27.5 * Math.pow (2.0, (msg.data.[1] - 21.0)/12.0)

    oscillator.frequency.value <- newFrequency

let registerMidiInputDevice (value : WebMidi.MIDIInput) key map = 
    printfn "%A %A" key value
    value.onmidimessage <- respondToMidiMessage |> JsFunc.From1 |> unbox

(navigator.requestMIDIAccess ())
    |> Fable.PowerPack.Promise.map(fun z -> 
        z.inputs.forEach (registerMidiInputDevice |> JsFunc.From3 |> unbox)
    ) |> ignore