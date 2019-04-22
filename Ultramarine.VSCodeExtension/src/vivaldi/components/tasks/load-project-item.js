import React, { Fragment } from 'react'
import PropTypes from 'prop-types'
import Task from './task'
import Input from '../ui/Input'

const Icon = ({ name }) => <i className="material-icons tooltipped">{name}</i>
Icon.propTypes = {
  name: PropTypes.string.isRequired
}

const LoadProjectItem = ({
  projectName,
  itemName,
  linkedWith,
  editable,
  ...rest
}) => (
  <Task editable={editable} {...rest}>
    <Icon name="code" />
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

LoadProjectItem.propTypes = {
  itemName: PropTypes.string,
  projectName: PropTypes.string,
  linkedWith: PropTypes.string,
  editable: PropTypes.bool
}

LoadProjectItem.defaultProps = {
  itemName: 'All items',
  projectName: 'Current project',
  linkedWith: 'None',
  editable: false
}

export default LoadProjectItem
