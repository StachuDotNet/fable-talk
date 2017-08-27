# Building a Task Scheduler

## 1 - Output only
- create a model
- create the task scheduler
- create view helpers
- create output view
- create app

## 2 - Split input/output
- create input/output folders
- migrate output stuff to Output.fs
- create InputView.fs, then SingleTask.fs
- enhance View.fs to have 2 columns, use InputView

## 3 - Change Task Name
- Update Models.fs w/ new Msg
- Update Update.fs to handle name change

## 4 - Change Start/End Time
- Update Models.fs w/ new Msgs
- Update Update.fs to handle start/end time changes
- Update SingleTask.fs to have a helper simpleInput, and use it

## 5 - Remove Task
- Update Models.fs w/ new Msg
- Update Update.fs to handle task removal
- Update InputView.fs to handle task removal

## 6 - Add Task
- Update Models.fs w/ new Msg
- Update Update.fs to handle task addition
- Update InputView.fs to handle task addition

## 7 - Introduce Frequency
- Update Models.fs w/ new types, upgrade the model, etc.
- Update Update.fs to handle changes
- Update TaskScheduler.fs to handle changes
- Update SingleTask.fs

## 8 - Utilize Frequency
- Move things in Output.fs into new file DayView.fs
- Create DayView.fs
- Update Models.fs w/ new toggle view thing
- Update Update.fs to handle changes