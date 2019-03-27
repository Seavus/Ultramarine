import React from 'react'
import PropTypes from 'prop-types'
import Task from './Task'
import TaskTypes from '../../model/TaskTypes'

const CreateProjectItem = props => {
  // console.log('create folder', this.props);
  const { isEditable } = props
  if (isEditable) {
    return <Task {...props} />
  }
  return <Task {...props} />
}

CreateProjectItem.propTypes = {
  isEditable: PropTypes.bool,
  path: PropTypes.string,
  onChange: PropTypes.func
}

CreateProjectItem.defaultProps = {
  isEditable: false,
  path: '',
  onChange: () => {}
}

CreateProjectItem.type = TaskTypes.CreateProjectItem

export default CreateProjectItem
