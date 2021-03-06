namespace Fable.Import.WebAudio

open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

type [<AllowNullLiteral>] AudioContext =
    abstract destination: AudioDestinationNode with get, set
    abstract sampleRate: float with get, set
    abstract currentTime: float with get, set
    abstract listener: AudioListener with get, set
    abstract activeSourceCount: float with get, set
    abstract createBuffer: numberOfChannels: float * length: float * sampleRate: float -> AudioBuffer
    abstract createBuffer: buffer: ArrayBuffer * mixToMono: bool -> AudioBuffer
    abstract decodeAudioData: audioData: ArrayBuffer * successCallback: obj * ?errorCallback: obj -> unit
    abstract createBufferSource: unit -> AudioBufferSourceNode
    abstract createMediaElementSource: mediaElement: HTMLMediaElement -> MediaElementAudioSourceNode
    abstract createMediaStreamSource: mediaStream: obj -> MediaStreamAudioSourceNode
    abstract createScriptProcessor: bufferSize: float * ?numberOfInputChannels: float * ?numberOfOutputChannels: float -> ScriptProcessorNode
    abstract createAnalyser: unit -> AnalyserNode
    abstract createGain: unit -> GainNode
    abstract createDelay: ?maxDelayTime: float -> DelayNode
    abstract createBiquadFilter: unit -> BiquadFilterNode
    abstract createWaveShaper: unit -> WaveShaperNode
    abstract createPanner: unit -> PannerNode
    abstract createConvolver: unit -> ConvolverNode
    abstract createChannelSplitter: ?numberOfOutputs: float -> ChannelSplitterNode
    abstract createChannelMerger: ?numberOfInputs: float -> ChannelMergerNode
    abstract createDynamicsCompressor: unit -> DynamicsCompressorNode
    abstract createOscillator: unit -> OscillatorNode
    abstract createWaveTable: real: obj * imag: obj -> WaveTable

and [<AllowNullLiteral>] AudioContextType =
    [<Emit("new $0($1...)")>] abstract Create: unit -> AudioContext

and [<AllowNullLiteral>] webkitAudioContextType =
    [<Emit("new $0($1...)")>] abstract Create: unit -> AudioContext

and [<AllowNullLiteral>] OfflineRenderSuccessCallback =
    [<Emit("$0($1...)")>] abstract Invoke: renderedData: AudioBuffer -> unit

and [<AllowNullLiteral>] OfflineAudioContext =
    inherit AudioContext
    abstract oncomplete: OfflineRenderSuccessCallback with get, set
    abstract startRendering: unit -> unit

and [<AllowNullLiteral>] webkitOfflineAudioContextType =
    [<Emit("new $0($1...)")>] abstract Create: numberOfChannels: float * length: float * sampleRate: float -> OfflineAudioContext

and [<AllowNullLiteral>] AudioNode =
    abstract context: AudioContext with get, set
    abstract numberOfInputs: float with get, set
    abstract numberOfOutputs: float with get, set
    abstract connect: destination: AudioNode * ?output: float * ?input: float -> unit
    abstract connect: destination: AudioParam * ?output: float -> unit
    abstract disconnect: ?output: float -> unit

and [<AllowNullLiteral>] AudioSourceNode =
    inherit AudioNode


and [<AllowNullLiteral>] AudioDestinationNode =
    inherit AudioNode
    abstract maxNumberOfChannels: float with get, set
    abstract numberOfChannels: float with get, set

and [<AllowNullLiteral>] AudioParam =
    abstract value: float with get, set
    abstract minValue: float with get, set
    abstract maxValue: float with get, set
    abstract defaultValue: float with get, set
    abstract setValueAtTime: value: float * startTime: float -> unit
    abstract linearRampToValueAtTime: value: float * time: float -> unit
    abstract exponentialRampToValueAtTime: value: float * endTime: float -> unit
    abstract setTargetValueAtTime: target: float * startTime: float * timeConstant: float -> unit
    abstract setValueCurveAtTime: values: Float32Array * time: float * duration: float -> unit
    abstract cancelScheduledValues: startTime: float -> unit

and [<AllowNullLiteral>] GainNode =
    inherit AudioNode
    abstract gain: AudioParam with get, set

and [<AllowNullLiteral>] DelayNode =
    inherit AudioNode
    abstract delayTime: AudioParam with get, set

and [<AllowNullLiteral>] AudioBuffer =
    abstract sampleRate: float with get, set
    abstract length: float with get, set
    abstract duration: float with get, set
    abstract numberOfChannels: float with get, set
    abstract getChannelData: channel: float -> Float32Array

and [<AllowNullLiteral>] AudioBufferSourceNode =
    inherit AudioSourceNode
    abstract playbackState: float with get, set
    abstract buffer: AudioBuffer with get, set
    abstract playbackRate: AudioParam with get, set
    abstract loop: bool with get, set
    abstract loopStart: float with get, set
    abstract loopEnd: float with get, set
    abstract onended: EventListener with get, set
    abstract start: ``when``: float * ?offset: float * ?duration: float -> unit
    abstract stop: ``when``: float -> unit

and [<AllowNullLiteral>] MediaElementAudioSourceNode =
    inherit AudioSourceNode

and [<AllowNullLiteral>] ScriptProcessorNode =
    inherit AudioNode
    abstract onaudioprocess: EventListener with get, set
    abstract bufferSize: float with get, set

and [<AllowNullLiteral>] AudioProcessingEvent =
    inherit Event
    abstract node: ScriptProcessorNode with get, set
    abstract playbackTime: float with get, set
    abstract inputBuffer: AudioBuffer with get, set
    abstract outputBuffer: AudioBuffer with get, set

and PanningModelType = string
and DistanceModelType = string
and OscillatorType = string
and BiquadFilterType = string

and [<AllowNullLiteral>] PannerNode =
    inherit AudioNode
    abstract panningModel: PanningModelType with get, set
    abstract distanceModel: DistanceModelType with get, set
    abstract refDistance: float with get, set
    abstract maxDistance: float with get, set
    abstract rolloffFactor: float with get, set
    abstract coneInnerAngle: float with get, set
    abstract coneOuterAngle: float with get, set
    abstract coneOuterGain: float with get, set
    abstract setPosition: x: float * y: float * z: float -> unit
    abstract setOrientation: x: float * y: float * z: float -> unit
    abstract setVelocity: x: float * y: float * z: float -> unit

and [<AllowNullLiteral>] AudioListener =
    abstract dopplerFactor: float with get, set
    abstract speedOfSound: float with get, set
    abstract setPosition: x: float * y: float * z: float -> unit
    abstract setOrientation: x: float * y: float * z: float * xUp: float * yUp: float * zUp: float -> unit
    abstract setVelocity: x: float * y: float * z: float -> unit

and [<AllowNullLiteral>] ConvolverNode =
    inherit AudioNode
    abstract buffer: AudioBuffer with get, set
    abstract normalize: bool with get, set

and [<AllowNullLiteral>] AnalyserNode =
    inherit AudioNode
    abstract fftSize: float with get, set
    abstract frequencyBinCount: float with get, set
    abstract minDecibels: float with get, set
    abstract maxDecibels: float with get, set
    abstract smoothingTimeConstant: float with get, set
    abstract getFloatFrequencyData: array: obj -> unit
    abstract getByteFrequencyData: array: obj -> unit
    abstract getByteTimeDomainData: array: obj -> unit

and [<AllowNullLiteral>] ChannelSplitterNode =
    inherit AudioNode


and [<AllowNullLiteral>] ChannelMergerNode =
    inherit AudioNode


and [<AllowNullLiteral>] DynamicsCompressorNode =
    inherit AudioNode
    abstract threshold: AudioParam with get, set
    abstract knee: AudioParam with get, set
    abstract ratio: AudioParam with get, set
    abstract reduction: AudioParam with get, set
    abstract attack: AudioParam with get, set
    abstract release: AudioParam with get, set

and [<AllowNullLiteral>] BiquadFilterNode =
    inherit AudioNode
    abstract ``type``: BiquadFilterType with get, set
    abstract frequency: AudioParam with get, set
    abstract Q: AudioParam with get, set
    abstract gain: AudioParam with get, set
    abstract getFrequencyResponse: frequencyHz: obj * magResponse: obj * phaseResponse: obj -> unit

and [<AllowNullLiteral>] WaveShaperNode =
    inherit AudioNode
    abstract curve: Float32Array with get, set

and [<AllowNullLiteral>] OscillatorNode =
    inherit AudioSourceNode
    abstract ``type``: OscillatorType with get, set
    abstract playbackState: float with get, set
    abstract frequency: AudioParam with get, set
    abstract detune: AudioParam with get, set
    abstract start: ``when``: float -> unit
    abstract stop: ``when``: float -> unit
    abstract setWaveTable: waveTable: WaveTable -> unit

and [<AllowNullLiteral>] WaveTable =
    interface end

and [<AllowNullLiteral>] MediaStreamAudioSourceNode =
    inherit AudioSourceNode


type [<Erase>]Globals =
    [<Global>] static member AudioContext with get(): AudioContextType = jsNative and set(v: AudioContextType): unit = jsNative
    [<Global>] static member webkitAudioContext with get(): webkitAudioContextType = jsNative and set(v: webkitAudioContextType): unit = jsNative
    [<Global>] static member webkitOfflineAudioContext with get(): webkitOfflineAudioContextType = jsNative and set(v: webkitOfflineAudioContextType): unit = jsNative

