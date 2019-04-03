import React from 'react'
import PropTypes from 'prop-types'
import Task from './Task'
import TaskTypes from '../../model/TaskTypes'

const CreateFolder = props => {
  // console.log('create folder', this.props);
  const { isEditable, folderPath, onChange } = props
  if (isEditable) {
    return (
      <Task {...props}>
        <div className="input-field">
          <input id="path" type="text" onChange={onChange} />
          <label htmlFor="path">Path</label>
        </div>
      </Task>
    )
  }
  return (
    <Task {...props}>
      <p>Path: {folderPath}</p>
    </Task>
  )
}

CreateFolder.propTypes = {
  isEditable: PropTypes.bool,
  folderPath: PropTypes.string,
  onChange: PropTypes.func
}

CreateFolder.defaultProps = {
  isEditable: false,
  folderPath: '',
  onChange: () => {}
}

CreateFolder.type = TaskTypes.CREATE_FOLDER

export default CreateFolder
