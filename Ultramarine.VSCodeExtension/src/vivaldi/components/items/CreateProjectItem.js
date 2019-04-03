import React from 'react'
import PropTypes from 'prop-types'
import Task from './Task'
import TaskTypes from '../../model/TaskTypes'

const CreateProjectItem = props => {
  const { isEditable, itemName, folderPath, overwrite, onChange } = props
  if (isEditable) {
    return (
      <Task {...props}>
        <div className="input-field">
          <input id="itemName" type="text" onChange={onChange} />
          <label htmlFor="itemName">Item name</label>
        </div>
        <div className="input-field">
          <input id="path" type="text" onChange={onChange} />
          <label htmlFor="path">Path</label>
        </div>
        <label>
          <input
            id="overwrite"
            type="checkbox"
            className="filled-in"
            onChange={onChange}
          />
          <span>Overwrite</span>
        </label>
      </Task>
    )
  }

  return (
    <Task {...props}>
      <p>Item name: {itemName}</p>
      <p>Path: {folderPath}</p>
      <p>Overwrite: {overwrite.toString()}</p>
    </Task>
  )
}

CreateProjectItem.propTypes = {
  isEditable: PropTypes.bool,
  itemName: PropTypes.string,
  folderPath: PropTypes.string,
  overwrite: PropTypes.bool,
  onChange: PropTypes.func
}

CreateProjectItem.defaultProps = {
  isEditable: false,
  itemName: '',
  folderPath: '',
  overwrite: false,
  onChange: () => {}
}

CreateProjectItem.type = TaskTypes.CREATE_PROJECT_ITEM

export default CreateProjectItem
