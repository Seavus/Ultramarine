import React from 'react'
import PropTypes from 'prop-types'

const Task = ({
  id,
  name,
  description,
  isEditable,
  children,
  onLandingCancelled,
  onChange,
  onTaskAdded,
  onFlyOver
}) => {
  // debugger;
  // console.log('task', props);
  if (isEditable) {
    return (
      <div className="card z-depth-0">
        <div className="card-content">
          <div className="input-field">
            <input id="name" type="text" onChange={onChange} />
            <label htmlFor="name">Name</label>
          </div>
          <div className="input-field">
            <input id="description" type="text" onChange={onChange} />
            <label htmlFor="description">Description</label>
          </div>
          {children}
        </div>
        <div className="card-action right-align">
          <button
            type="button"
            className="waves-effect waves-light btn grey mlr-small"
            onClick={onLandingCancelled}
          >
            Cancel
          </button>
          <button
            type="button"
            className="waves-effect waves-light btn"
            onClick={onTaskAdded}
          >
            Submit
          </button>
        </div>
      </div>
    )
  }
  return (
    <div className="card z-depth-0" onDragOver={e => onFlyOver(e, id)}>
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
  onLandingCancelled: PropTypes.func,
  onChange: PropTypes.func,
  onTaskAdded: PropTypes.func,
  onFlyOver: PropTypes.func
}

Task.defaultProps = {
  id: null,
  name: '',
  description: '',
  isEditable: false,
  children: null,
  onLandingCancelled: () => {},
  onChange: () => {},
  onTaskAdded: () => {},
  onFlyOver: () => {}
}

export default Task
