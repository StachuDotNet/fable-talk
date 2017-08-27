module Models

open Elmish

type Time = string

type DayOfWeek = Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday
type Frequency = Daily | WeekDays

type ScheduleTask = { 
    Id: int
    Name: string
    Frequency: Frequency
    StartTime: Time
    EndTime: Time 
}

type Model = 
    { InputTasks: ScheduleTask list
      DisplayDay: DayOfWeek }


type AppMsg = 
    | ChangeName of int * string
    | ChangeStartTime of int * string
    | ChangeEndTime of int * string
    | RemoveTask of int
    | ToggleFrequency of int
    | AddTask
    | ToggleView of DayOfWeek

let init () : Model * Cmd<AppMsg> = 
    {
        InputTasks = 
            [ 
                { Id = 1; Name="Work"; Frequency = Daily; StartTime = "09:00"; EndTime = "17:00" }
                { Id = 2; Name="Drive Home"; Frequency = Daily; StartTime = "17:00"; EndTime = "17:30" }
                { Id = 3; Name="Yoga"; Frequency = WeekDays; StartTime = "05:00"; EndTime = "05:30" }
            ]
        DisplayDay = Monday
    }, []