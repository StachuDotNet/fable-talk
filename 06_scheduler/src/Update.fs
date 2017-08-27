module Update

open Models

let updateInputTasks msg model =
    match msg with
    | ToggleView day -> model
    | ChangeName (id, newName) -> 
        let updateEntry t = if t.Id = id then { t with Name = newName } else t
        List.map updateEntry model

    | ChangeStartTime (id, newStartTime) -> 
        let updateEntry t = if t.Id = id then { t with StartTime = newStartTime } else t
        List.map updateEntry model
        
    | ChangeEndTime (id, newEndTime) -> 
        let updateEntry t = if t.Id = id then { t with EndTime = newEndTime } else t
        List.map updateEntry model

    | RemoveTask id ->
        model |> List.filter(fun t -> t.Id <> id)

    | ToggleFrequency id -> 
        let updateEntry t = 
            if t.Id = id then 
                let newFrequency = 
                    match t.Frequency with
                    | Daily -> WeekDays
                    | WeekDays -> Daily

                { t with Frequency = newFrequency } 
            else t

        List.map updateEntry model

    | AddTask ->
        let newId = 
            if List.isEmpty model then
                1
            else 
                model 
                |> List.map(fun i -> i.Id) 
                |> List.max |> (+) 1

        let newTask = { Id = newId; Name="New Task"; Frequency = Daily; StartTime = "00:00"; EndTime="00:00"}

        newTask :: model

let update msg model = 
    match msg with 
    | ToggleView newDayOfWeek-> 
        { model with DisplayDay = newDayOfWeek }, []

    | _ -> { model with InputTasks = updateInputTasks msg model.InputTasks}, []
    