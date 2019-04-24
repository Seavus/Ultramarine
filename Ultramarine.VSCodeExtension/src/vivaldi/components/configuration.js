import React, { Component } from 'react'
import PropTypes from 'prop-types'
import { isEqual } from 'underscore'
import Generator from './tasks/generator'
import Toolbox from './task-toolbox'
import { TaskTypes } from './tasks/task-builder'

class Configuration extends Component {
  constructor(props) {
    super(props)
    const { settings } = this.props
    this.state = {
      configuration: settings,
      tasks: TaskTypes
    }
  }

  static getDerivedStateFromProps(props, state) {
    const { settings } = props
    const { configuration } = state

    if (isEqual(settings, configuration)) return null
    return {
      configuration: settings,
      tasks: TaskTypes
    }
  }

  handleTaskClicked = () => {
    // const { configuration } = this.state
  }

  handleTaskLanded = (landingZone, parentName, taskType) => {
    const { configuration } = this.state
    const task = this.findTask(configuration, parentName)
    task.tasks.push({
      [taskType]: { name: '', description: '', editable: true }
    })

    this.setState({ configuration })
  }

  handleTaskChange = () => {}

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
              onChange={this.handleTaskChange}
            />
          </div>
          <div className="col s5 m4 l4 xl3">
            <Toolbox
              tasks={tasks}
              onTaskLanded={this.handleTaskLanded}
              onTaskClicked={this.handleTaskClicked}
            />
          </div>
        </div>
      </div>
    )
  }
}

Configuration.propTypes = {
  settings: PropTypes.shape({})
}
Configuration.defaultProps = {
  settings: {
    name: 'generatorConfig',
    tasks: []
  }
}

export default Configuration
