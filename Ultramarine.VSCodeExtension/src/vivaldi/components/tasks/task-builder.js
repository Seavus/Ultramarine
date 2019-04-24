import React from 'react'
import CreateFolder from './create-folder'
import LoadProjectItem from './load-project-item'
import Iterator from './iterator'
import Task from './task'

export const Tasks = [CreateFolder, LoadProjectItem, Iterator]

export const TaskTypes = Tasks.map(t => ({
  name: t.name,
  description: t.description,
  icon: t.icon,
  type: t.type
}))

const getTaskType = task => Object.keys(task)[0]
const getTask = task =>
  Tasks.find(t => t.name.toLowerCase() === getTaskType(task).toLowerCase())

const taskBuilder = (task, onTaskLanded, onChange) => {
  const taskType = getTaskType(task)
  const taskSettings = task[taskType]
  const ConcreteTask = getTask(task)
  return ConcreteTask ? (
    <ConcreteTask
      key={taskSettings.name}
      {...taskSettings}
      onTaskLanded={onTaskLanded}
      onChange={onChange}
    />
  ) : (
    <Task key={taskSettings.name} {...taskSettings} onChange={onChange} />
  )
}

export default taskBuilder
