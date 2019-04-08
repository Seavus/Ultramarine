import React from 'react'
import PropTypes from 'prop-types'
import Task from './Task'
import TaskTypes from '../../model/TaskTypes'

import Input from '../ui/Input'

const CreateFolder = props => {
  // console.log('create folder', this.props);
  const { isEditable, folderPath, projectName, onChange } = props
  if (isEditable) {
    return (
      <Task {...props}>
        <Input
          label="Path"
          htmlFor="folderPath"
          value={folderPath}
          onChange={onChange}
        />
        <Input
          label="Project Name"
          htmlFor="projectName"
          value={projectName}
          onChange={onChange}
        />
      </Task>
    )
  }
  return (
    <Task {...props}>
      <p>Path: {folderPath}</p>
      <p>Project Name: {projectName}</p>
    </Task>
  )
}

CreateFolder.propTypes = {
  isEditable: PropTypes.bool,
  folderPath: PropTypes.string,
  projectName: PropTypes.string,
  onChange: PropTypes.func
}

CreateFolder.defaultProps = {
  isEditable: false,
  folderPath: '',
  projectName: '',
  onChange: () => {}
}

CreateFolder.type = TaskTypes.CREATE_FOLDER

export default CreateFolder
