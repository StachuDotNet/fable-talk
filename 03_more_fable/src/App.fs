module FableInterop

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser




console.log("Fable running...");
printfn "hi there"









[<Emit("undefined")>]
let undefined : obj = jsNative

console.log(undefined) // undefined







[<Emit("1")>]
let one : int = jsNative

let result = one + one
console.log(result) // logs 2







[<Emit("$0 === undefined")>]
let isUndefined (x: 'a) : bool = jsNative


[<Emit("undefined")>]

console.log(isUndefined 5) // false
console.log(isUndefined "") // false
console.log(isUndefined [||]) // false
console.log(isUndefined (undefined)) // true








// [<Emit("$0 + $1")>]
// let add (x: int) (y: int) = jsNative

// console.log(add 5 10)











// [<Emit("isNaN($0)")>]
// let isNaN (x: 'a) = jsNative
// console.log(isNaN (log -2.0)) // true







// [<Emit("Math.random()")>]
// let getRandom() : float = jsNative
// console.log(getRandom())










// [<Emit("isNaN(parseFloat($0)) ? null : parseFloat($0)  ")>]
// let parseFloat (input : string) : float option = jsNative

// // Correct parsing
// match parseFloat "5.3" with
// | Some value -> console.log(value)
// | None -> console.log("parseFloat failed!")

// // Parsing fails
// match parseFloat "%" with
// | Some value -> console.log(value)
// | None -> console.log("parseFloat failed!")







type IJQuery = interface end

module JQuery = 
  [<Emit("window['$']($0)")>]
  let select (selector: string) : IJQuery = jsNative

  [<Emit("window['$']($0)")>]
  let ready (handler: unit -> unit) : unit = jsNative
  
  [<Emit("$2.css($0, $1)")>]
  let css (prop: string) (value: string) (el: IJQuery) : IJQuery = jsNative
  
  [<Emit("$1.addClass($0)")>]
  let addClass (className: string) (el: IJQuery) : IJQuery = jsNative
  
  [<Emit("$1.click($0)")>]
  let click (handler: obj -> unit)  (el: IJQuery) : IJQuery = jsNative







JQuery.ready (fun () ->
   JQuery.select "#main"
       |> JQuery.css "background-color" "red"
       |> JQuery.click (fun ev -> console.log("Clicked"))
       |> JQuery.addClass "fancy-class"
       |> ignore
)





// type IJQuery2 = 
//   abstract css : string * string -> IJQuery2
//   abstract addClass : string -> IJQuery2

//   [<Emit("$0.click($1)")>]
//   abstract onClick : (obj -> unit) -> IJQuery2

// module JQuery2 = 
//   [<Emit("window['$']($0)")>]
//   let select (selector: string) : IJQuery2 = jsNative

// JQuery2.select("#main")
//       .addClass("fancy")
//       .onClick(fun ev -> console.log("clicked"))
//       .css("background-color", "red")
//       |> ignore








// [<Import("parseJson", "./custom.js")>]
// let parseJson : string -> obj option = jsNative

// [<Import("getValue", "./custom.js")>]
// let getValue : obj -> string -> obj option = jsNative

// let json = "{ \"SpecialProp\": \"hello\" }"

// match parseJson json with
//     | Some objLiteral -> // parse succeeded
//         console.log(objLiteral) 
//         match getValue objLiteral "SpecialProp" with
//         | Some result -> console.log(result) // the value is defined, log it
//         | None -> console.log("No such property was found")
//     | None -> 
//         console.log("Json parsing did not succeed")








//npm install --save left-pad

// let leftPad : string -> int -> char -> string = importDefault "left-pad"

// // pad the string "4" with the char '0' 4 times to the left
// let paddedNumber = leftPad "4" 4 '0'
// console.log(paddedNumber) // "0004"

