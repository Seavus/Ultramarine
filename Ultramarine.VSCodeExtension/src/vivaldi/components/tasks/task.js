import React from 'react'
import PropTypes from 'prop-types'

const Task = ({ name, description, children, icon }) => (
  <div className="card z-depth-0">
    <div className="card-content">
      <span className="card-title">{name}</span>
      <p>{description}</p>
      <div className="card-action">
        {children}
        <i className="material-icons">{icon}</i>
      </div>
    </div>
  </div>
)

Task.propTypes = {
  name: PropTypes.string.isRequired,
  description: PropTypes.string,
  children: PropTypes.oneOfType([
    PropTypes.arrayOf(PropTypes.node),
    PropTypes.node
  ]),
  icon: PropTypes.string
}

Task.defaultProps = {
  description: '',
  children: null,
  icon: 'adjust'
}

export default Task
