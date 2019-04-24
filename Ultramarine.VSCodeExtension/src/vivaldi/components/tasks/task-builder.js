import React from 'react'
import BuildProject from './generated/BuildProject.generated'
import CreateFolder from './generated/CreateFolder.generated'
import CreateProjectItem from './generated/CreateProjectItem.generated'
import Iterator from './generated/Iterator.generated'
import LoadCodeElement from './generated/LoadCodeElement.generated'
import LoadProjectItem from './generated/LoadProjectItem.generated'
import ReadProperty from './generated/ReadProperty.generated'
import SetVariable from './generated/SetVariable.generated'
import StringManipulation from './generated/StringManipulation.generated'
import TextTransformation from './generated/TextTransformation.generated'
import WebDownload from './generated/WebDownload.generated'
import Task from './task'

export const Tasks = [
  BuildProject,
  CreateFolder,
  CreateProjectItem,
  Iterator,
  LoadCodeElement,
  LoadProjectItem,
  ReadProperty,
  SetVariable,
  StringManipulation,
  TextTransformation,
  WebDownload
]

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
