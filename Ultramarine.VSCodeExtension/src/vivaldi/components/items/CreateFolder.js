import React from 'react'
import PropTypes from 'prop-types'
import Task from './Task'
import TaskTypes from '../../model/TaskTypes'

const CreateFolder = props => {
  // console.log('create folder', this.props);
  const { isEditable, folderPath, projectName, onChange } = props
  if (isEditable) {
    return (
      <Task {...props}>
        <div className="input-field">
          <input
            id="folderPath"
            type="text"
            onChange={onChange}
            value={folderPath}
          />
          <label htmlFor="folderPath" className={folderPath ? 'active' : ''}>
            Path
          </label>
        </div>
        <div className="input-field">
          <input
            id="projectName"
            type="text"
            onChange={onChange}
            value={projectName}
          />
          <label htmlFor="projectName" className={projectName ? 'active' : ''}>
            Project Name
          </label>
        </div>
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
