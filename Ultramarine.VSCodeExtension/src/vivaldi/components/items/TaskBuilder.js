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
  constructor(props) {
    super(props)
    this.state = { ...props }
  }

  handleChange = e => {
    // console.log(this.state)
    this.setState({
      [e.target.id]:
        e.target.type === 'checkbox' ? e.target.checked : e.target.value
    })
  }

  handleTaskUpdated = () => {
    const { type, onTaskUpdated } = this.props
    const item = { ...this.state }
    item.type = type
    onTaskUpdated(item)
  }

  render() {
    // console.log('task builder', this.props);
    const { type, isEditable } = this.props
    const Item = components.find(i => i.type === type)
    const values = isEditable
      ? { ...this.state, isEditable }
      : { ...this.props }
    return (
      <Item
        {...values}
        onChange={this.handleChange}
        onTaskUpdated={this.handleTaskUpdated}
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
  isEditable: PropTypes.bool,
  onTaskUpdated: PropTypes.func
}

TaskBuilder.defaultProps = {
  type: null,
  isEditable: false,
  onTaskUpdated: () => {}
}

export default TaskBuilder
