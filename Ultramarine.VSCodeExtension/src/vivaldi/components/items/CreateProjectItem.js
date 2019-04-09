import React from 'react'
import PropTypes from 'prop-types'
import Task from './Task'
import TaskTypes from '../../model/TaskTypes'

import Input from '../ui/Input'
import Checkbox from '../ui/Checkbox'

const CreateProjectItem = props => {
  const { isEditable, itemName, folderPath, overwrite, onChange } = props
  if (isEditable) {
    return (
      <Task {...props}>
        <Input
          label="Item name"
          htmlFor="itemName"
          value={itemName}
          onChange={onChange}
        />
        <Input
          label="Path"
          htmlFor="path"
          value={folderPath}
          onChange={onChange}
        />
        <Checkbox
          id="overwrite"
          name="Overwrite"
          className="filled-in"
          onChange={onChange}
          overwrite={overwrite}
        />
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
