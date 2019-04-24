import React, { Component } from 'react'
import Generator from './tasks/generator'
import Toolbox from './task-toolbox'
import { TaskTypes } from './tasks/task-builder'
import genConfig from '../../tests/samples/repository.gen.json'

class Configuration extends Component {
  constructor(props) {
    super(props)
    this.state = {
      configuration: genConfig,
      tasks: TaskTypes
    }
  }

  handleTaskClicked = () => {
    const { configuration } = this.state
  }

  handleTaskLanded = (landingZone, parentName, taskType) => {
    debugger
    const { configuration } = this.state
    const task = this.findTask(configuration, parentName)
    task.tasks.push({ [taskType]: { name: '', description: '' } })

    this.setState({ configuration })
  }

  findTask = (task, parentName) => {
    if (task.name.toLowerCase() === parentName.toLowerCase()) return task
    if (task.tasks) {
      for (let i = 0; i < task.tasks.length; i += 1) {
        const t = this.findTask(Object.values(task.tasks[i])[0], parentName)
        if (t) return t
      }
    }
    return null
  }

  render() {
    const { configuration, tasks } = this.state
    return (
      <div className="container">
        <div className="row">
          <div className="col s7 m8 offset-l1 l7 offset-xl2 xl7">
            <Generator
              {...configuration}
              onTaskLanded={this.handleTaskLanded}
            />
          </div>
          <div className="col s5 m4 l4 xl3">
            <Toolbox tasks={tasks} onTaskLanded={this.handleTaskLanded} />
          </div>
        </div>
      </div>
    )
  }
}

export default Configuration
