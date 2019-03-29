import React, { Component } from 'react'
import PropTypes from 'prop-types'
import TaskTypes from '../../model/TaskTypes'
import CreateFolder from './CreateFolder'
import WebDownload from './WebDownload'
import SqlExecute from './SqlExecute'
import CreateProjectItem from './CreateProjectItem'

// export { default as CreateFolder } from './CreateFolder'
// export { default as WebDownload } from './WebDownload'
// export { default as SqlExecute } from './SqlExecute'

const components = [CreateFolder, WebDownload, SqlExecute, CreateProjectItem]

class TaskBuilder extends Component {
  state = {}

  handleChange = e => {
    // console.log(this.state)
    this.setState({
      [e.target.id]: e.target.value
    })
  }

  handleTaskAdded = () => {
    // debugger;
    const { type, onTaskAdded } = this.props
    const item = { ...this.state }
    item.type = type
    onTaskAdded(item)
  }

  render() {
    // console.log('task builder', this.props);
    const { type } = this.props
    const Item = components.find(i => i.type === type)
    return (
      <Item
        {...this.props}
        onChange={this.handleChange}
        onTaskAdded={this.handleTaskAdded}
      />
    )
  }
}

TaskBuilder.propTypes = {
  type: PropTypes.oneOf([
    TaskTypes.COMPOSITE,
    TaskTypes.CREATE_FOLDER,
    TaskTypes.CREATE_PROJECT_ITEM,
    TaskTypes.GENERATE_CODE_FROM_T4_TEMPLATE,
    TaskTypes.SQL_EXECUTE,
    TaskTypes.WEB_DOWNLOAD
  ]),
  onTaskAdded: PropTypes.func
}

TaskBuilder.defaultProps = {
  type: null,
  onTaskAdded: () => {}
}

export default TaskBuilder
