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

  handleTaskClicked = () => {}

  handleTaskLanded = () => {}

  render() {
    const { configuration, tasks } = this.state
    return (
      <div className="container">
        <div className="row">
          <div className="col s7 m8 offset-l1 l7 offset-xl2 xl7">
            <Generator {...configuration} />
          </div>
          <div className="col s5 m4 l4 xl3">
            <Toolbox
              tasks={tasks}
              onTaskClicked={this.handleTaskClicked}
              onTaskLanded={this.handleTaskLanded}
            />
          </div>
        </div>
      </div>
    )
  }
}

export default Configuration
