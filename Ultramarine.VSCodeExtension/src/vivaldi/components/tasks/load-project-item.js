import React, { Fragment } from 'react'
import PropTypes from 'prop-types'
import Task from './task'
import Input from '../ui/Input'

const LoadProjectItem = ({
  projectName,
  itemName,
  linkedWith,
  editable,
  onChange,
  ...rest
}) => (
  <Task editable={editable} {...rest} icon={LoadProjectItem.icon}>
    {editable ? (
      <Fragment>
        <Input
          id="projectName"
          text="Project Name"
          value={projectName}
          onChange={onChange}
        />
        <Input
          id="itemName"
          text="Item Name"
          value={itemName}
          onChange={onChange}
        />
        <Input
          id="linkedWith"
          text="Linked With"
          value={linkedWith}
          onChange={onChange}
        />
      </Fragment>
    ) : (
      <Fragment>
        <p>Project Name: {projectName}</p>
        <p>Item Name: {itemName}</p>
        <p>Linked With: {linkedWith}</p>
      </Fragment>
    )}
  </Task>
)

LoadProjectItem.description = 'Load Project Item'
LoadProjectItem.icon = 'code'
LoadProjectItem.type = 'loadProjectItem'

LoadProjectItem.propTypes = {
  itemName: PropTypes.string,
  projectName: PropTypes.string,
  linkedWith: PropTypes.string,
  editable: PropTypes.bool,
  onChange: PropTypes.func
}

LoadProjectItem.defaultProps = {
  itemName: 'All items',
  projectName: 'Current project',
  linkedWith: 'None',
  editable: false,
  onChange: () => {}
}

export default LoadProjectItem
