module TaskScheduler 

open Models

type ScheduledTask = { Name: string; StartTime: Time; EndTime: Time }

let allowedTask displayDay task =
    let weekDays = [Monday; Tuesday; Wednesday; Thursday; Friday]

    match task.Frequency with
    | Daily -> true
    | WeekDays -> 
        weekDays |> List.contains displayDay

let taskScheduler displayType scheduleTasks  = 
    scheduleTasks 
        |> List.filter(allowedTask displayType)
        |> List.map(fun (v: ScheduleTask) -> 
            { Name = v.Name
              StartTime = v.StartTime
              EndTime = v.EndTime
            })