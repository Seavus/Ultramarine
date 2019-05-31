import React from 'react'
import PropTypes from 'prop-types'

import Input from '../ui/Input'
import Button from '../ui/Button'

const Task = ({
  id,
  name,
  description,
  isEditable,
  children,
  onTaskUpdateCancelled,
  onChange,
  onTaskUpdated,
  onFlyOver,
  onTaskEdit
}) => {
  // debugger;
  // console.log('task', props);
  if (isEditable) {
    return (
      <div className="card z-depth-0">
        <div className="card-content">
          <Input text="Name" htmlFor="name" value={name} onChange={onChange} />
          <Input
            text="Description"
            htmlFor="description"
            value={description}
            onChange={onChange}
          />
          {children}
        </div>
        <div className="card-action right-align">
          <Button
            text="Cancel"
            className="waves-effect waves-light btn grey mlr-small"
            onClick={() => onTaskUpdateCancelled(id)}
          />
          <Button
            text="Submit"
            className="waves-effect waves-light btn"
            onClick={onTaskUpdated}
          />
        </div>
      </div>
    )
  }
  return (
    <div
      className="card z-depth-0"
      onDragOver={() => onFlyOver(id)}
      role="button"
      tabIndex="0"
      onKeyPress={() => {}}
      onClick={() => onTaskEdit(id)}
    >
      <div className="card-content">
        <span className="card-title">{name}</span>
        <p className="mb-small">{description}</p>
        {children}
      </div>
    </div>
  )
}

Task.propTypes = {
  id: PropTypes.number,
  name: PropTypes.string,
  description: PropTypes.string,
  isEditable: PropTypes.bool,
  children: PropTypes.oneOfType([
    PropTypes.arrayOf(PropTypes.node),
    PropTypes.node
  ]),
  onTaskUpdateCancelled: PropTypes.func,
  onChange: PropTypes.func,
  onTaskUpdated: PropTypes.func,
  onFlyOver: PropTypes.func,
  onTaskEdit: PropTypes.func
}

Task.defaultProps = {
  id: null,
  name: '',
  description: '',
  isEditable: false,
  children: null,
  onTaskUpdateCancelled: () => {},
  onChange: () => {},
  onTaskUpdated: () => {},
  onFlyOver: () => {},
  onTaskEdit: () => {}
}

export default Task
