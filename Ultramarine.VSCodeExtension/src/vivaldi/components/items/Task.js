import React from 'react'
import PropTypes from 'prop-types'

const Task = ({
  name,
  description,
  isEditable,
  children,
  onLandingCancelled,
  onChange,
  onTaskAdded
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
    <div className="card z-depth-0">
      <div className="card-content">
        <span className="card-title">{name}</span>
        <p className="mb-small">{description}</p>
        {children}
      </div>
    </div>
  )
}

Task.propTypes = {
  name: PropTypes.string,
  description: PropTypes.string,
  isEditable: PropTypes.bool,
  children: PropTypes.oneOfType([
    PropTypes.arrayOf(PropTypes.node),
    PropTypes.node
  ]),
  onLandingCancelled: PropTypes.func,
  onChange: PropTypes.func,
  onTaskAdded: PropTypes.func
}

Task.defaultProps = {
  name: '',
  description: '',
  isEditable: false,
  children: null,
  onLandingCancelled: () => {},
  onChange: () => {},
  onTaskAdded: () => {}
}

export default Task
