namespace Fable.Import.WebMIDI

open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

module WebMidi =
    type [<AllowNullLiteral>] MIDIOptions =
        abstract sysex: bool with get, set

    and MIDIInputMap =
        Map<string, MIDIInput>

    and  MIDIOutputMap =
        Map<string, MIDIOutput>

    and [<AllowNullLiteral>] MIDIAccess =
        inherit EventTarget
        abstract inputs: MIDIInputMap with get, set
        abstract outputs: MIDIOutputMap with get, set
        abstract onstatechange: Func<MIDIConnectionEvent, unit> with get, set
        abstract sysexEnabled: bool with get, set

    and [<StringEnum>] MIDIPortType =
        | Input | Output

    and [<StringEnum>] MIDIPortDeviceState =
        | Disconnected | Connected

    and [<StringEnum>] MIDIPortConnectionState =
        | Open | Closed | Pending

    and [<AllowNullLiteral>] MIDIPort =
        inherit EventTarget
        abstract id: string with get, set
        abstract manufacturer: string option with get, set
        abstract name: string option with get, set
        abstract ``type``: MIDIPortType with get, set
        abstract version: string option with get, set
        abstract state: MIDIPortDeviceState with get, set
        abstract connection: MIDIPortConnectionState with get, set
        abstract onstatechange: Func<MIDIConnectionEvent, unit> with get, set
        abstract ``open``: unit -> Promise<MIDIPort>
        abstract close: unit -> Promise<MIDIPort>

    and [<AllowNullLiteral>] MIDIInput =
        inherit MIDIPort
        abstract onmidimessage: Func<MIDIMessageEvent, unit> with get, set

    and [<AllowNullLiteral>] MIDIOutput =
        inherit MIDIPort
        abstract send: data: ResizeArray<float> * ?timestamp: float -> unit
        abstract clear: unit -> unit

    and [<AllowNullLiteral>] MIDIMessageEvent =
        inherit Event
        abstract receivedTime: float with get, set
        abstract data: Uint8Array with get, set

    and [<AllowNullLiteral>] MIDIMessageEventInit =
        inherit EventInit
        abstract receivedTime: float with get, set
        abstract data: Uint8Array with get, set

    and [<AllowNullLiteral>] MIDIConnectionEvent =
        inherit Event
        abstract port: MIDIPort with get, set

    and [<AllowNullLiteral>] MIDIConnectionEventInit =
        inherit EventInit
        abstract port: MIDIPort with get, set


type [<AllowNullLiteral>] Navigator =
    abstract requestMIDIAccess: ?options: WebMidi.MIDIOptions -> Promise<WebMidi.MIDIAccess>
